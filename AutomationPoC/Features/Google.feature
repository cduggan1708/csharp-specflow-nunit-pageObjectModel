Feature: Sample Feature
	In order to demonstrate the value of an open-source automation solution
	As a QA Automation Engineer
	I want to give an example of how to test using a feature file

	Scenario Outline: Test Scenario
      Given I am a user on Google
      When I search for "<searchString>"
      Then I should be directed to the "Google Search Results" page
      And I should see "<searchString>" in the search field
      Examples:
        | searchString							 |
        | how wonderful is the Gherkin language? |