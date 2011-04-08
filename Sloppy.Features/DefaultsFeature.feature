Feature: Option defualts 
	In order to have default values if nothing was passed in 
	As a developer
	I want to be sure defaults are being set for missing values 

Scenario: option with value returns values 
	Given I have the following option with a default param 
		| short | long    | description | default        |
		| m     | message | message     | god loves ugly | 
	When I pass in the arguments 
		| args                   |
		| --message              |
		| bad clown, sad summmer |
	Then the property message should return "bad clown, sad summmer"

Scenario: option without a value returns the default 
	Given I have the following option with a default param 
		| short | long    | description | default        |
		| m     | message | message     | god loves ugly |
		| v     | verbose | verbose     | true           |
	When I pass in the arguments 
		| args      |
		| --verbose |
	Then the property message should return "god loves ugly"
