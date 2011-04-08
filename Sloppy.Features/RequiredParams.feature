Feature: Required params 
	In order to ensure the user thinks about some optiosn 
	As a developer
	I want to be some params are being passed 

Scenario: a required option is passed 
	Given I have the following option that is required
		| short | long    | description |
		| m     | message | message     |
		| v     | verbose | verbose     | 
	When I pass in the arguments 
		| args                   |
		| --message              |
		| bad clown, sad summmer |
		| --verbose |
	Then the property message should return "bad clown, sad summmer"
	And the property verbose should exist

Scenario: a required option is not passed 
	Given I have the following option that is required
		| short | long    | description |
		| m     | message | message     |
		| v     | verbose | verbose     | 
	When I pass in the arguments 
		| args      |
		| --verbose |
	Then there should be an exception 
