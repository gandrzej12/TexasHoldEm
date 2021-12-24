using System.Collections.Generic;
using System.Linq;
using TexasHoldEm;

public partial class SetAnalyzer
{
    public void calculateOnePair()
    {
        ClearLevels();
        byte howManyPairs=0;
        for (int i = 2; i < 15; i++)
        {
            if (howManyCardsOfValue[i] == 2)
            {
                howManyPairs+=1;
                cardSetLevels[1]=(byte)(i);     
                cardSetLevels[0]= (byte)KindOfSet.OnePair;
                var lastCard = (from card in allCards
                        where (card.Number != i)
                        orderby (card.Number) descending
                        select card).Take(3);
                var tempArray = lastCard.ToArray<Card>();
                cardSetLevels[2]=tempArray[0].Number;
                cardSetLevels[3]=tempArray[1].Number;
                cardSetLevels[4]=tempArray[2].Number;
            }
        }
    }
}