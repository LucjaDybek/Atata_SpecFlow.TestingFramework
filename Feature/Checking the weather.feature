Feature: Checking the weather
	As a User, I want to check the weather 
	for a selected city and forecast length 

Scenario: User wants to check the weather today in imperial units by API
	When User check the weather today in imperial units by Api
	Then Imperial temperature and city are visible and correct

	
Scenario: User wants to check the weather today in metric units by API
	When User check the weather today in metric units by Api
	Then Metric temperature and city are visible and correct


Scenario: User wants to check climate forecast for 30 days in imperial units by API
	When User check the climate forecast for 30 days in imperial units by Api
	Then Imperial temperature list and city are visible and correct for 30 days