Feature: Option defuauls 
	In order to have default values if nothing was passed in 
	As a developer
	I want to be sure defaults are being set for missing values 

Scenario: option with value returns values 
	Given I have the following option 
		| short | long    | description | default        |
		| m     | message | message     | god loves ugly | 
	When I pass in the arguments 
		| args                   |
		| --message              |
		| bad clown, sad summmer |
	Then the property mesage should return "bad clown, sad summmer"
