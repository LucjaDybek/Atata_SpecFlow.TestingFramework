Feature: TextBoxTests
#Test description
	As a user, to make an order 
	I want to provide the store 
	with my address and contact infomration 

@AUTO
@FrontEnd
#Scenario title
Scenario: Correct address form filling process  
#Scenario Steps
	When User input all personal data on address form page
	And confirm the data by clicking button
	Then user should see provided data below