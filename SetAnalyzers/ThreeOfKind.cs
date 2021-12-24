using System.Collections.Generic;
using System.Linq;
using TexasHoldEm;

public class ThreeOfKind : SetAnalyzer
{
    public ThreeOfKind(List<Card> someCards) : base(someCards)
    {
    }

    //ThreeOfKind needs 4Levels
    public override void calculateCardSetLevel()
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