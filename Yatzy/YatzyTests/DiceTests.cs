using System.Collections.Generic;
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
            var list = dice.GetDice();

            foreach (var die in list)
            {
                Assert.True(die.Value > 0 && die.Value < 7);
            }
        }

        [Fact]
        public void Check_dice_list_is_always_length_5()
        {
            var dice = new Dice();
            var list = dice.GetDice();

            Assert.Equal(5, list.Count);
        }
        
        [Fact]
        public void Check_die_roll_works()
        {
            var die = new Die();
            die.Roll();

            Assert.True(die.Value > 0 && die.Value < 7);
        }
        
        [Fact]
        public void Check_dice_roll_works()
        {
            var dice = new Dice();
            dice.Roll();
            var list = dice.GetDice();

            foreach (var die in list)
            {
                Assert.True(die.Value > 0 && die.Value < 7);
            }
        }
    }
}