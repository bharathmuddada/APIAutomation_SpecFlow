Feature: Basic test Operation
tests endpoints in https://reqres.in/

    @genderize
    Scenario: GET List of users
        Given I perform a GET operation "/?name=luc"
        Then Status code should be "200"

    @reqres
    Scenario: GET Single User
        Given I perform a GET operation "/api/users/2"
        Then Status code should be "200"