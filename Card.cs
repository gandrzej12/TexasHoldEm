using System;

namespace TexasHoldEm
{
    public enum CardSymbol
    {
        HEART = 3,//♥alt3
        DIAMOND = 4,//♦alt4
        CLUB = 5,//alt5♣  
        SPADE = 6//♠alt6
    }

    public class Card
    {
        public byte Number { get; }
        public string Graphics { get; }
        public CardSymbol Symbol { get; }
        public string GraphicsSymbol { get;}
        //TODO szablon karty- np. jak wyswietlac graficznie 7 znaczkow 

        public void PrintCard(){
            Console.WriteLine($"Card: {Number} = {Graphics} {GraphicsSymbol}");
        }

        public Card(CardSymbol symbol, byte number)
        {
            if (number > 14 || number <2)
            {
                throw new Exception("Wrong value during card creation");
            }
            this.Symbol = symbol;
            switch (symbol)
            {
                case CardSymbol.CLUB:
                    this.GraphicsSymbol = "♣";// alt 5
                    break;
                case CardSymbol.DIAMOND:
                    this.GraphicsSymbol = "♦";// alt 4
                    break;
                case CardSymbol.HEART:
                    this.GraphicsSymbol = "♥";// alt 3
                    break;
                case CardSymbol.SPADE:
                    this.GraphicsSymbol = "♠";// alt 6
                    break;
            }
            this.Number = number;
            switch (number)
            {          
                case 11:
                    this.Graphics = "J";
                    break;
                case 12:
                    this.Graphics = "D";
                    break;
                case 13:
                    this.Graphics = "K";
                    break;
                case 14:
                    this.Graphics = "A";
                    break;
                default:
                    this.Graphics = number.ToString();
                    break;
            }


        }
    }


}