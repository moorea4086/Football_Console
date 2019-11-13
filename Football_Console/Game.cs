using System;
using Football_cs.Model;
using System.IO;
using Dapper;
using System.Linq;
using System.Reflection;

namespace Football_cs
{
    public class GameInit
    {
        private int quarter;
        private int down;
        private int gameclock;
        private int playclock;
        private Boolean openingkickoff_init;

        public int Quarter { get => quarter; set => quarter = value; }
        public int Down { get => down; set => down = value; }
        public int GameClock { get => gameclock; set => gameclock = value; }
        public int PlayClock { get => playclock; set => playclock = value; }
        public bool OpeningKickoff_init { get => openingkickoff_init; set => openingkickoff_init = value; }

        public GameInit(Team HomeTeam, Team AwayTeam)
        {
            Quarter = 1;
            Down = 0;               // down 0 to represent kickoff, possession belonging to receiving team
            GameClock = 60 * 15;    // seconds
            PlayClock = 40;         // seconds
            OpeningKickoff_init = true;
        }

        public void CoinFlip(Team HomeTeam, Team AwayTeam)      // also implemented in overtime situations
        {
            Random rand = new Random();
            string[] coin_sides = { "Heads", "Tails" };
            string[] possession_options = { "Kick", "Receive", "Defer" }; 

            var choice_index = rand.Next(coin_sides.Count());
            var flip_index = rand.Next(coin_sides.Count());

            var visitor_coin_flip = coin_sides[choice_index]; 
            var flip_result = coin_sides[flip_index];

            var possession_index = rand.Next(possession_options.Count());
            var winner_choice = possession_options[possession_index];

            Console.Write("Visitor chooses {0}. ", visitor_coin_flip);
            Console.Write("The coin lands on {0}. ", flip_result);

            if (visitor_coin_flip == flip_result)
            {
                Console.WriteLine("Visitor chooses to {0}.", winner_choice);
                if (winner_choice == "Receive")
                {
                    AwayTeam.FirstHalfPossession = true;
                    AwayTeam.SecondHalfPossession = false;
                    HomeTeam.FirstHalfPossession = false;
                    HomeTeam.SecondHalfPossession = true;
                }
                else if (winner_choice == "Kick" || winner_choice == "Defer")
                {
                    AwayTeam.FirstHalfPossession = false;
                    AwayTeam.SecondHalfPossession = true;
                    HomeTeam.FirstHalfPossession = true;
                    HomeTeam.SecondHalfPossession = false;
                }
            }
            else
            {
                Console.WriteLine("Home team chooses to {0}.", winner_choice);
                if (winner_choice == "Receive")
                {
                    AwayTeam.FirstHalfPossession = false;
                    AwayTeam.SecondHalfPossession = true;
                    HomeTeam.FirstHalfPossession = true;
                    HomeTeam.SecondHalfPossession = false;
                }
                else if (winner_choice == "Kick" || winner_choice == "Defer")
                {
                    AwayTeam.FirstHalfPossession = true;
                    AwayTeam.SecondHalfPossession = false;
                    HomeTeam.FirstHalfPossession = false;
                    HomeTeam.SecondHalfPossession = true;
                    
                }
            }
        }


        static void Main(string[] args)
        {
            Team HomeTeam = new HomeTeam("Steelers");
            Team AwayTeam = new AwayTeam("Ravens");

            // GameInit adds Rosters to Team objects
            var game = new GameInit(HomeTeam, AwayTeam);

            // initialize statistics database
            PlayerStats.playerstats();

            // todo: create game flow class
            game.CoinFlip(HomeTeam, AwayTeam);

            // test
            Test.Initialization(game, HomeTeam, AwayTeam);
            Test.Roster(HomeTeam, AwayTeam);
            Test.ListAccess(HomeTeam, AwayTeam);
            Test.CoinFlip(game, HomeTeam, AwayTeam);
            //Initialize
            Test.OpeningKickoffTest(game, HomeTeam, AwayTeam);
            game.Quarter = 3;
            Test.OpeningKickoffTest(game, HomeTeam, AwayTeam);
            
        }
    }
}
