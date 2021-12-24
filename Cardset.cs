using System;
using System.Collections.Generic;
using System.Linq;
using TexasHoldEm;

//very ugly
public class Cardset
{
    //z setu allCards tworzymy zbiory dla specifiedCards
    private List<Card> allCards = new List<Card>();

    //section Pairs
    private byte? twoPairLevel1 = 0;//if there is 2 pairs
    private byte? twoPairLevel2 = 0;//stronger pair
    private byte? twoPairLevel3 = 0;//lower pair
    private byte? twoPairLevel4 = 0;//strongest card
    //end of pairs


    public Cardset(List<Card> someCards){
        InitializeNumbers();
        allCards=someCards;
        CheckCardNumber();
    }

    private void CheckTwoPairLevel4(byte? cardKindA, byte? cardKindB)
    {
        twoPairLevel4 = 0;
        var lastCard = (from card in allCards
                        where (card.Number != cardKindA && card.Number != cardKindB)
                        orderby (card.Number) descending
                        select card).Take(1);
        var tempArray = lastCard.ToArray<Card>();
        twoPairLevel4 = tempArray[0].Number;
    }


}

