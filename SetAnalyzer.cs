using System;
using System.Collections.Generic;
using TexasHoldEm;

public enum KindOfSet:Byte{
    HighestCard=1,
    OnePair=2,
    TwoPairs = 3,
    ThreeOfKind = 4,
    Streigh = 5,
    Flush = 6,
    FullHouse = 7,
    FourOfKind = 8,
    StreighFlush = 9
}

public abstract class SetAnalyzer
{
    protected List<Card> allCards = new List<Card>();
    protected List<Byte> cardSetLevels = new List<Byte>();
    protected List<Byte> numberOfCards = new List<Byte>();

    public SetAnalyzer(List<Card> someCards)
    {
        allCards = someCards;
        ClearLevels();
        InitializeNumbers();
    }

    protected void ClearLevels()
    {
        cardSetLevels.Clear();
        for (byte i = 0; i < 6; i++)
        {
            cardSetLevels.Add(0);
        }
    }

    private void InitializeNumbers()
    {
        numberOfCards.Clear();
        for (int i = 0; i < 15; i++)
        {
            numberOfCards.Add(0);
        }
    }

    private void CheckCardNumber()
    {
        foreach (var card in allCards)
        {
            numberOfCards[card.Number] += 1;
        }

    }

    public byte GetLevel(byte level) => cardSetLevels[level];

    public bool CheckIfFits(){
        if(cardSetLevels[0]>0){
            return true;
        }
        return false;
    }
    public abstract void calculateCardSetLevel();

}