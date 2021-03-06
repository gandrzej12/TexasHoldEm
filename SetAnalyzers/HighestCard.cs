using System.Collections.Generic;
using System.Linq;

using TexasHoldEm;

public partial class SetAnalyzer
{
    public void calculateHighestCard()
    {
        ClearLevels();
        cardSetLevels[0]= (byte)KindOfSet.HighestCard;
        var lastCard = (from card in allCards
                        where (card.Number != 0)//This is not needed. Probably.
                        orderby (card.Number) descending
                        select card).Take(5);
        var tempArray = lastCard.ToArray<Card>();
        cardSetLevels[1] = tempArray[0].Number;
        cardSetLevels[2] = tempArray[1].Number;
        cardSetLevels[3] = tempArray[2].Number;
        cardSetLevels[4] = tempArray[3].Number;
        cardSetLevels[5] = tempArray[4].Number;
    }
}