Feature: GetExerciseById

	As a user of the TrackerAPI
	I want to be able to get an Exercise
	So that I can see my lifting stats

Background: 
	Given We are running the API with Sample Data

@getPositiveScenario
Scenario: Get an Exercise by a valid ID
	When I send a 'GET' request to '<EndpointUrl>' endpoint
	Then A '<ResponseCode>' response is returned
	And A '<ExerciseName>' restaurant details are retrieved

Examples: 
	| EndpointUrl         | ResponseCode | ExerciseName |
	| /api/Exercises/1003 | 200          | Jerk         |
	| /api/Exercises/1004 | 200          | Pull-up      |

@getNegativeScenario
Scenario: Get an Exercise by a invalid ID
	When I send a 'GET' request to '<EndpointUrl>' endpoint
	Then A '<ResponseCode>' response is returned
	And The response should contain '<ResponseText>'

Examples: 
	| EnpointUrl        | ResponseCode | ResponseText |
	| api/Exercises/111 | 404          | Not Found    |