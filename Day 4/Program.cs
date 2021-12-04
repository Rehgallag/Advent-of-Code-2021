using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4
{
    // Day 4 Advent of Code
    public static class Program
    {
        static string[] data = File.ReadAllLines("E:\\Code\\Advent of Code\\Day 4\\data.txt");
        static List<int> drawNumbers = new List<int>();
        static int cardCounter = 0;
        static List<Card> cards = new List<Card>();
        static List<int> winningCard = new List<int>();
        public static void Main(string[] args)
        {
            SetupGame();
            DrawNumbers();
        }


        public static void DrawNumbers()
        {
            bool winnerFirstRound = false;
            for (int i = 0; i < drawNumbers.Count; i++)
            {
                for (int j = 0; j < cards.Count; j++)
                {
                    if (cards[j].CheckNumbers(drawNumbers[i]) && !winningCard.Contains(j))
                    {
                        Console.WriteLine($"Card: {j} Score: {(drawNumbers[i]*cards[j].GetUnmarkedNumbers())}");
                        winningCard.Add(j);
                    }
                }
            }
        }
        public static void SetupGame()
        {
            // The numbers that will be drawn
            string[] nums = data[0].Split(',');
            foreach(string n in nums)
            {
                drawNumbers.Add(int.Parse(n));
            }

            // Bingo cards
            List<int> tmpCard = new List<int>();
            for(int i=2; i < data.Length; i++)
            {
                if (data[i] == "")
                {
                    cardCounter++;
                    cards.Add(new Card(cardCounter, tmpCard));
                    tmpCard.Clear();
                }
                else
                {
                    string[] tmp = data[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    foreach(string s in tmp)
                    {
                        tmpCard.Add(int.Parse(s));
                    }
                }
                if(i == data.Length)
                {
                    cardCounter++;
                    cards.Add(new Card(cardCounter, tmpCard));
                    tmpCard.Clear();
                }
            }
            
        }
        public class Card
        {
            public int CardNumber { get; set; }
            public int[] Values { get; set; }
            public bool[,] NumsPicked;
            public int[,] CardValue;
            private int counter = 0;
            private int unmarked = 0;
            public Card(int cardNumber_, List<int> cardValue_)
            {
                CardNumber = cardNumber_;
                Values = cardValue_.ToArray();
                CardValue = new int[5, 5];
                NumsPicked = new bool[5, 5];
                int counter = 0;
                // i =x j =y
                for (int j = 0; j < 5; j++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        NumsPicked[i, j] = false;
                        CardValue[i, j] = Values[counter];
                        counter++;
                    }
                }
            }
            public int GetUnmarkedNumbers()
            {
                return unmarked;
            }

            public bool CheckNumbers(int numPicked)
            {
                bool cardWin = false;
                int row = 0;
                int col = 0;
                for(int j=0; j < 5; j++)
                {
                    for(int i=0; i < 5; i++)
                    {
                        if (CardValue[i, j] == numPicked)
                        {
                            NumsPicked[i, j] = true;
                            counter++;
                        }
                    }
                }

                //check if card has less than 5 numbers
                if (counter >= 5)
                {
                    // Check the rows
                    for (int j = 0; j < 5; j++)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (NumsPicked[i, j])
                            {
                                row++;
                            }
                        }
                        if (row == 5)
                        {
                            cardWin = true;
                        }
                        else
                        {
                            row = 0;
                        }
                    }
                    // Check Columns
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (NumsPicked[i, j])
                            {
                                col++;
                            }
                        }
                        if (col == 5)
                        {
                            cardWin = true;
                        }
                        else
                        {
                            col = 0;
                        }
                    }
                }
                    if (cardWin)
                    {
                        for(int i=0; i < 5; i++)
                        {
                            for(int j=0; j < 5; j++)
                            {
                                if (!NumsPicked[i, j])
                                {
                                    unmarked += CardValue[i, j];
                                }
                            }
                        }
                       
                    }
                return cardWin;
            }
            


        }
    }
}
