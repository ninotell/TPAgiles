#AUTOGENERADO CON LA CREACION DEL PROYECTO

Feature: Wordle

	In order to play the game
	As a player
	I must enter my username
	I want to enter my guesses and know if i won or not

@tag1
Scenario: Enter the username
	Given I have entered Juan as name
	When I click on button Jugar Ahora
	Then I should be told Bienvenido Juan

Scenario: Enter a word
	Given I am logged as Juan
	When I enter MANO as the word to guess and click the button Intentar Palabra
	Then I should see the word MANO in the words section

Scenario: Lose a game
	Given I am logged as Juan
	When I enter MANO as the word to guess 4 times
	Then I should be told that I lost

Scenario: Win a game
	Given I am logged as Juan
	When I enter the correct word
	Then I should be told that I won