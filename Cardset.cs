using System.Collections.Generic;
using TexasHoldEm;

public class Cardest
{
    //z setu allCards tworzymy zbiory dla specifiedCards
    private List<Card> allCards = new List<Card>();
    //private List<Card> specifiedCards = new List<Card>();

    private int value = 0;
    private int level = 0;
    private CardSymbol symbolIfColor;

    private List<int> numberOfCards = new List<int>();

    private void InitializeNumbers()
    {
        for (int i = 0; i < 13; i++)
        {
            numberOfCards.Add(0);
        }
    }

    private void CheckCardNumber()
    {
        for (int i = 0; i < numberOfCards.Count; i++)
        {
            foreach (var card in allCards)
            {
                if (card.Number == i + 1)
                {
                    numberOfCards[i] += 1;
                }
            }
        }
    }

    private bool CheckIfColor()
    {
        byte needClubs = 0;
        byte needDiamonds = 0;
        byte needHearts = 0;
        byte needSpades = 0;
        foreach (var card in allCards)
        {
            switch (card.Symbol)
            {
                case CardSymbol.CLUB:
                    needClubs++;
                    break;
                case CardSymbol.DIAMOND:
                    needDiamonds++;
                    break;
                case CardSymbol.HEART:
                    needHearts++;
                    break;
                case CardSymbol.SPADE:
                    needSpades++;
                    break;
            }
        }
        if(needClubs>=5){
            symbolIfColor= CardSymbol.CLUB;
            return true;
        }
        if(needDiamonds>=5){
            symbolIfColor= CardSymbol.DIAMOND;
            return true;
        }
        if(needHearts>=5){
            symbolIfColor= CardSymbol.HEART;
            return true;
        }
        if(needSpades>=5){
            symbolIfColor= CardSymbol.SPADE;
            return true;
        }
        return false;
    }


}

