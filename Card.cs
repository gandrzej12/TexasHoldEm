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
            var color=new Terminal.Gui.Attribute(Color.BrightGreen, Color.Black);
            if(Symbol==CardSymbol.DIAMOND || Symbol==CardSymbol.HEART){
                color=new Terminal.Gui.Attribute(Color.Red, Color.Black);
            }
            List<string> stringList=new List<string>();
            CardSymbol s=Symbol;
            string n=Graphics;
            string vertiz="|";
            string horiz="=";
            switch(Number){
                case 2:
                    stringList.Add($"{horiz}{horiz}{horiz}{s}");
                    stringList.Add($" {s} {n}");
                    stringList.Add($"   {vertiz}");
                    stringList.Add($" {s} {vertiz}");
                    stringList.Add($"   {vertiz}");
                    break;
                case 3:
                    stringList.Add($"{horiz}{horiz}{horiz}{s}");
                    stringList.Add($" {s} {n}");
                    stringList.Add($" {s} {vertiz}");
                    stringList.Add($" {s} {vertiz}");
                    stringList.Add($"   {vertiz}");
                    break;
                case 4:
                    stringList.Add($"{horiz}{horiz}{horiz}{s}");
                    stringList.Add($"{s} {s}{n}");
                    stringList.Add($"   {vertiz}");
                    stringList.Add($"   {vertiz}");
                    stringList.Add($"{s} {s}{vertiz}");
                    break;
                case 5:
                    stringList.Add($"{horiz}{horiz}{horiz}{s}");
                    stringList.Add($"{s} {s}{n}");
                    stringList.Add($" {s} {vertiz}");
                    stringList.Add($"{s} {s}{vertiz}");
                    stringList.Add($"   {vertiz}");
                    break;
                case 6:
                    stringList.Add($"{horiz}{horiz}{horiz}{s}");
                    stringList.Add($"{s} {s}{n}");
                    stringList.Add($"{s} {s}{vertiz}");
                    stringList.Add($"{s} {s}{vertiz}");
                    stringList.Add($"   {vertiz}");
                    break;
                case 7:
                    stringList.Add($"{horiz}{horiz}{horiz}{s}");
                    stringList.Add($"{s} {s}{n}");
                    stringList.Add($"{s}{s}{s}{vertiz}");
                    stringList.Add($"{s} {s}{vertiz}");
                    stringList.Add($"   {vertiz}");
                    break;
                case 8:
                    stringList.Add($"{horiz}{horiz}{horiz}{s}");
                    stringList.Add($"{s} {s}{n}");
                    stringList.Add($"{s} {s}{vertiz}");
                    stringList.Add($"{s} {s}{vertiz}");
                    stringList.Add($"{s} {s}{vertiz}");
                    break;
                case 9:
                    stringList.Add($"{horiz}{horiz}{horiz}{s}");
                    stringList.Add($"{s} {s}{n}");
                    stringList.Add($"{s}{s}{s}{vertiz}");
                    stringList.Add($"{s}{s}{s}{vertiz}");
                    stringList.Add($" {s} {vertiz}");
                    break;
                case 10:
                    stringList.Add($"{horiz}{horiz}{horiz}{s}");
                    stringList.Add($"{s} {s}{n}");
                    stringList.Add($"{s}{s}{s}{vertiz}");
                    stringList.Add($"{s}{s}{s}{vertiz}");
                    stringList.Add($"{s} {s}{vertiz}");
                    break;
                case 11:
                    stringList.Add($"{horiz}{horiz}{horiz}{s}");
                    stringList.Add($"JJJ{n}");
                    stringList.Add($"  J{vertiz}");
                    stringList.Add($"J J{vertiz}");
                    stringList.Add($"JJJ{vertiz}");
                    break;
                case 12:
                    stringList.Add($"{horiz}{horiz}{horiz}{s}");
                    stringList.Add($"DDD{n}");
                    stringList.Add($"D D{vertiz}");
                    stringList.Add($"D D{vertiz}");
                    stringList.Add($"DDD{vertiz}");
                    break;
                case 13:
                    stringList.Add($"{horiz}{horiz}{horiz}{s}");
                    stringList.Add($"K K{n}");
                    stringList.Add($"KK {vertiz}");
                    stringList.Add($"K K{vertiz}");
                    stringList.Add($"K K{vertiz}");
                    break;
                case 14:
                    stringList.Add($"{horiz}{horiz}{horiz}{s}");
                    stringList.Add($"==={n}");
                    stringList.Add($"={s}={vertiz}");
                    stringList.Add($"==={vertiz}");
                    stringList.Add($"==={vertiz}");
                    break;
            }

            return stringList;
        }
    }


}