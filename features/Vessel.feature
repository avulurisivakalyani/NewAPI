Feature: Vessel API
Vessel  HC,GET,POST
@test
Scenario: HC  API
Given I set GET endpoint 'api/v/-check'
When I set HC method 
Then I set  headers
      | Key	| Value| 
      | Content-Type | application/json |        
Then I shouldreceive valid response code as'200' 
@test
 Scenario:POST search=true 
Given I set Post endpoint 'api/checkapi'
When I set VesselSearch POST method
Then I set headers to Post 
  | Key	| Value| 
      | Content-Type | application/json | 
Then I set Payload
Then I should Post receive valid response code as'200' 

