Feature: Wordle

	In order to play the game
	As a player
	I must enter my username
	I want to enter my guesses and know if i won or not

@tag1
Scenario: Enter the username
	Given I have entered default Errors and Difficulty
	When I enter Juan as the Name
	Then I should be told Bienvenido JUAN

Scenario: Enter Word
	Given I have entered Juan as the name and default Errors and Difficulty
	When I enter Juan as the word to guess
	Then I should see the word and be told it is incorrect

Scenario: Lose Game
	Given I have entered Juan as the name and default Errors and Difficulty
	When I enter Juan as the word to guess 4 times
	Then I should be told that I lost

Scenario: Win Game
	Given I have entered Juan as the name and default Errors and Difficulty
	When I enter the correct word
	Then I should be told that I won
