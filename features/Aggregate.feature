﻿@tag
Feature: Aggregate API

Aggregate HC API Test 

@SmokeTest 
Scenario:Aggregate API
    Given I set endpoint as 'api/health'
   When I set method  GET
   Then I set Get Header param request content type Get 
  | Key	 | Value| 
  | Content-Type | application/json |      
Then I should receive valid HTTP response code '200'
