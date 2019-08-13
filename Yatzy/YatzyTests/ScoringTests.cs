using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Xunit;
using YatzyLibrary;

namespace YatzyTests
{
    public class DiceTests
    {
        [Fact]
        public void Get_dice_list_check_value_to_be_1()
        {
            var dice = new Dice();

            List<Die> list = dice.GetDice();

            foreach (var die in list)
            {
                Assert.Equal(1, die.Value);
            }
        }

        [Fact]
        public void Check_dice_list_is_always_length_5()
        {
            var dice = new Dice();

            List<Die> list = dice.GetDice();

            Assert.Equal(5, list.Count);
        }
    }

    public class ScoringTests
    {
        [Theory]
        [InlineData(new[] {2, 2, 2, 2, 2}, 10)]
        [InlineData(new[] {1, 1, 3, 3, 6}, 14)]
        [InlineData(new[] {4, 5, 5, 6, 1}, 21)]
        [InlineData(new[] {5, 1, 5, 7, 1}, 19)]
        public void Return_score_for_chance(int[] dice, int expected)
        {
            Score score = new Score();

            Assert.Equal(expected, score.Chance(dice));
        }


        [Theory]
        [InlineData(new[] {2, 2, 2, 2, 2}, 50)]
        [InlineData(new[] {1, 1, 3, 3, 6}, 0)]
        [InlineData(new[] {4, 5, 5, 6, 1}, 0)]
        [InlineData(new[] {1, 1, 1, 1, 1}, 50)]
        [InlineData(new[] {5, 5, 5, 5, 5}, 50)]
        public void Return_score_for_Same_Number(int[] dice, int expected)
        {
            Score score = new Score();

            Assert.Equal(expected, score.SameNumber(dice));
        }
        
        [Theory]
//        [InlineData(new[] {2, 2, 2, 2, 2}, 0)]
//        [InlineData(new[] {1, 1, 3, 3, 6}, 2)]
//        [InlineData(new[] {4, 5, 5, 6, 1}, 1)]
//        [InlineData(new[] {1, 1, 1, 1, 1}, 5)]
        [InlineData(new[] {5, 5, 5, 5, 5}, 0)]
        public void Return_score_for_Ones(int[] dice, int expected)
        {
            Score score = new Score();

            Assert.Equal(expected, score.Ones(dice));
        }
    }

    public class Score
    {
        public int Chance(int[] dice)
        {
            return dice.Sum();
        }

        public int SameNumber(int[] dice)
        {
            return (dice.All(d => d == dice[0])) ? 50 : 0;
        }

        public int Ones(int[] dice)
        {
            return 0;
        }
    }
}