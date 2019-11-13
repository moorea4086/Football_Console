using System;
using System.Collections.Generic;
using System.Text;
using Football_cs.Model;

// relating the play outcome to Playbook style statement
namespace Football_cs
{
    interface IPlay
    {
        string PlayType();
        int PlayClock();
        int PlayTime();
        int YardsGainedOrLost();
        Player OffenseP1(); // Center or long snapper, or placekicker
        Player OffenseP2(); // Quarterback (usually) 
        Player OffenseP3(); // Runningback, WR
        Player OffenseP4(); // A second receiver or running back or quarterback on a flea flicker or reverse, fumble recovery 
        Player DefenseP1(); // Tackler, sacker, fumble recoverer or kick returner
        Player DefenseP2(); // Co-Tackler, sacker, fumble recoverer or kick returner
    }
}
