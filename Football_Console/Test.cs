using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Football_cs.Model;

namespace Football_cs
{
    class Test
    {
        public static void Initialization(GameInit game, Team HomeTeam, Team AwayTeam)
        {
            Console.WriteLine("{0} have {1} timeouts remaining and {2} points with {3}:{4} minutes remaining in the {5} quarter",
                HomeTeam.Id, HomeTeam.NumberOfTimeOuts, HomeTeam.Points, (game.GameClock / 60), (game.GameClock % 60), game.Quarter);
            game.GameClock -= 22;
            HomeTeam.NumberOfTimeOuts -= 1;
            HomeTeam.Points = 7;
            game.Quarter += 1;
            Console.WriteLine("{0} have {1} timeouts remaining and {2} points with {3}:{4} minutes remaining in the {5} quarter",
                HomeTeam.Id, HomeTeam.NumberOfTimeOuts, HomeTeam.Points, (game.GameClock / 60), (game.GameClock % 60), game.Quarter);
            game.GameClock += 22;
            HomeTeam.NumberOfTimeOuts += 1;
            HomeTeam.Points = 0;
            game.Quarter -= 1;
        }

        public static void Roster(Team HomeTeam, Team AwayTeam)
        {
            foreach (Player line in AwayTeam.Roster)
            {
                Console.WriteLine(line.Third);
            }

            Console.WriteLine("\n");
            foreach (Player line in HomeTeam.Roster)
            {
                Console.WriteLine(line.Third);
            }
        }

        public static void ListAccess(Team HomeTeam, Team AwayTeam)
        {
            // Accessing list
            // https://stackoverflow.com/questions/1175645/find-an-item-in-list-by-linq
            Player home_captain = HomeTeam.Roster.Single(p => p.Position == "QB");
            Console.WriteLine(home_captain.Third);
            // Also finding QB
            Console.WriteLine(AwayTeam.Roster.Single(x => x.Position == "QB").Third);
            //// Also finding QB
            //var all_qb = AwayTeam.Roster.Where(x => x.Position == "RB");
            //Console.WriteLine(all_qb.Count()); // 1
            //Console.WriteLine(all_qb.ToArray()); //Football_cs.Model.Player[]
            //Console.WriteLine(all_qb.ElementAt(0));  //Football_cs.Model.Player
            //Console.WriteLine(all_qb.ElementAt(0).Starter);  //Mark Ingram II
            //Console.WriteLine(all_qb.ElementAt(0).Second); //Gus Edwards

            //foreach (Player starter in HomeTeam.Roster)
            //{
            //    Console.WriteLine("{0} {1}",starter.Position, starter.Second);
            //}

            foreach (Player position in HomeTeam.Roster)
            {
                Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4}", position.Position, position.Starter, position.Second, position.Third, position.Fourth);
            }
        }

        public static void CoinFlip(GameInit game, Team HomeTeam, Team AwayTeam)
        {
            game.CoinFlip(HomeTeam, AwayTeam);
            Console.WriteLine("HomeTeam gets the opening kickoff: {0}. ", HomeTeam.FirstHalfPossession);
            game.CoinFlip(HomeTeam, AwayTeam);
            Console.WriteLine("HomeTeam gets the opening kickoff: {0}. ", HomeTeam.FirstHalfPossession);
            game.CoinFlip(HomeTeam, AwayTeam);
            Console.WriteLine("HomeTeam gets the opening kickoff: {0}. ", HomeTeam.FirstHalfPossession);
            game.CoinFlip(HomeTeam, AwayTeam);
            Console.WriteLine("HomeTeam gets the opening kickoff: {0}. ", HomeTeam.FirstHalfPossession);
            game.CoinFlip(HomeTeam, AwayTeam);
            Console.WriteLine("HomeTeam gets the opening kickoff: {0}. ", HomeTeam.FirstHalfPossession);
        }

        //public static void OpeningKickoff(GameInit game, Team HomeTeam, Team AwayTeam)
        //{ 
        //    string kicker;
        //    string return_man;
        //    string kicking_team;
        //    string receiving_team;

        //    if (HomeTeam.FirstHalfPossession != true)
        //    {
        //        kicker = HomeTeam.Kicker;
        //        kicking_team = HomeTeam.Id;
        //    }
        //    else
        //    {
        //        kicker = AwayTeam.Kicker;
        //        kicking_team = AwayTeam.Id;
        //    }
        //    if (HomeTeam.FirstHalfPossession == true)
        //    {
        //        return_man = HomeTeam.Kick_returner;
        //        receiving_team = HomeTeam.Id;
        //    }
        //    else
        //    {
        //        return_man = AwayTeam.Kick_returner;
        //        receiving_team = AwayTeam.Id;
        //    }
        //    var kickoff = new Kickoff(kicker, return_man, kicking_team, receiving_team);
        //}

        public static void OpeningKickoffTest(GameInit game, Team HomeTeam, Team AwayTeam)
        {
            // temporary to test OpeningKickoff in Test.OpeningKickoff(game, HomeTeam, AwayTeam);
            HomeTeam.Kicker = HomeTeam.Roster.Single(x => x.Position == "PK").Starter;
            AwayTeam.Kicker = AwayTeam.Roster.Single(x => x.Position == "PK").Starter;
            HomeTeam.Kick_returner = HomeTeam.Roster.Single(x => x.Position == "KR").Starter;
            AwayTeam.Kick_returner = AwayTeam.Roster.Single(x => x.Position == "KR").Starter;
            OpeningKickoff.openingkickoff(game, HomeTeam, AwayTeam);
        }
    }
}
