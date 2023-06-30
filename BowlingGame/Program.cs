using static System.Formats.Asn1.AsnWriter;

namespace BowlingGameNS
{
    public class BowlingGame   
    {
        private int[] rolls = new int[20];
        private int currentRoll = 0;

        public int Score
        {
            get
            {
                var score = 0;
                var rollIndex = 0;
                for (var frame = 0; frame < 10; frame++)
                {
                    if (isStrike(rollIndex))
                    {
                        score += GetStrikeScore(rollIndex);
                        rollIndex++;
                    }
                    else if (IsSpare(rollIndex))
                    {
                        score += GetSpareScore(rollIndex);
                        rollIndex += 2;
                    }
                    else
                    {
                        score += GetStandardScore(rollIndex);
                        rollIndex += 2;
                    }
                    
                }

                return score;
            }
        }

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public static void Main()
        {

        }

        private bool isStrike(int rollIndex)
        {
            return rolls[rollIndex] == 10;
        }
        private int GetStrikeScore(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }
        private int GetSpareScore(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }
        private int GetStandardScore(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1];
        }
        private bool IsSpare(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
        }
    }
}