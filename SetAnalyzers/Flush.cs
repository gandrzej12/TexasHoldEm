using System.Collections.Generic;
using System.Linq;
using TexasHoldEm;

public partial class SetAnalyzer
{
    public void calculateFlush()
    {
        ClearLevels();
        for(byte i = 3; i <7;i++){
            if(howManyCardsInSingleColor[i] >= 5){
                cardSetLevels[0] = (byte)KindOfSet.Flush;
                //levels 2-6
                var lastCard = (from card in allCards
                        where ((byte)card.Symbol == i)
                        orderby (card.Number) descending
                        select card).Take(5);
                var tempArray = lastCard.ToArray<Card>();
                cardSetLevels[1]=tempArray[0].Number;
                cardSetLevels[2]=tempArray[1].Number;
                cardSetLevels[3]=tempArray[2].Number;
                cardSetLevels[4]=tempArray[3].Number;
                cardSetLevels[5]=tempArray[4].Number;
            }
        }
    }
}