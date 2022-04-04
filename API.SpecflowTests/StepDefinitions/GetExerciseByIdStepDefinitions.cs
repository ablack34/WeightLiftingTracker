using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using TechTalk.SpecFlow;
using TrackerAPI.Data;
using API.SpecflowTests.Contexts;
using System.Net;
using TrackerAPI.Models;
using API.SpecflowTests.Helpers;

namespace API.SpecflowTests.StepDefinitions
{
    [Binding]
    public class GetExerciseByIdStepDefinitions
    {
        //Should this be a new "Test" context or context from Project?
        private TestExerciseContext _context;

        public GetExerciseByIdStepDefinitions(TestExerciseContext context)
        {
            _context = context;
        }

        [Given(@"We are running the API with Sample Data")]
        public void GivenWeAreRunningTheAPIWithSampleData()
        {
            _context!.HttpClient = new WebApplicationFactory<Program>().CreateClient();
        }

        [When(@"I send a '([^']*)' request to '([^']*)' endpoint")]
        public async void WhenISendARequestToEndpoint(HttpMethod method, Uri uri)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, uri);
            try
            {
                var test = await _context!.HttpClient!.SendAsync(request);
            }
            catch (Exception ex)
            {

            }
            _context!.LastHttpResponseMessage = await _context!.HttpClient!.SendAsync(request);
        }

        [Then(@"A '([^']*)' response is returned")]
        public void ThenAResponseIsReturned(HttpStatusCode expectedhttpStatusCode)
        {
            _context!.LastHttpResponseMessage!.StatusCode.Should().Be(expectedhttpStatusCode);
        }

        [Then(@"A '([^']*)' restaurant details are retrieved")]
        public async void ThenARestaurantDetailsAreRetrieved(string expectedExerciseName)
        {
            Exercise exerciseResult = await _context!.LastHttpResponseMessage!.GetBodyAs<Exercise>();

            exerciseResult.Should().NotBeNull();
            exerciseResult.Name.Should().Be(expectedExerciseName);
        }

        [Then(@"The response should contain '([^']*)'")]
        public async void ThenTheResponseShouldContain(string expectedResponseText)
        {
            string responseBody = await _context!.LastHttpResponseMessage!.GetBodyAsString();

            responseBody.Should().Be(expectedResponseText);
        }
    }
}
