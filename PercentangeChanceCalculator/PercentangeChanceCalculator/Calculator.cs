namespace PercentangeChanceCalculator
{
    public class Calculator
    {
        private float percentage;
        private Random random;

        private int minimumPossiblePercentageValue = 0;

        private int maximumPossiblePercentageValue = 100;
        /// <summary>
        /// Pass in percentage which you want to be used for chance calculation
        /// </summary>
        /// <param name="percentage"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Calculator(float percentage)
        {
            if (percentage < minimumPossiblePercentageValue)
            {
                throw new ArgumentOutOfRangeException(nameof(percentage), $"Percentage can't be less than {minimumPossiblePercentageValue}");
            }
            if (percentage > maximumPossiblePercentageValue)
            {
                throw new ArgumentOutOfRangeException(nameof(percentage), $"Percentage can't be more than {maximumPossiblePercentageValue}");
            }
            this.percentage = percentage;

            random = new Random();
        }

        public bool Calculate()
        {
            if (percentage == minimumPossiblePercentageValue)
            {
                return false;
            }
            else if (percentage == maximumPossiblePercentageValue)
            {
                return true;
            }

            int percentageIntPart = (int)Math.Truncate(percentage);

            var percentageSplittedByFractionSeparator = percentage.ToString().Split('.');
            int percentageFractionPartLength = percentageSplittedByFractionSeparator.Length > 1 ? percentageSplittedByFractionSeparator[1].Length : 0;

            // multiplying random value in case for handling fractiol percentage posibilities
            int randomValueMultiplier = percentageFractionPartLength + 1;

            int outerRandomRange = maximumPossiblePercentageValue * randomValueMultiplier;
            int acceptanceRandomValue = percentageIntPart * randomValueMultiplier;

            int randomValue = random.Next(0, outerRandomRange);
            return randomValue <= acceptanceRandomValue;
        }
    }
}