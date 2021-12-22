Feature: ButtonTests
	As a User, I want to submit data 
	by clicking a button

Scenario: Submitting data by double clicking the button
	When User double clicks a submit button
	Then Confirm double click message appears

Scenario: Submitting data by right clicking the button
	When User right clicks a submit button
	Then Confirm right click message appears

Scenario: Submitting data by clicking the button
	When User clicks a submit button
	Then Confirm message appears