using System.Collections.Generic;
using System.Linq;
using TexasHoldEm;

public partial class SetAnalyzer
{
    //ThreeOfKind needs 4Levels
    public void calculateThreeOfKind()
    {
        ClearLevels();
        for (byte i = 2; i < 15; i++)
        {
            if (howManyCardsOfValue[i] == 3)
            {
                //1,2level
                cardSetLevels[1]= i;
                cardSetLevels[0]=(byte)KindOfSet.ThreeOfKind;
                //3,4
                var lastCard = (from card in allCards
                        where (card.Number != i)
                        orderby (card.Number) descending
                        select card).Take(2);
                var tempArray = lastCard.ToArray<Card>();
                cardSetLevels[2]= tempArray[0].Number;
                cardSetLevels[3]= tempArray[1].Number;
            }
        }
    }
}