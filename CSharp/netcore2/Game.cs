using System;
using System.Collections.Generic;
using System.Linq;
using trivia.Question;

namespace Trivia
{
    public class Game
    {
        List<string> players = new List<string>();

        int[] places = new int[6];
        int[] purses = new int[6];

        bool[] inPenaltyBox = new bool[6];

        Question popQuestions = new PopQuestion();
        Question scienceQuestions = new ScienceQuestion();
        Question sportsQuestions = new SportsQuestion();
        Question rockQuestions = new RockQuestion();

        int currentPlayer = 0;
        bool isGettingOutOfPenaltyBox;

        public Game()
        {
            for (int i = 0; i < 50; i++)
            {
                popQuestions.AddLastQuestion(i);
                scienceQuestions.AddLastQuestion(i);
                sportsQuestions.AddLastQuestion(i);
                rockQuestions.AddLastQuestion(i);
            }
        }

        public String CreateRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public bool IsPlayable()
        {
            return (HowManyPlayers() >= 2);
        }

        public bool Add(String playerName)
        {
            players.Add(playerName);
            places[HowManyPlayers()] = 0;
            purses[HowManyPlayers()] = 0;
            inPenaltyBox[HowManyPlayers()] = false;

            Console.WriteLine(playerName + " was Added");
            Console.WriteLine("They are player number " + players.Count);
            return true;
        }

        public int HowManyPlayers()
        {
            return players.Count;
        }

        public void Roll(int roll)
        {
            Console.WriteLine(players[currentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (!inPenaltyBox[currentPlayer])
            {
                UpdateCurrentPlayerPlaces(roll);
                RenderPlayersNewLocationAndCategory();
                return;
            }
            isGettingOutOfPenaltyBox = roll % 2 != 0;
            Console.WriteLine(players[currentPlayer] + " is getting out of the penalty box");
            if (isGettingOutOfPenaltyBox)
            {
                UpdateCurrentPlayerPlaces(roll);
                RenderPlayersNewLocationAndCategory();
            }
        }

        private void UpdateCurrentPlayerPlaces(int roll)
        {
            places[currentPlayer] = places[currentPlayer] + roll;
            if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;
        }

        private void RenderPlayersNewLocationAndCategory()
        {
            Console.WriteLine(players[currentPlayer]
                              + "'s new location is "
                              + places[currentPlayer]);
            Console.WriteLine("The category is " + CurrentCategory());
            AskQuestion();
        }

        private void AskQuestion()
        {
            if (CurrentCategory() == "Pop")
            {
                Console.WriteLine(popQuestions.First());
                popQuestions.RemoveFirstQuestion();
            }

            if (CurrentCategory() == "Science")
            {
                Console.WriteLine(scienceQuestions.First());
                scienceQuestions.RemoveFirstQuestion();
            }

            if (CurrentCategory() == "Sports")
            {
                Console.WriteLine(sportsQuestions.First());
                sportsQuestions.RemoveFirstQuestion();
            }

            if (CurrentCategory() == "Rock")
            {
                Console.WriteLine(rockQuestions.First());
                rockQuestions.RemoveFirstQuestion();
            }
        }


        private String CurrentCategory()
        {
            if (places[currentPlayer] == 0) return "Pop";
            if (places[currentPlayer] == 4) return "Pop";
            if (places[currentPlayer] == 8) return "Pop";
            if (places[currentPlayer] == 1) return "Science";
            if (places[currentPlayer] == 5) return "Science";
            if (places[currentPlayer] == 9) return "Science";
            if (places[currentPlayer] == 2) return "Sports";
            if (places[currentPlayer] == 6) return "Sports";
            if (places[currentPlayer] == 10) return "Sports";
            return "Rock";
        }

        public bool WasCorrectlyAnswered()
        {
            if (!inPenaltyBox[currentPlayer])
            {
                Console.WriteLine("Answer was corrent!!!!");
                purses[currentPlayer]++;
                Console.WriteLine(players[currentPlayer]
                                  + " now has "
                                  + purses[currentPlayer]
                                  + " Gold Coins.");

                bool winner = DidPlayerWin();
                currentPlayer++;
                if (currentPlayer == players.Count) currentPlayer = 0;

                return winner;

            }
            if (isGettingOutOfPenaltyBox)
            {
                Console.WriteLine("Answer was correct!!!!");
                currentPlayer++;
                if (currentPlayer == players.Count) currentPlayer = 0;
                purses[currentPlayer]++;
                Console.WriteLine(players[currentPlayer]
                                  + " now has "
                                  + purses[currentPlayer]
                                  + " Gold Coins.");
                bool winner = DidPlayerWin();
                return winner;
            }
            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;
            return true;
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(players[currentPlayer] + " was sent to the penalty box");
            inPenaltyBox[currentPlayer] = true;

            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;
            return true;
        }


        private bool DidPlayerWin()
        {
            return !(purses[currentPlayer] == 6);
        }
    }
}