using System.Collections.Generic;
using TexasHoldEm;

public partial class SetAnalyzer
{
    //Streigh needs 2 levels
    public void calculateStreigh()
    {
        ClearLevels();
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
}