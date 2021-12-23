using System;
using System.Collections.Generic;
using System.Linq;
using TexasHoldEm;

//very ugly
public class Cardset
{
    //z setu allCards tworzymy zbiory dla specifiedCards
    private List<Card> allCards = new List<Card>();
    private List<byte?> numberOfCards = new List<byte?>();

    byte? threeWhichKind = null;
    byte threeLevel3 = 0;
    byte threeLevel4 = 0;

    //section Pairs
    private byte? firstPairNumber = null;
    private byte? secondPairNumber = null;
    private byte? thirdPairNumber = null;

    private byte? onePairLevel1 = 0;//if there is a pair
    private byte? onePairLevel2 = 0;//the strongest pair str
    private byte? onePairLevel3 = 0;//1st strongest card
    private byte? onePairLevel4 = 0;//2nd strongest card
    private byte? onePairLevel5 = 0;//3rd strongest card

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

    
    




    //zostanie najsilniejsza trojka
    //4 level of strength 1)level ThreeOfKind 2) Level WhichKind 3)Level 1st HighestCard 4)Level 2nd HighestCard
    //BE careful ACES
    private bool CheckIfThree()
    {//1level
        byte kindOfThree = CheckThreeKind();
        if (kindOfThree > 0)
        {
            threeWhichKind = kindOfThree;
            CheckThreeLastCards(threeWhichKind);
            return true;
        }
        return false;
    }

    //Level 3,4
    private void CheckThreeLastCards(byte? cardKind)
    {
        threeLevel3 = 0;
        threeLevel4 = 0;
        var lastCard = (from card in allCards
                        where (card.Number != cardKind)
                        orderby (card.Number) descending
                        select card).Take(2);
        var tempArray = lastCard.ToArray<Card>();
        threeLevel3 = tempArray[0].Number;
        threeLevel4 = tempArray[1].Number;
    }

    //2level
    private byte CheckThreeKind()
    {
        byte thereIsThree = 0;
        for (byte i = 2; i < numberOfCards.Count; i++)
        {
            if (numberOfCards[i] == 3)
            {
                threeWhichKind = i;
            }
        }
        return thereIsThree;
    }


    //analiza w dol potrzebna i potem dopisujemy pokery i wymagane property
    //i funkcje porownan

    //zapamietaj 3 najmocniejsze 2ki, w puli 7 kart moze byc max 3 2ki


    private void CheckTwoPairStrength()
    {
        throw new NotImplementedException();
    }
    //1)level: 2pairs 2)level: higherPairStr 3)level: lowerPairStr 4)Level: 1st strongest card
    //1)level: pair 2)level: 9 3)level: 1st strongest card 4)level 2nd strongest card 5)level: 3rd strongest card
    private void CheckOnePairStrength()
    {
        throw new NotImplementedException();
    }

    private void CheckOnePairLevel3_5(byte? cardKind)
    {
        onePairLevel3 = 0;
        onePairLevel4 = 0;
        onePairLevel5 = 0;
        var lastCard = (from card in allCards
                        where (card.Number != cardKind)
                        orderby (card.Number) descending
                        select card).Take(3);
        var tempArray = lastCard.ToArray<Card>();
        onePairLevel3 = tempArray[0].Number;
        onePairLevel4 = tempArray[1].Number;
        onePairLevel5 = tempArray[2].Number;
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

    // Level 1
    private bool CheckIfPair()
    {
        switch (CheckPairNumber())
        {
            case 0:
                return false;
            case 1:
                //only one pair Level2
                onePairLevel2 = firstPairNumber;
                //Level 3_5
                CheckOnePairLevel3_5(onePairLevel1);
                return true;
            case 2:
                //taken as 1 pair to complete full house, we dont need more levels, but im not sure
                onePairLevel2 = secondPairNumber;
                //taken as 2 pairs
                twoPairLevel2 = secondPairNumber;
                twoPairLevel3 = firstPairNumber;
                CheckTwoPairLevel4(twoPairLevel2, twoPairLevel3);
                return true;
            case 3:
                //taken as 1 pair to complete full house, we dont need more levels, but im not sure
                onePairLevel2 = secondPairNumber;
                //taken as 2 stronger pairs
                twoPairLevel2 = thirdPairNumber;
                twoPairLevel3 = secondPairNumber;
                CheckTwoPairLevel4(twoPairLevel2, twoPairLevel3);
                return true;
            default:
                throw new ArgumentException("Invalid pair number");
        }
    }
    private byte CheckPairNumber()
    {
        byte numberOfPairs = 0;
        for (int i = 2; i < numberOfCards.Count; i++)
        {
            if (numberOfCards[i] == 2)
            {
                switch (numberOfPairs)
                {
                    case 0:
                        firstPairNumber = (byte?)(i);
                        numberOfPairs++;
                        break;
                    case 1:
                        secondPairNumber = (byte?)(i);
                        numberOfPairs++;
                        break;
                    case 2:
                        thirdPairNumber = (byte?)(i);
                        numberOfPairs++;
                        break;
                }
            }
        }
        return numberOfPairs;
    }

    



}

