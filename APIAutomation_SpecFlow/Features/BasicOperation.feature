Feature: Basic test Operation
tests endpoints in https://reqres.in/

    @reqres
    Scenario: GET Single user from reqres
        Given I perform a GET operation "/api/users/2"
        Then Status code should be "200"

    @catfact
    Scenario: GET a catfact
        Given I perform a GET operation "/fact"
        Then Status code should be "200"
        Then count of stores should be equal