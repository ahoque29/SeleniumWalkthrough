Feature: APSignin
	As a registered user of the automation practice website
	I want to be able to sign in
	So that I can access my account

@navigate
Scenario: Go to signin page from home page
	Given I am on the home page
	When I click the Signin link
	Then I go to the Signin page

@login
#GivenIamOnTheSignInPage_AndIEnterAFourDigitPassword_ThenIClickTheSigninButton_ThenIGetAnErrorMessage
Scenario: Signing in with an incorrect password
	Given I am on the sign in page
	And I have entered the email 'tester@testing.com'
	And I have entered the password <password>
	When I click the sign in button
	Then I should see an alert containing the error message 'invalid password'
Examples:
| password |
| four     |
| 1234     |
| Nish     |