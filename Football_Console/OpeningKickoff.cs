using System;
using System.Collections.Generic;
using System.Text;
using Football_cs.Model;

namespace Football_cs
{
    class OpeningKickoff
    {
        public static void openingkickoff(GameInit game, Team HomeTeam, Team AwayTeam)
        {
            string kicker;
            string return_man;
            string kicking_team;
            string receiving_team;

            if (game.Quarter == 1)
            {
                if (HomeTeam.FirstHalfPossession != true) kicker = HomeTeam.Kicker;
                else kicker = AwayTeam.Kicker;

                if (HomeTeam.FirstHalfPossession != true) kicking_team = HomeTeam.Id;
                else kicking_team = AwayTeam.Id;

                if (HomeTeam.FirstHalfPossession == true) return_man = HomeTeam.Kick_returner;
                else return_man = AwayTeam.Kick_returner;

                if (HomeTeam.FirstHalfPossession == true) receiving_team = HomeTeam.Id;
                else receiving_team = AwayTeam.Id;

                var kickoff = new Kickoff(kicker, return_man, kicking_team, receiving_team);
            }

            else if(game.Quarter == 3)
            {
                if (HomeTeam.SecondHalfPossession != true) kicker = HomeTeam.Kicker;
                else kicker = AwayTeam.Kicker;

                if (HomeTeam.SecondHalfPossession != true) kicking_team = HomeTeam.Id;
                else kicking_team = AwayTeam.Id;

                if (HomeTeam.SecondHalfPossession == true) return_man = HomeTeam.Kick_returner;
                else return_man = AwayTeam.Kick_returner;

                if (HomeTeam.SecondHalfPossession == true) receiving_team = HomeTeam.Id;
                else receiving_team = AwayTeam.Id;

                var kickoff = new Kickoff(kicker, return_man, kicking_team, receiving_team);
            }
        }
    }
}
