Feature: Basic options 
	In order to easily parse input
	As a developer
	I want to be sure my argument object returns the proper results 

@mytag
Scenario: Option with no value 
	Given I have the following option 
		| short | long    | description |
		| v     | verbose | verbose     |
	When I pass in the arguments 
		| args      |
		| --verbose |
	Then the property verbose should exist
