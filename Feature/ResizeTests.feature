Feature: ResizeTests
	As a User I want to resize a comment box 

Scenario: Making a box bigger by dragging a handle 
	When User increases the box by '20' and '50' pixels dragging handle
	Then the box has bigger size