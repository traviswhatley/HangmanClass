using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanClass
{
    class Program
    {
        static void Main(string[] args)
        {
            HangMan();
            
            Console.ReadKey(); //keep the console open
        }

        static void HangMan()
        {
            //bool to hold whether they
            //play or not
            bool playing = true;
            string name;
            int lives = 7; //# of chances
            //adding words to the wordBank
            List<string> wordBank = new List<string>() {"wow", "much", "list", "such", "words", "nickelback", "doge"};
            Random rng = new Random(); //random number generator
            int randomNumber = rng.Next(0, wordBank.Count); //randomly generating a word
            string wordToGuess = wordBank[randomNumber].ToUpper(); //chosing randomly generated word, forced to UPPERCASE

            //one line solution for this nonsense
            //string wordToGuess = wordBank[new Random().Next(0, wordBank.Count())];

            //need to track what letters we've guessed
            string lettersGuessed = string.Empty;

            //start our game loop
            while (playing)
            {
                //show the masked word
                Console.WriteLine(MaskedWord(wordToGuess, lettersGuessed));                
                //tell how many lives
                Console.WriteLine("You have " + lives + " lives left.");
                //ask for input
                Console.WriteLine("Enter a guess.");
                //get input
                string input = Console.ReadLine().ToUpper();

                //determine if letter is a word or character
                if (input.Length == 1)
                {
                    //guessed a letter
                    lettersGuessed += input;
                    //letter guess
                    //determine if it's correct
                    if (wordToGuess.Contains(input))
                    {
                        //correct guess
                        Console.WriteLine("Much winning. So happy. Such gaming.");
                        //determine if they guessed all the letters in the word
                        if (AllLettersGuessed(MaskedWord(wordToGuess, lettersGuessed)))
                        {
                            playing = false;
                            Console.WriteLine("Such win. Much congrats. Many lives.");
                        }
                    }

                    else
                    {
                        Console.WriteLine("Lose life. So sad. Much pain.");
                        lives--;
                    }
                }

                else
                {
                    //word guess
                    if (wordToGuess == input)
                    {
                        //you win
                        Console.WriteLine("Such win. Much congrats. Many lives.");
                        playing = false;
                    }

                    else
                    {
                        //guessed but wrong word
                        Console.WriteLine("Try again");
                        lives--;
                    }
                }
                if (lives == 0)
                {
                    playing = false;
                    Console.WriteLine("You are as bad as Chad Kroeger. Much disappointment. So sad. Very bad.");
                }
            }
        }

        static string MaskedWord(string wordToGuess, string lettersGuessed)
        {
            //return our masked word
            //ex: a _ _ l _
            string returnString = "";

            //loop over the string to examine each character
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                //get a character from wordToGuess by using
                //the index i
                char letter = wordToGuess[i];

                //check if the letter in the wordToGuess
                //has been guessed by the user
                //using ToString().ToUpper() to make sure its UPPERCASE
                if (lettersGuessed.ToUpper().Contains(char.ToUpper(letter).ToString()))
                {
                    //they've guessed the letter so print the letter
                    //not an underscore to our return string
                    returnString += letter + " ";
                }

                else
                {
                    //did NOT guess the letter, add an underscore
                    //to our return string
                    returnString += "_" + " ";
                }

            }
            //return returnString
            return returnString;
        }

        static bool AllLettersGuessed(string MaskedWord)
        {
            //one line solution
            //return !MaskedWord.Contains("_");

            //determine if the user has guessed all the
            //letters of the word
            if (MaskedWord.Contains("_"))
            {
                return false;
            }

            else
            {
                return true;
            }
        }
    }
}
