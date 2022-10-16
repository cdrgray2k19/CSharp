using System;
using System.Collections.Generic;
using System.Collections;

namespace TrumpCardProject
{

    class Card
    {
        private Dictionary<string, int> vals = new Dictionary<string, int>(6);
        private List<string> fields = new List<string>();
        public int this[string key]
        {
            get
            {
                return vals[key];
            }
            set
            {
                vals[key] = value;
            }
        }
        public Card(List<int> nums)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                vals.Add($"field{i+1}", nums[i]);
            }
        }
    }
    
    class Player
    {
        private List<Card> cards = new List<Card>();
        
        private int numCards;
        public int NumCards { get; set; }

        public Player
        {
            
        }
    }
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("hello");
        }
    }
}