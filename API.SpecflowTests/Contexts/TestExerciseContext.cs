using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.SpecflowTests.Contexts
{
    public sealed class TestExerciseContext
    {
        public HttpClient? HttpClient { get; set; }

        public HttpResponseMessage? LastHttpResponseMessage { get; set; }

        public string? LastHttpResponseMessageLocationHeaderValue { get; set; }
    }
}
