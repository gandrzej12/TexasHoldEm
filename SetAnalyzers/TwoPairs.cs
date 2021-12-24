using System.Collections.Generic;
using System.Linq;
using TexasHoldEm;

public partial class SetAnalyzer{
    // 1level if there is at least two pairs, 2level strength of stronger pair, 3level strength of weaker pair, 4level strength of last card
    public void calculateTwoPairs(){
        ClearLevels();
        byte howManyPairs=0;
        for (byte i = 2; i < 15; i++)
        {
            if (howManyCardsOfValue[i] == 2)
            {
                howManyPairs+=1;
                switch(howManyPairs){
                    case 1:
                        cardSetLevels[0]=0;
                        cardSetLevels[1]=i;
                        break;
                    case 2:
                        cardSetLevels[0]=(byte) KindOfSet.TwoPairs;
                        cardSetLevels[2]=cardSetLevels[1];
                        cardSetLevels[1]=i;
                        break;
                    case 3:
                        cardSetLevels[0]=(byte) KindOfSet.TwoPairs;//logicly not needed if there is 3 pairs, 2 pairs are needed before
                        cardSetLevels[2]=cardSetLevels[1];
                        cardSetLevels[1]=i;
                        break;
                }
                if(howManyPairs>=2){
                    var lastCard = (from card in allCards
                        where (card.Number !=cardSetLevels[1]  && card.Number !=cardSetLevels[2])
                        orderby (card.Number) descending
                        select card).Take(1);
                    var tempArray = lastCard.ToArray<Card>();
                    cardSetLevels[3]=tempArray[0].Number;
                }
            }
        }
    }
}