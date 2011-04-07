Feature: Basic options 
	In order to easily parse input
	As a developer
	I want to be sure my argument object returns the proper results 

Scenario: Long option with no value exists
	Given I have the following option 
		| short | long    | description |
		| v     | verbose | verbose     |
	When I pass in the arguments 
		| args      |
		| --verbose |
	Then the property verbose should exist


Scenario: Long option with no value returns null
	Given I have the following option 
		| short | long    | description |
		| v     | verbose | verbose     |
	When I pass in the arguments 
		| args      |
		| --verbose |
	Then the property verbose should return "<null>"

Scenario: Short option with no value exists
	Given I have the following option 
		| short | long    | description |
		| v     | verbose | verbose     |
	When I pass in the arguments 
		| args |
		| -v   |
	Then the property verbose should exist


Scenario: Short option with no value returns null
	Given I have the following option 
		| short | long    | description |
		| v     | verbose | verbose     |
	When I pass in the arguments 
		| args |
		| -v   |
	Then the property verbose should return "<null>"

	
Scenario: Long option with value exists
	Given I have the following option 
		| short | long    | description |
		| m     | message | message     |
	When I pass in the arguments 
		| args                   |
		| --message              |
		| bad clown, sad summmer |
	Then the property message should exist


Scenario: Long option with value returns value 
	Given I have the following option 
		| short | long    | description |
		| m     | message | message     |
	When I pass in the arguments 
		| args                   |
		| --message              |
		| bad clown, sad summmer |
	Then the property message should return "bad clown, sad summmer"

Scenario: Short option with value exists
	Given I have the following option 
		| short | long    | description |
		| m     | message | message     |
	When I pass in the arguments 
		| args                   |
		| -m                     |
		| bad clown, sad summmer |
	Then the property message should exist


Scenario: Short option with value returns value 
	Given I have the following option 
		| short | long    | description |
		| m     | message | message     |
	When I pass in the arguments 
		| args                   |
		| -m                     |
		| bad clown, sad summmer |
	Then the property message should return "bad clown, sad summmer"