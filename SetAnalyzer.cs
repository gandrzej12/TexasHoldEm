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

public partial class SetAnalyzer
{
    protected List<Card> allCards = new List<Card>();
    protected List<Byte> cardSetLevels = new List<Byte>();

    protected List<Byte> howManyCardsOfValue = new List<Byte>();
    protected List<Byte> howManyCardsInSingleColor=new List<Byte>();

    public SetAnalyzer(List<Card> someCards)
    {
        allCards = someCards;
        ClearLevels();
        InitializeValues();
        InitializeColors();

        CheckCardValues();
        CheckCardColors();
    }

    protected void ClearLevels()
    {
        cardSetLevels.Clear();
        for (byte i = 0; i < 6; i++)
        {
            cardSetLevels.Add(0);
        }
    }

    private void InitializeValues()
    {
        howManyCardsOfValue.Clear();
        // 0,1 shall be empty, just 4 simplicity
        for (int i = 0; i < 15; i++)
        {
            howManyCardsOfValue.Add(0);
        }
    }

    private void InitializeColors(){
        howManyCardsInSingleColor.Clear();
        //0,1,2 shall be empty, just 4 simplicity {3,4,5,6}
        for (int i = 0; i < 7; i++)
        {
            howManyCardsInSingleColor.Add(0);
        }
    }

    private void CheckCardValues()
    {
        foreach (var card in allCards)
        {
            howManyCardsOfValue[card.Number] += 1;
        }
    }

    private void CheckCardColors(){
        foreach (var card in allCards)
        {
            howManyCardsInSingleColor[(byte)card.Symbol] += 1;
        }
    }

    public byte GetLevel(byte level) => cardSetLevels[level];

    public bool CheckIfFits(){
        if(cardSetLevels[0]>0){
            return true;
        }
        return false;
    }

    public List<Byte> getAllCardSetLevels(){
        return cardSetLevels;
    }

}