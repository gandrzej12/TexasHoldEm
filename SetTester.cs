using System;
using System.Collections.Generic;
using TexasHoldEm;
using static TexasHoldEm.CardSymbol;
using System.IO;

public class SetTester
{
    
    protected List<Card> testCards = new List<Card>();
    protected byte[] levels= new byte[5];

    //!deprecated! Use readCSV instead
    protected void setCards(){
        testCards.Clear();
        testCards.Add(new Card(HEART,3));
        testCards.Add(new Card(HEART,4));
        testCards.Add(new Card(HEART,5));
        testCards.Add(new Card(HEART,6));
        testCards.Add(new Card(HEART,7));        
    }

    public void readCSV(){
        var lines= File.ReadAllLines("testData.csv");
        foreach(var line in lines){
            testCards.Clear();
            var values=line.Split(',');
            for(var i=0; i<7;i++){
                CardSymbol symbix;
                switch(values[i*2].ToLower()){
                    case "heart":
                        symbix=HEART;
                        break;
                    case "diamond":
                        symbix=DIAMOND;
                        break;
                    case "club":
                        symbix=CLUB;
                        break;
                    case "spade":
                        symbix=SPADE;
                        break;
                    default:
                        throw new ArgumentException("symbix not initialized, check csv file");
                }
                byte number=Convert.ToByte(values[(i*2)+1]);
                testCards.Add(new Card(symbix, number));              
            }

            for(var i=0;i<7;i++){
                levels[i]=Convert.ToByte(values[i+10]);
            }

            //testHere TODO
        }
    }

}