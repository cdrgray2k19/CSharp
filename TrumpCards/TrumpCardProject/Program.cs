using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace TrumpCardProject
{

    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nHow many players would you like to play with?\n>");
            int numPlayers = Convert.ToInt32(Console.ReadLine());
            if (numPlayers < 2)
            {
                return;
            }

            bool playing = true;
            Deck deck = new Deck();
            while (playing)
            {
                Console.Clear();
                Game test = new Game(numPlayers, deck);
                playing = test.play();
            }
        }
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
        