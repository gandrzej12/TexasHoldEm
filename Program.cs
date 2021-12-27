using System;
using System.Collections.Generic;
using Terminal.Gui;

namespace TexasHoldEm
{
    class Program
    {

        static void TestOfSolver()
        {
            Deck ndeck = new Deck();
            List<Card> lcard = new List<Card>();
            lcard.Add(ndeck.PickACard());
            lcard.Add(ndeck.PickACard());
            lcard.Add(ndeck.PickACard());
            lcard.Add(ndeck.PickACard());
            lcard.Add(ndeck.PickACard());
            //turn
            lcard.Add(ndeck.PickACard());
            //river
            lcard.Add(ndeck.PickACard());
            SetAnalyzer sanal = new SetAnalyzer(lcard);
            List<byte> levels = sanal.levelAnalyze();
            foreach (var card in lcard)
            {
                card.PrintCard();
            }
            foreach (var level in levels)
            {
                Console.WriteLine($"Level: {level}");
            }
        }

        static void TestOfGUI()
        {
            new Game().StartGame();
        }

        static void TestOfDeckAndCards()
        {
            Deck myDeck = new Deck();
            myDeck.PickACard().PrintCard();
            myDeck.PickACard().PrintCard();
            myDeck.PickACard().PrintCard();
        }

        static void TestOf_CSV_Reading(){
            new SetTester().readCSV();
        }

        static void Main(string[] args)
        {
            //TestOfSolver();
            TestOfGUI();   
        }
    }
}
