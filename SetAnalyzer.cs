using System;
using System.Collections.Generic;
using TexasHoldEm;

public abstract class SetAnalyzer
{
    private List<Card> allCards = new List<Card>();
    private List<Byte> cardSetLevels = new List<Byte>();
    private List<Byte> numberOfCards = new List<Byte>();

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

    public abstract bool CheckIfFits();
    public abstract void calculateCardSetLevel();

}