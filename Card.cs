using System;

namespace TexasHoldEm
{
    public enum CardSymbol
    {
        CLUB = 0,
        DIAMOND = 1,
        HEART = 2,
        SPADE = 3
    }

    public class Card
    {
        public int Number { get; }
        public string Graphics { get; }
        public CardSymbol Symbol { get; }
        public string GraphicsSymbol { get;}
        //TODO szablon karty- np. jak wyswietlac graficznie 7 znaczkow 

        public void PrintCard(){
            Console.WriteLine($"Card: {Number} = {Graphics} {GraphicsSymbol}");
        }

        public Card(CardSymbol symbol, int number)
        {
            if (number > 13 || number <= 0)
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
                case 1:
                    this.Graphics = "A";
                    break;
                case 11:
                    this.Graphics = "J";
                    break;
                case 12:
                    this.Graphics = "D";
                    break;
                case 13:
                    this.Graphics = "K";
                    break;
                default:
                    this.Graphics = number.ToString();
                    break;
            }


        }
    }


}