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


    private CardSymbol? symbolIfColor = null;
    //private byte strengthOfColor;
    private byte? colorLevel2 = 0;
    private byte? colorLevel3 = 0;
    private byte? colorLevel4 = 0;
    private byte? colorLevel5 = 0;
    private byte? colorLevel6 = 0;

    byte strengthOfStreigh = 0;

    byte? fourWhichKind = null;
    byte? fourLastCardStrength = null;

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

    //High Card section -----------------------------------------------------------
    private byte? HighestCardLevel1 = 0;
    private byte? HighestCardLevel2 = 0;
    private byte? HighestCardLevel3 = 0;
    private byte? HighestCardLevel4 = 0;
    private byte? HighestCardLevel5 = 0;
    private byte? HighestCardLevel6 = 0;
    //End of High Card section ----------------------------------------------------

    public Cardset(List<Card> someCards){
        InitializeNumbers();
        allCards=someCards;
        CheckCardNumber();
    }

    

    

    //------------------------------------------------ABOVE IS DONE
    //test this
    //good test case: 7karo in different positions
    //Level1 thereIsColor, Level2_6 siła poszczególnych kart

    private void GetColorLevels2_6(CardSymbol? symbol)
    {
        if (symbol == null) { throw new ArgumentNullException("symbol"); }
        colorLevel2 = 0;
        colorLevel3 = 0;
        colorLevel4 = 0;
        colorLevel5 = 0;
        colorLevel6 = 0;  
        var lastCard = (from card in allCards
                        where (card.Symbol == symbol)
                        orderby (card.Number) descending
                        select card).Take(5);
        var tempArray = lastCard.ToArray<Card>();
        colorLevel2 = tempArray[0].Number;
        colorLevel3 = tempArray[1].Number;
        colorLevel4 = tempArray[2].Number;
        colorLevel5 = tempArray[3].Number;
        colorLevel6 = tempArray[4].Number;
    }

    //Kolor po polsku: ten sam znaczek
    //Powinno działać dobrze
    private bool CheckIfColor()
    {
        bool colorDetected = false;
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
        if (needClubs >= 5)
        {
            symbolIfColor = CardSymbol.CLUB;
            colorDetected = true;
        }
        if (needDiamonds >= 5)
        {
            symbolIfColor = CardSymbol.DIAMOND;
            colorDetected = true;
        }
        if (needHearts >= 5)
        {
            symbolIfColor = CardSymbol.HEART;
            colorDetected = true;
        }
        if (needSpades >= 5)
        {
            symbolIfColor = CardSymbol.SPADE;
            colorDetected = true;
        }
        if (colorDetected)
        {
            GetColorLevels2_6(symbolIfColor);
            return true;
        }
        return false;
    }

    //Strit po polsku: po kolei
    private bool CheckIfStreigh()
    {
        if (CheckStreighStrength() > 0)
        {
            return true;
        }
        return false;
    }


    private byte CheckStreighStrength()
    {
        byte tempStrength = 0;
        //ACE case
        if (
            numberOfCards[14] >= 1 &&
            numberOfCards[2] >= 1 &&
            numberOfCards[3] >= 1 &&
            numberOfCards[4] >= 1 &&
            numberOfCards[5] >= 1
            )
        {
            tempStrength = 1;
        }
        for (byte i = 2; 4 + i < 15; i++)
        {
            if (
            numberOfCards[0 + i] >= 1 &&
            numberOfCards[1 + i] >= 1 &&
            numberOfCards[2 + i] >= 1 &&
            numberOfCards[3 + i] >= 1 &&
            numberOfCards[4 + i] >= 1
            )
            {
                tempStrength = i;
            }
        }
        return tempStrength;
    }


    private bool CheckIfFour()
    {
        byte tempFourStrength = CheckFourKind();
        if (tempFourStrength > 0)
        {
            fourWhichKind = tempFourStrength;
            fourLastCardStrength = CheckFourLastCard(fourWhichKind);
            return true;
        }
        return false;
    }

    private byte CheckFourLastCard(byte? fourKind)
    {
        byte strength = 0;
        var lastCard = (from card in allCards
                        where (card.Number != fourKind)
                        orderby (card.Number) descending
                        select card).Take(1);
        foreach (var card in lastCard)
        {
            strength += card.Number;
        }
        return strength;
    }
    //Kareta po polsku: cztery takie same figury
    //3 level of strength: 1)level FourOfKind 2)level WhichKind 3)level LastCard
    private byte CheckFourKind()
    {
        byte strFour = 0;

        for (byte i = 2; i < numberOfCards.Count; i++)//if confused, go to see numberofcards initialization
        {
            if (numberOfCards[i] == 4)
            {
                strFour = i;
            }
        }
        return strFour;
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

    //Level 1_6 1 if highest card, 2-6
    private void AllLeftIsHighestCard()
    {
        HighestCardLevel1 = 1;

        HighestCardLevel2 = 0;
        HighestCardLevel3 = 0;
        HighestCardLevel4 = 0;
        HighestCardLevel5 = 0;
        HighestCardLevel6 = 0;
        var lastCard = (from card in allCards
                        where (card.Number != 0)//This is not needed. Probably.
                        orderby (card.Number) descending
                        select card).Take(5);
        var tempArray = lastCard.ToArray<Card>();
        HighestCardLevel2 = tempArray[0].Number;
        HighestCardLevel3 = tempArray[0].Number;
        HighestCardLevel4 = tempArray[0].Number;
        HighestCardLevel5 = tempArray[0].Number;
        HighestCardLevel6 = tempArray[0].Number;
    }



}

