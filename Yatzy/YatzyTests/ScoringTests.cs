using Xunit;
using YatzyLibrary;

namespace YatzyTests
{
    public class ScoringTests
    {
        [Theory]
        [InlineData(new[] {2, 2, 2, 2, 2}, 10)]
        [InlineData(new[] {1, 1, 3, 3, 6}, 14)]
        [InlineData(new[] {4, 5, 5, 6, 1}, 21)]
        [InlineData(new[] {5, 1, 5, 7, 1}, 19)]
        public void Return_score_for_chance(int[] dice, int expected)
        {
            CategoryLogic categoryLogic = new CategoryLogic();

            Assert.Equal(expected, categoryLogic.Chance(dice));
        }


        [Theory]
        [InlineData(new[] {2, 2, 2, 2, 2}, 50)]
        [InlineData(new[] {1, 1, 3, 3, 6}, 0)]
        [InlineData(new[] {4, 5, 5, 6, 1}, 0)]
        [InlineData(new[] {1, 1, 1, 1, 1}, 50)]
        [InlineData(new[] {5, 5, 5, 5, 5}, 50)]
        public void Return_score_for_Yatzy(int[] dice, int expected)
        {
            CategoryLogic categoryLogic = new CategoryLogic();

            Assert.Equal(expected, categoryLogic.Yatzy(dice));
        }

        [Theory]
        [InlineData(new[] {2, 2, 2, 2, 2}, 1, 0)]
        [InlineData(new[] {1, 1, 3, 3, 6}, 1, 2)]
        [InlineData(new[] {4, 5, 5, 6, 1}, 1, 1)]
        [InlineData(new[] {1, 1, 1, 1, 1}, 1, 5)]
        [InlineData(new[] {5, 5, 5, 5, 5}, 1, 0)]
        [InlineData(new[] {2, 2, 2, 2, 2}, 2, 10)]
        [InlineData(new[] {1, 1, 3, 3, 6}, 3, 6)]
        [InlineData(new[] {4, 5, 5, 6, 1}, 5, 10)]
        [InlineData(new[] {1, 1, 1, 3, 1}, 1, 4)]
        [InlineData(new[] {5, 5, 5, 3, 5}, 1, 0)]
        public void Return_score_for_Ones(int[] dice, int num, int expected)
        {
            CategoryLogic categoryLogic = new CategoryLogic();

            Assert.Equal(expected, categoryLogic.SumNumber(dice, num));
        }

        [Theory]
        [InlineData(new[] {3, 3, 3, 4, 4}, 8)]
        [InlineData(new[] {1, 1, 6, 2, 6}, 12)]
        [InlineData(new[] {3, 3, 3, 4, 1}, 6)]
        [InlineData(new[] {3, 3, 3, 3, 1}, 6)]
        public void Return_score_for_Pair(int[] dice, int expected)
        {
            CategoryLogic categoryLogic = new CategoryLogic();

            Assert.Equal(expected, categoryLogic.NumberOfAKind(dice, 2));
        }

        [Theory]
        [InlineData(new[] {1, 1, 2, 3, 3}, 8)]
        [InlineData(new[] {1, 1, 2, 3, 4}, 0)]
        [InlineData(new[] {1, 1, 2, 2, 2}, 6)]
        public void Return_score_for_Two_Pair(int[] dice, int expected)
        {
            CategoryLogic categoryLogic = new CategoryLogic();

            Assert.Equal(expected, categoryLogic.TwoPair(dice));
        }

        [Theory]
        [InlineData(new[] {1, 1, 3, 3, 3}, 9)]
        [InlineData(new[] {1, 1, 2, 3, 4}, 0)]
        [InlineData(new[] {1, 1, 2, 2, 2}, 6)]
        [InlineData(new[] {1, 2, 2, 2, 2}, 6)]
        public void Return_score_for_3ofAKind(int[] dice, int expected)
        {
            CategoryLogic categoryLogic = new CategoryLogic();

            Assert.Equal(expected, categoryLogic.NumberOfAKind(dice, 3));
        }

        [Theory]
        [InlineData(new[] {2, 2, 2, 2, 5}, 8)]
        [InlineData(new[] {6, 6, 6, 6, 6}, 24)]
        [InlineData(new[] {3, 3, 4, 5, 6}, 0)]
        [InlineData(new[] {3, 3, 3, 3, 1}, 12)]
        public void Return_score_for_4ofAKind(int[] dice, int expected)
        {
            CategoryLogic categoryLogic = new CategoryLogic();

            Assert.Equal(expected, categoryLogic.NumberOfAKind(dice, 4));
        }

        [Theory]
        [InlineData(new[] {1, 2, 3, 4, 5}, 15)]
        [InlineData(new[] {3, 3, 3, 3, 1}, 0)]
        [InlineData(new[] {5, 6, 2, 4, 3}, 20)]
        public void return_score_for_straight(int[] dice, int expected)
        {
            CategoryLogic categoryLogic = new CategoryLogic();

            Assert.Equal(expected, categoryLogic.Straight(dice));
        }

        [Theory]
        [InlineData(new[] {1, 1, 2, 2, 2}, 8)]
        [InlineData(new[] {3, 3, 2, 2, 1}, 0)]
        [InlineData(new[] {4, 4, 4, 4, 4}, 0)]
        [InlineData(new[] {5, 5, 4, 4, 4}, 22)]
        public void return_score_for_Full_House(int[] dice, int expected)
        {
            CategoryLogic categoryLogic = new CategoryLogic();

            Assert.Equal(expected, categoryLogic.FullHouse(dice));
        }
        
        [Theory]
        [InlineData("pair", new[]{1,1,1,1,1}, 2)] 
        [InlineData("pair", new[]{1,2,3,4,5}, 0)] 
        [InlineData("two pair", new[]{1,1,1,1,1}, 4)] 
        [InlineData("two pair", new[]{1,2,3,4,5}, 0)] 
        
        [InlineData("ones", new[]{1,1,1,1,1}, 5)] 
        [InlineData("ones", new[]{1,1,1,1,3}, 4)] 
        [InlineData("twos", new[]{3,3,3,3,3}, 0)] 
        [InlineData("twos", new[]{3,3,3,3,2}, 2)] 
        [InlineData("threes", new[]{3,3,2,3,4}, 9)] 
        [InlineData("fours", new[]{4,4,4,4,4}, 20)] 
        [InlineData("fives", new[]{5,5,5,5,5}, 25)] 
        [InlineData("sixes", new[]{1,1,1,1,6}, 6)]  
        
        [InlineData("chance", new[]{1,1,1,1,1}, 5)] 
        [InlineData("yatzy", new[]{1,1,1,1,1}, 50)] 
        [InlineData("yatzy", new[]{1,1,0,1,1}, 0)] 
        
        [InlineData("three of a kind", new[]{1,1,1,1,1}, 3)] 
        [InlineData("four of a kind", new[]{1,1,1,1,1}, 4)] 
        [InlineData("small straight", new[]{1,2,3,4,5}, 15)] 
        [InlineData("large straight", new[]{2,3,4,5,6}, 20)] 
        [InlineData("full house", new[]{1,1,2,2,2}, 8)] 
        [InlineData("full ", new[]{1,1,2,2,2}, 0)] 
        public void check_scoring_stuff(string input, int[] hand, int expected)
        {
            // Arrange
            CategoryLogic categoryLogic = new CategoryLogic();
            Scoring scoring = new Scoring(categoryLogic);
            
            // Act
            int score = scoring.CreateScore(input, hand);

            // Assert
            Assert.Equal(expected, score);
        }
    }
}