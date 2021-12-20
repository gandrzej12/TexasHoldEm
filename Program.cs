using System;

namespace TexasHoldEm
{

    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Deck myDeck = new Deck();
            myDeck.PickACard().PrintCard();
            myDeck.PickACard().PrintCard();
            myDeck.PickACard().PrintCard();
            
        }
    }
}
