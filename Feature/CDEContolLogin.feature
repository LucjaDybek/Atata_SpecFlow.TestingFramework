Feature: Login
	Login to Appliation

@mytag
Scenario: Login to page
	When User enter data to login
	Then User is log in

@mytag
Scenario: Login to page with wrogn data
	When User enter worng data to login
	Then User is not log in