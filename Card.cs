using System;
using System.Collections.Generic;
using Terminal.Gui;

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
        public Terminal.Gui.Attribute CardColor{get;set;}
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

        public List<string> cardToGUI(){
            var color=new Terminal.Gui.Attribute(Color.Black, Color.White);
            if(Symbol==CardSymbol.DIAMOND || Symbol==CardSymbol.HEART){
                color=new Terminal.Gui.Attribute(Color.Red, Color.White);
            }
            CardColor=color;
            List<string> stringList=new List<string>();
            string s=GraphicsSymbol;
            string n=Graphics;
            switch(Number){
                case 2:
                    stringList.Add($" {s} {n}");
                    stringList.Add($"    ");
                    stringList.Add($" {s}  ");
                    stringList.Add($"    ");
                    break;
                case 3:
                    stringList.Add($" {s} {n}");
                    stringList.Add($" {s}  ");
                    stringList.Add($" {s}  ");
                    stringList.Add($"    ");
                    break;
                case 4:
                    stringList.Add($"{s} {s}{n}");
                    stringList.Add($"    ");
                    stringList.Add($"    ");
                    stringList.Add($"{s} {s} ");
                    break;
                case 5:
                    stringList.Add($"{s} {s}{n}");
                    stringList.Add($" {s}  ");
                    stringList.Add($"{s} {s} ");
                    stringList.Add($"    ");
                    break;
                case 6:
                    stringList.Add($"{s} {s}{n}");
                    stringList.Add($"{s} {s} ");
                    stringList.Add($"{s} {s} ");
                    stringList.Add($"    ");
                    break;
                case 7:
                    stringList.Add($"{s} {s}{n}");
                    stringList.Add($"{s}{s}{s} ");
                    stringList.Add($"{s} {s} ");
                    stringList.Add($"    ");
                    break;
                case 8:
                    stringList.Add($"{s} {s}{n}");
                    stringList.Add($"{s} {s} ");
                    stringList.Add($"{s} {s} ");
                    stringList.Add($"{s} {s} ");
                    break;
                case 9:
                    stringList.Add($"{s}{s}{s}{n}");
                    stringList.Add($"{s}{s}{s} ");
                    stringList.Add($"{s}{s}{s} ");
                    stringList.Add($"    ");
                    break;
                case 10:
                    stringList.Add($"{s} {s}{n}");
                    stringList.Add($"{s}{s}{s} ");
                    stringList.Add($"{s}{s}{s} ");
                    stringList.Add($"{s} {s} ");
                    break;
                case 11:
                    stringList.Add($" J {s}");
                    stringList.Add($" J  ");
                    stringList.Add($" J  ");
                    stringList.Add($"J J ");
                    break;
                case 12:
                    stringList.Add($" Q {s}");
                    stringList.Add($" QQ ");
                    stringList.Add($" |  ");
                    stringList.Add($"//  ");
                    break;
                case 13:
                    stringList.Add($" K {s}");
                    stringList.Add($" I  ");
                    stringList.Add($" N  ");
                    stringList.Add($" G  ");
                    break;
                case 14:
                    stringList.Add($"   {s}");
                    stringList.Add($" A  ");
                    stringList.Add($"    ");
                    stringList.Add($"    ");
                    break;
            }

            return stringList;
        }
    }


}