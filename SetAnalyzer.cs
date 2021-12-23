using System;
using System.Collections.Generic;
using TexasHoldEm;

public abstract class SetAnalyzer
{
    private List<Card> allCards = new List<Card>();
    private List<Byte> cardSetLevels=new List<Byte>();

    public SetAnalyzer(List<Card> someCards)
    {
        allCards=someCards;
        ClearLevels();
    }

    protected void ClearLevels(){
        cardSetLevels.Clear();
        for (byte i = 0; i < 6; i++)
        {
            cardSetLevels.Add(0);
        }
    }

    public byte GetLevel(byte level) => cardSetLevels[level];

    public abstract bool CheckIfFits();
    public abstract void calculateCardSetLevel();

}