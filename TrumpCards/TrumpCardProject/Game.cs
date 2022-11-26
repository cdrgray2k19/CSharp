namespace TrumpCardProject;

public class Game
    {

        private List<Player> players = new List<Player>();
        //private List<string> fieldNames = new List<string>();
        private int numPlayers = 0;
        private Deck deck;

        public Game(int numPlayers, Deck deck)
        {
            this.deck = deck;
            this.numPlayers = numPlayers;
            for (int i = 0; i < this.numPlayers; i++)
            {
                if (i == 0)
                {
                    players.Add(new Player(this.deck));
                }
                else
                {
                    players.Add(new Computer(this.deck));
                }
                
            }

            this.deck.cards = this.deck.shuffle(this.deck.cards, 1);
            for (int i = 0; i < this.deck.getDeckLength(); i++)
            {
                players[i % players.Count].pickUp(this.deck.getCard(i));
            }

        }

        private void playRound(int field)
        {
            int max = -1;
            int winningPlayer = -1;
            List<Card> placed = new List<Card>();

            for (int i = 0; i < players.Count; i++)
            {
                if (!players[i].getPlaying())
                {
                    continue;
                }

                Card cardPlaced = players[i].placeCard();
                int val = cardPlaced.GetFieldVal(field);
                placed.Add(cardPlaced);
                
                Console.WriteLine($"player {i + 1} has value {val} for this attribute on their top card");
                if (val > max)
                {
                    max = val;
                    winningPlayer = i;
                }
            }
            //UPDATE LOGIC FOR DRAWING CARDS


            //winning player for that round picks up cards
            Console.WriteLine($"\nplayer {winningPlayer + 1} has won with a value of {max} for this attribute on their top card");
            Console.WriteLine($"All cards placed down are now picked up by player {winningPlayer + 1}\n");

            players[winningPlayer].pickUp(placed);

        }

        private void displayInfo()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (!players[i].getPlaying())
                {
                    continue;
                }

                if (players[i].numCards() == 0)
                {

                    Console.WriteLine($"player {i + 1} has 0 cards left and is now out of the game");
                    players[i].outOfGame();
                    numPlayers -= 1;
                }
                else
                {
                    Console.WriteLine($"player {i + 1} has {players[i].numCards()} cards");
                }
            }
        }

        private int newField(int playerInd)
        {
            if (playerInd % players.Count == 0)
            {
                displayInfo();
            }

            int field = players[playerInd % players.Count].chooseField();
            Console.Clear();
            Console.WriteLine($"\nplayer {playerInd % players.Count + 1} has chosen {deck.getFieldName(field)}\n");

            return field;
        }

        private bool endOfGame()
        {
            Console.WriteLine("\nEnd of game");
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].getPlaying())
                {
                    Console.WriteLine($"player {i + 1} won!");
                    break;
                }
            }

            Console.WriteLine("Press enter to play again, if not type a letter then press enter");
            string inp = Console.ReadLine();
            if (inp == "")
            {
                return true;
            }

            return false;
        }

        private void wait(string msg)
        {
            Console.WriteLine(msg);
            Console.ReadLine();
            Console.Clear();
        }

        public bool play()
        {
            int playerInd = 0;
            //enter game loop
            while (true)
            {

                if (!players[playerInd % players.Count].getPlaying())
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
                wait("Press any key to continue onto the next round");
            }
            //end of game, determine the only player who had cards left and therefore won

            return endOfGame();
        }
    }