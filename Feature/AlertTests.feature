Feature: AlertTests
	As a User I want to confirm
	an alert to submit provided data

@AUTO
Scenario: Closing an alert after clicking submit button
	When User click submit button and alert appears
	Then Alert message is displayed

@AUTO
Scenario: Accepting an alert after clicking submit button
	When User click submit button and confirms alert that appears
	Then Correct message appears on page