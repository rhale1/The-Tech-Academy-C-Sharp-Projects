using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public class TwentyOneRules
    {
        private static Dictionary<Face, int> _cardValues = new Dictionary<Face, int>() // if you know something is only going to be used in this class make it private, good for naming
        { // static because don't want to create a object. 
            [Face.Two] = 2,
            [Face.Three] = 3,
            [Face.Four] = 4,
            [Face.Five] = 5,
            [Face.Six] = 6,
            [Face.Seven] = 7,
            [Face.Eight] = 8,
            [Face.Nine] = 9,
            [Face.Ten] = 10,
            [Face.Jack] = 10,
            [Face.Queen] = 10,
            [Face.King] = 10,
            [Face.Ace] = 1
        };
        public static int[] GetAllPossibleHandValues(List<Card> Hand)
        {
            //lambada expressions are methods you can preform on lists
            int aceCount = Hand.Count(x => x.Face == Face.Ace);
            int[] result = new int[aceCount + 1];
            int value = Hand.Sum(x => _cardValues[x.Face]);
            result[0] = value;
            if (result.LongLength == 1)
            {
                return result;
            }

            for (int i = 1; i < result.Length; i++)
            {
                value += (i * 10);
                result[i] = value; 
            }

        }

        public static bool CheckForBlackJack(List<Card> Hand)
        {

        }
    }
}
