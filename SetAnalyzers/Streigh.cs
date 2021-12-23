using System.Collections.Generic;
using TexasHoldEm;

public class Streigh : SetAnalyzer
{
    public Streigh(List<Card> someCards) : base(someCards)
    {
    }

    //Streigh needs 2 levels
    public override void calculateCardSetLevel()
    {
        byte tempStrength = 0;
        //ACE case
        if (
            howManyCardsOfValue[14] >= 1 &&
            howManyCardsOfValue[2] >= 1 &&
            howManyCardsOfValue[3] >= 1 &&
            howManyCardsOfValue[4] >= 1 &&
            howManyCardsOfValue[5] >= 1
            )
        {
            tempStrength = 1;
        }
        for (byte i = 2; 4 + i < 15; i++)
        {
            if (
            howManyCardsOfValue[0 + i] >= 1 &&
            howManyCardsOfValue[1 + i] >= 1 &&
            howManyCardsOfValue[2 + i] >= 1 &&
            howManyCardsOfValue[3 + i] >= 1 &&
            howManyCardsOfValue[4 + i] >= 1
            )
            {
                tempStrength = i;
            }
        }
        if(tempStrength>0){
            cardSetLevels[0] = (byte)KindOfSet.Streigh;
            cardSetLevels[1] = tempStrength;
        }
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}