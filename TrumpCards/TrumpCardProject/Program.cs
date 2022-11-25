using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace TrumpCardProject
{

    class Card
    {
        private List<int> fields = new List<int>(6);
        
        public Card(List<int> nums)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                fields.Add(nums[i]);
            }
        }

        public int GetFieldVal(int ind)
        {
            return fields[ind];
        }

    }

    class QueueNode
    {
        private Card data;
        private QueueNode next;

        public Card Data
        {
            get { return data; }
        }

        public QueueNode Next
        {
            get { return next; }
            set { next = value; }
        }

        public QueueNode( Card value)
        {
            this.data = value;
            this.next = null;
        }
    }

    class Queue
    {
        private QueueNode first;
        private QueueNode last;
        private int length = 0;
        public Queue()
        {
            first = null;
            last = null;
        }

        public void add(Card node)
        {
            if (first == null)
            {
                first = new QueueNode(node);
                last = first;
            }
            else
            {
                QueueNode temp = new QueueNode(node);
                last.Next = temp;
                last = temp;
            }

            length += 1;
        }

        public QueueNode remove()
        {
            if (!isEmpty())
            {
                
                QueueNode temp = first;
                first = first.Next;
                
                length -= 1;
                return temp;
            }
            else
            {
                return null;
            }
        }

        public Boolean isEmpty()
        {
            return first == null;
        }

        public QueueNode peek()
        {
            if (!isEmpty())
            {
                return first;
            }
            else
            {
                return null;
            }
        }

        public int getLength()
        {
            return length;
        }
    }

    class Game
    {
        
        private List<Queue> players = new List<Queue>();
        private List<string> fieldNames = new List<string>();
        private int numPlayers = 0;
        public Game(int numPlayers)
        {
            this.numPlayers = numPlayers;
            for (int i=0; i<this.numPlayers; i++)
            {
                players.Add(generatePlayer());
            }
            
            //create basic test attributes for each card
            
            fieldNames = new List<string>{"field 1", "field 2", "field 3", "field 4", "field 5", "field 6"};
            
        }
        private Queue generatePlayer()
        {
            Queue newPlayer = new Queue();
            Random generator = new Random();

            for (int i = 0; i < 4; i++)
            {
                List<int> values = new List<int>();
            
                
                for (int j = 0; j < 6; j++)
                {
                    values.Add(generator.Next(0, 100+1));
                }

                Card c = new Card(values);
                
                newPlayer.add(c);
            }
            
            return newPlayer;
        }

        private void displayCard(Card c)
        {
            for (int i = 0; i < fieldNames.Count; i++)
            {
                Console.WriteLine($"{fieldNames[i]}: {c.GetFieldVal(i)}");
            }
        }

        private void playRound(int field)
        {
            int max = -1;
            int winningPlayer = -1;
            List<Card> placed = new List<Card>();

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i] == null)
                {
                    continue;
                }
                int val = players[i].peek().Data.GetFieldVal(field);
                placed.Add(players[i].remove().Data);
                Console.WriteLine($"player {i+1} has value {val} for this attribute on their top card");
                if (val > max)
                {
                    max = val;
                    winningPlayer = i;
                }
            }
            //UPDATE LOGIC FOR DRAWING CARDS
                
                
            //winning player for that round picks up cards
            Console.WriteLine($"\nplayer {winningPlayer+1} has won with a value of {max} for this attribute on their top card");
            Console.WriteLine($"All cards placed down are now picked up by player {winningPlayer+1}\n");
                
            for (int i = 0; i < placed.Count; i++)
            {
                players[winningPlayer].add(placed[i]);
            }
            
        }
        
        private void displayInfo()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i] == null)
                {
                    continue;
                }
                if (players[i].isEmpty())
                {

                    Console.WriteLine($"player {i+1} has 0 cards left and is now out of the game");
                    players[i] = null;
                    numPlayers -= 1;
                }
                else
                {
                    Console.WriteLine($"player {i+1} has {players[i].getLength()} cards");
                }
            }
        }

        public int newField(int playerInd)
        {
            int field = -1;
                if (playerInd%players.Count == 0)
                {

                    for (int i = 0; i < players.Count; i++)
                    {
                        if (players[i] == null)
                        {
                            continue;
                        }

                        Console.WriteLine($"player {i + 1} has {players[i].getLength()} cards");
                    }

                    Console.WriteLine("\nHere is your card");
                    displayCard(players[0].peek().Data);
                    Console.WriteLine("\nenter field number for value to be taken from");
                    field = Convert.ToInt32(Console.ReadLine()) - 1;
                }
                else
                {
                    Random generator = new Random();
                    field = generator.Next(0, fieldNames.Count);
                    Console.WriteLine($"\nplayer {(playerInd%players.Count)+1} has chosen the {fieldNames[field]}\n");
                }

            return field;
        }

        public void play()
        {
            int playerInd = 0;
            //enter game loop
            while (true)
            {
                
                if (players[playerInd%players.Count] == null)
                {
                    playerInd += 1;
                    continue;
                }
                
                //determine field that cards should be evaluated on
                int field = newField(playerInd);
                
                //simulate placing and comparing cards
                
                playRound(field);


                //if players have ran out of cards, eliminate them from game, else announce the number of cards they have left

                displayInfo();

                if (numPlayers < 2)
                {
                    break;
                }
                //update player that gets to pick field
                playerInd += 1;
                Console.WriteLine("Press any key to continue onto the next round");
                Console.ReadLine();
                Console.Clear();
            }
            //end of game, determine the only player who had cards left and therefore won
            Console.WriteLine("\nEnd of game");
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i] != null)
                {
                    Console.WriteLine($"player {i+1} won!");
                    return;
                }
            }
            Console.WriteLine("Press any key to play again");
            Console.ReadLine();
            Console.Clear();
        }
    }
    
    class Program
    {
        
        public static void Main(string[] args)
        {
            //create players with random values on cards, to test, 6 cards each
            while (true)
            {
                Console.WriteLine("\nHow many players would you like to play with?\n>");
                int numPlayers = Convert.ToInt32(Console.ReadLine());
                if (numPlayers < 2)
                {
                    break;
                }

                Console.Clear();
                Game test = new Game(numPlayers);
                test.play();
            }
        }
        
        
        
        
        
        /*List<int> toPlayRound = new List<int>();

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i] != null)
                {
                    toPlayRound.Add(i);
                }
            }
            
            winningPlayer = placeCards(toPlayRound, 0, ref players, ref placed, ref max, ref field);*/
        
        /*
        public static int placeCards(List<int> toPlayRound, int order, ref List<Queue> players, ref List<Card> placed, ref int max, ref int field)
        {
            int winningPlayer = -1;
            List<int> drawedPlayers = new List<int>();
            for (int i = 0; i < toPlayRound.Count; i++)
            {

                if (players[toPlayRound[i]].isEmpty())
                {
                    Console.WriteLine($"player {toPlayRound[i]+1} ran out of cards");
                    continue;
                }

                int val = players[toPlayRound[i]].peek().Data.GetFieldVal(field);
                placed.Add(players[toPlayRound[i]].remove().Data);
                Console.WriteLine($"player {toPlayRound[i]+1} has value {val} for this attribute on their top card");
                if (val > max)
                {
                    drawedPlayers = new List<int>();
                    max = val;
                    winningPlayer = toPlayRound[i];
                    drawedPlayers.Add(toPlayRound[i]);
                } 
                else if (val == max)
                {
                    drawedPlayers.Add(toPlayRound[i]);
                }
            }
            List<Card> placedSaved = new List<Card>();
            List<Queue> playersSaved = new List<Queue>();
            if (order == 0)
            {
                //save placed and players in case draw occurs until players have 0 cards left
                for (int i = 0; i < placed.Count; i++)
                {
                    placedSaved.Add(placed[i]);
                }
                for (int i = 0; i < players.Count; i++)
                {
                    playersSaved.Add(players[i]);
                }

            }
            if (drawedPlayers.Count > 1)
            {
                winningPlayer = placeCards(drawedPlayers, order+1, ref players, ref placed, ref max, ref field);
            }

            if (winningPlayer == -1 && order == 0)
            {
                placed = placedSaved;
                players = playersSaved;
                field = (field + 1) % 6;
                winningPlayer = placeCards(drawedPlayers, order+1, ref players, ref placed, ref max, ref field);
            }
            
            return winningPlayer;
        }
        */
        
    }
}