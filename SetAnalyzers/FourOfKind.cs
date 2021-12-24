using System.Collections.Generic;
using System.Linq;
using TexasHoldEm;

public class FourOfKind : SetAnalyzer
{
    public FourOfKind(List<Card> someCards) : base(someCards)
    {
    }

    public override void calculateCardSetLevel()
    {
        ClearLevels();
        // 3level representation   
        for (byte i = 2; i < howManyCardsOfValue.Count; i++)
        {
            if (howManyCardsOfValue[i] == 4)
            {
                cardSetLevels[0] = (byte)KindOfSet.FourOfKind;//FokLevel
                cardSetLevels[1] = i;
                //3rd level- last card
                var lastCard = (from card in allCards
                                where (card.Number != cardSetLevels[1])
                                orderby (card.Number) descending
                                select card).Take(1);
                var tempArray = lastCard.ToArray<Card>();
                cardSetLevels[2] = tempArray[0].Number;
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