Feature: Vesselimage
VesselImage HC,GET,POST METHOD
@test
Scenario:Vesselimage API
Given  Iset endpoint as 'api/health-check'
When I set HCGET method 
Then I set Headers
      | Key	     | Value	        | 
      | Content-Type | application/json |        
Then I should receive valid response code '200' 
