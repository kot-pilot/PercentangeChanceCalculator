namespace PercentangeChanceCalculator
{
    public class PercentangeChanceCalculator
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
        public PercentangeChanceCalculator(float percentage)
        {
            if (percentage < minimumPossiblePercentageValue)
            {
                throw new ArgumentOutOfRangeException(nameof(percentage), "Percentage can't be less than 0");
            }
            if (percentage > maximumPossiblePercentageValue)
            {
                throw new ArgumentOutOfRangeException(nameof(percentage), "Percentage can't be more than 100");
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
            int percentageAfterPointSynbolsLength = percentage.ToString().Split('.').Length;

            int outerRandomRange = maximumPossiblePercentageValue * percentageAfterPointSynbolsLength;
            int acceptanceRandomValue = percentageIntPart * percentageAfterPointSynbolsLength;

            int randomValue = random.Next(0, outerRandomRange);
            return randomValue <= acceptanceRandomValue;
        }
    }
}