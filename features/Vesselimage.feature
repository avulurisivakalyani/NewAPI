Feature: Vessel 
VesselImage HC,GET,POST METHOD
@test
Scenario:Vesselimage API
Given  Iset endpoint as 'api/check'
When I set HCGET method 
Then I set Headers
      | Key	     | Value	        | 
      | Content-Type | application/json |        
Then I should receive valid response code '200' 
