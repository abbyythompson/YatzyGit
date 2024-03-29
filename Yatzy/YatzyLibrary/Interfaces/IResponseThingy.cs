using System;

namespace YatzyLibrary.Interfaces
{
    public interface IResponseThingy
    {
        string GetPlayerName();

        Boolean RollAgainQuestion();

        int[] WhatDiceToRollAgain();

        string ChooseCategory();

        void PrintWelcome();

        void PrintDice(int[] dice);

        void PrintScore(Player player);
        void RollsToGo(int rolls);
    }
}