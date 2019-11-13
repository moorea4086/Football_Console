using System;
using System.Collections.Generic;
using System.Text;
using Football_cs.Model;

namespace Football_cs
{
    public abstract class Team
    {
        private string team_name;
        private int points = 0;
        private int numberOfTimeOuts = 3;
        private IEnumerable<Player> roster;
        private Boolean firstHalfPossession;
        private Boolean secondHalfPossession;
        private Boolean possession;
        // temporary
        private string kicker;
        private string kick_returner;

        public Team(string name)
        {
            // calling the set accessor of the Id property.
            Id = name;
            Points = points;
            NumberOfTimeOuts = numberOfTimeOuts;
            Roster = roster;
        }

        public string Id
        {
            get
            {
                return team_name;
            }

            set
            {
                team_name = value;
            }
        }

        public int NumberOfTimeOuts
        {
            get
            {
                return numberOfTimeOuts;
            }
            set
            {
                numberOfTimeOuts = value;
            }
        }

        public int Points
        {
            get
            {
                return points;
            }

            set
            {
                points = value;
            }
        }

        public IEnumerable<Player> Roster
        {
            get => roster;
            set => roster = Database.Roster(Id);
        }
        
        public bool FirstHalfPossession { get => firstHalfPossession; set => firstHalfPossession = value; }
        public bool SecondHalfPossession { get => secondHalfPossession; set => secondHalfPossession = value; }
        public bool Possession { get => possession; set => possession = value; }
        public string Kicker { get => kicker; set => kicker = value; }
        public string Kick_returner { get => kick_returner; set => kick_returner = value; }
    }

    public class HomeTeam : Team
    {
        public HomeTeam(string team) : base(team) { }
    }     

    public class AwayTeam : Team
    {
        public AwayTeam(string team) : base(team) {}
    }
}
