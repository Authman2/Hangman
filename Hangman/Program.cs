using System;

namespace Hangman {

	class MainClass {
		
		/* The mystery word and the hint. Change these when playing the game. */
		public static string MysteryWord = "Computer Science", Hint = "Topics include computers, programming languages, video game development...";

		/* All of the letters that have been guessed and what the user has guessed so far. */
		public static string GuessedLetters = "", GuessedWord = "";

		/* The number of wrong and right guesses. */
		public static int wrong = 0, right = 0, maxWrong = 10, maxRight = 0;


		public static void Main(string[] args) {

			//Set up underscores
			for (int i = 0; i < MysteryWord.Length; i++) {
				if (MysteryWord [i].Equals (' ')) {
					GuessedWord += " ";
				} else {
					GuessedWord += "_";
					maxRight++;
				}
			}


			ShowGuessed ();
			GuessAgain ();
		}

		/// <summary>
		/// Prints what the user has guessed so far. Prints an underscore if the letter
		/// has not been guessed yet.
		/// </summary>
		public static void ShowGuessed() {
			foreach(char c in GuessedWord) {
				Console.Write(c + " ");
			}
			Console.WriteLine ();
		}



		/// <summary>
		/// Prompts the user to make another guess.
		/// </summary>
		public static void GuessAgain() {
			Console.WriteLine("Hint: " + Hint);
			Console.WriteLine("Guesses: " + GuessedLetters);
			Console.WriteLine ("Guess a letter: ");
			string guess = Console.ReadLine ();
			GuessLetter (guess);
		}

		/// <summary>
		/// Changes the guessed word based on what has been entered.
		/// </summary>
		public static void ChangeGuessed(string guess) {
			string temp = "";
			for (int i = 0; i < MysteryWord.Length; i++) {
				if (MysteryWord [i].Equals (GuessedWord [i])) {
					temp += GuessedWord [i];
				} else if (MysteryWord [i].Equals (guess.ToLower() [0]) || MysteryWord [i].Equals (guess.ToUpper() [0])) {
					if (MysteryWord [i].Equals (MysteryWord.ToUpper () [i])) {
						temp += guess.ToUpper () [0];
					} else {
						temp += guess [0];
					}
				
				} else if (MysteryWord [i].Equals (' ')) {
					temp += " ";
				} else {
					temp += "_";
				}
			}
			GuessedWord = temp;
		}


		/// <summary>
		/// Returns the number of times "guess" appears in the mystery word.
		/// </summary>
		public static int GetOccurances(string guess) {
			int num = 0;
			foreach (char c in MysteryWord) {
				if (c.Equals (guess.ToLower() [0]) || c.Equals (guess.ToUpper() [0]))
					num++;
			}
			return num;
		}

		/// <summary>
		/// Guesses the letter.
		/// </summary>
		public static void GuessLetter(string guess) {
			if (char.IsLetter(guess[0])) {

				//The letter exists in the mystery word
				if (MysteryWord.IndexOf (guess.ToLower() [0]) > -1 || MysteryWord.IndexOf (guess.ToUpper() [0]) > -1) {
					//Print correct message
					Console.WriteLine ();
					Console.WriteLine ("Correct!");
					Console.WriteLine ();

					//Change the guessed word
					ChangeGuessed (guess);

					//Print out the hangman so far
					HangMan();

					//Show the guessed word
					ShowGuessed ();

					//Add to the number of right letters
					right += GetOccurances (guess);

					//Let the user guess again.
					if (right < maxRight) {
						GuessAgain ();
					} else {
						Console.WriteLine ();
						Console.WriteLine("Congratulations! You guessed the word!");
						Console.WriteLine ();
					}



				//The letter does not appear in the mystery word
				} else if (MysteryWord.IndexOf (guess.ToLower() [0]) <= -1 && MysteryWord.IndexOf (guess.ToUpper() [0]) <= -1) {

					//Print incorrect message
					Console.WriteLine ();
					Console.WriteLine ("Incorrect!");
					Console.WriteLine ();

					//Add to the number of wrong answers
					wrong++;

					//Print out the hangman so far
					HangMan();

					//Print out what has been guessed so far
					ShowGuessed();

					//Let the user guess again.
					if (wrong < maxWrong) {
						GuessAgain ();
					} else {
						Console.WriteLine ();
						Console.WriteLine("Sorry, you ran out of tries. The word was " + MysteryWord);
						Console.WriteLine ();
					}
				}



			} else {
				Console.WriteLine ();
				Console.WriteLine ("You can only guess letters.");
				Console.WriteLine ();
				ShowGuessed ();
				GuessAgain ();

			} //End of "if letter."
		}




		public static void HangMan() {
			if (wrong == 1) {
				Console.WriteLine (" (o o) ");
			} else if (wrong == 2) {
				Console.WriteLine (" (o o) ");
				Console.WriteLine ("   |   ");
			} else if (wrong == 3) {
				Console.WriteLine (" (o o) ");
				Console.WriteLine ("  -|   ");
			} else if (wrong == 4) {
				Console.WriteLine (" (o o) ");
				Console.WriteLine (" --|   ");
			} else if (wrong == 5) {
				Console.WriteLine (" (o o) ");
				Console.WriteLine (" --|-  ");
			} else if (wrong == 6) {
				Console.WriteLine (" (o o) ");
				Console.WriteLine (" --|-- ");
			} else if (wrong == 7) {
				Console.WriteLine (" (o o) ");
				Console.WriteLine (" --|-- ");
				Console.WriteLine ("  |    ");
			} else if (wrong == 8) {
				Console.WriteLine (" (o o) ");
				Console.WriteLine (" --|-- ");
				Console.WriteLine ("  |    ");
				Console.WriteLine ("  |    ");
			} else if (wrong == 9) {
				Console.WriteLine (" (o o) ");
				Console.WriteLine (" --|-- ");
				Console.WriteLine ("  | |  ");
				Console.WriteLine ("  |    ");
			} else if (wrong == 10) {
				Console.WriteLine (" (o o) ");
				Console.WriteLine (" --|-- ");
				Console.WriteLine ("  | |  ");
				Console.WriteLine ("  | |  ");
			}
		}








	} //End of class

} //End of namespace