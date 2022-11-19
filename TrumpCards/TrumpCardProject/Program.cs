using System;
using System.Collections.Generic;
using System.Collections;
using System.Net.Mail;
using Microsoft.VisualBasic;

namespace TrumpCardProject
{

    class Card
    {
        private Dictionary<int, int> fields = new Dictionary<int, int>(6);
        
        public Card(List<int> nums)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                fields.Add(i+1, nums[i]);
            }
        }

        public int GetFieldVal(int key)
        {
            return fields[key];
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
    
    class Program
    {
        public static Queue generatePlayer()
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
        public static void Main(string[] args)
        {
            List<Queue> players = new List<Queue>();
            Console.WriteLine("How many players would you like to play with?\n>");
            int numPlayers = Convert.ToInt32(Console.ReadLine());
            for (int i=0; i<numPlayers; i++)
            {
                players.Add(generatePlayer());
            }
            
            List<string> fields = new List<string>{"field 1", "field 2", "field 3", "field 4", "field 5", "field 6"};



            int playerInd = 0;
            while (true)
            {
                int field = -1;
                if (playerInd%players.Count == 0)
                {
                    Console.WriteLine("enter field for value to be taken from");
                    field = Convert.ToInt32(Console.ReadLine());
                    
                }
                else
                {
                    Random generator = new Random();
                    field = generator.Next(1, 7);
                    Console.WriteLine($"Other player has chosen this field {field}");
                }
                int max = -1;
                int winningPlayer = -1;
                List<Card> placed = new List<Card>();
                for (int i = 0; i < players.Count; i++)
                {
                    int val = players[i].peek().Data.GetFieldVal(field);
                    placed.Add(players[i].remove().Data);
                    Console.WriteLine($"player {i+1} has value {val} for this attribute on their top card");
                    if (val > max)
                    {
                        max = val;
                        winningPlayer = i;
                    }
                }
                //keep tally of who has drawn max, then keep on drawing cards from there packs until someone wins
                
                
                //announce who won
                Console.WriteLine($"player {winningPlayer+1} has won with a value of {max} for this attribute on their top card");
                Console.WriteLine($"All cards placed down are now picked up by player {winningPlayer+1}");
                
                for (int i = 0; i < placed.Count; i++)
                {
                    players[winningPlayer].add(placed[i]);
                }

                List<int> toRemove = new List<int>();

                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].isEmpty())
                    {
                        
                        toRemove.Add(i);
                    }
                    else
                    {
                        Console.WriteLine(players[i].getLength());
                    }
                }

                for (int i = 0; i < toRemove.Count; i++)
                {
                    players.RemoveAt(toRemove[i]);
                }

                if (players.Count < 2)
                {
                    break;
                }

                playerInd += 1;
            }
            Console.WriteLine("End of game");
        }
    }
}