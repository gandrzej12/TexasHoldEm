using System;
using System.Collections.Generic;
using Terminal.Gui;

namespace TexasHoldEm
{
    class Program
    {
        
        static void Main(string[] args)
        {

            // myDeck.PickACard().PrintCard();
            // myDeck.PickACard().PrintCard();
            // myDeck.PickACard().PrintCard();

            // new SetTester().readCSV();
           // new Game().StartGame();
           Deck ndeck=new Deck();
           List<Card> lcard=new List<Card>();
           lcard.Add(ndeck.PickACard());
           lcard.Add(ndeck.PickACard());
           lcard.Add(ndeck.PickACard());
           lcard.Add(ndeck.PickACard());
           lcard.Add(ndeck.PickACard());
           SetAnalyzer sanal=new SetAnalyzer(lcard);
           List<byte> levels=sanal.levelAnalyze();
           foreach(var card in lcard){
               card.PrintCard();
           }
           foreach (var level in levels){
               Console.WriteLine($"Level: {level}");      
           }
                      
        }  
    }
}
