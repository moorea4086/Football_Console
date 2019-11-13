using System;
using System.Collections.Generic;
using System.Text;

namespace Football_cs
{
    class CalculateFieldPosition
    {
        public static int calculatefieldposition(int beginPlay, double endPlay)
        {
            int football_field_position;
            int absolute_field_position = beginPlay + (int)endPlay;
            if (absolute_field_position > 100)
            {
                football_field_position = 100 - absolute_field_position;
                Console.WriteLine("The ball is {0} yards deep into the receiving team's endzone", Math.Abs(football_field_position));
            }
            else if (absolute_field_position == 100)
            {
                football_field_position = 0;
                Console.WriteLine("The ball is at the receiving team's goalline");
            }
            else
            {
                football_field_position = 100 - absolute_field_position;
                Console.WriteLine("The ball is on the receiving team {0} yard line", football_field_position);
            }
            return football_field_position;
        }
    }
}
