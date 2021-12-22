using System;
using System.Collections.Generic;
using System.Linq;
using TexasHoldEm;

public class Cardest
{
    //z setu allCards tworzymy zbiory dla specifiedCards
    private List<Card> allCards = new List<Card>();
    private List<Card> choosenCards = new List<Card>();

    private List<byte?> numberOfCards = new List<byte?>();

    private byte cardSetLevel = 0;

    private CardSymbol? symbolIfColor = null;
    private byte strengthOfColor;

    byte strengthOfStreigh = 0;

    byte? fourWhichKind = null;
    byte? fourLastCardStrength = null;

    byte? threeWhichKind = null;
    byte threeLevel3 = 0;
    byte threeLevel4 = 0;

    private byte? firstPairNumber = null;
    private byte? secondPairNumber = null;
    private byte? thirdPairNumber = null;

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
        for (int i = 2; i < 15; i++)
        {
            foreach (var card in allCards)
            {
                if (card.Number == i)
                {
                    numberOfCards[i] += 1;
                }
            }
        }
    }

    //------------------------------------------------ABOVE IS DONE
    //test this
    //good test case: 7karo in different positions
    private byte GetStrengthOfColor(CardSymbol? symbol)
    {
        if (symbol == null) { throw new ArgumentNullException("symbol"); }
        byte strength = 0;
        var fiveHighestCards = (from card in allCards
                                where (card.Symbol == symbol)
                                orderby (card.Number) descending
                                select card).Take(5);
        foreach (var card in fiveHighestCards)
        {
            strength += card.Number;
        }
        return strength;
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
            strengthOfColor = GetStrengthOfColor(symbolIfColor);
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


    private bool CheckIfFour(){
        byte tempFourStrength= CheckFourKind();
        if(tempFourStrength>0){
            fourWhichKind=tempFourStrength;
            fourLastCardStrength=CheckFourLastCard(fourWhichKind);
            return true;
        }
        return false;
    }

    private byte CheckFourLastCard(byte? fourKind){
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
        byte strFour=0;

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
    private bool CheckIfThree(){//1level
        byte kindOfThree=CheckThreeKind();
        if(kindOfThree>0){
            threeWhichKind=kindOfThree;
            CheckThreeLastCards(threeWhichKind);
            return true;
        }
        return false;
    }

    //Level 3,4
    private void CheckThreeLastCards(byte? cardKind){
        threeLevel3 = 0;
        threeLevel4 = 0;
        var lastCard = (from card in allCards
                                where (card.Number != cardKind)
                                orderby (card.Number) descending
                                select card).Take(2);
        var tempArray= lastCard.ToArray<Card>();
        threeLevel3=tempArray[0].Number;
        threeLevel4=tempArray[1].Number;
    }

    //2level
    private byte CheckThreeKind()
    {
        byte thereIsThree = 0;
        for (byte i = 2; i < numberOfCards.Count; i++)
        {
            if (numberOfCards[i] == 3)
            {
                threeWhichKind = i ;
            }
        }  
        return thereIsThree;
    }


    //analiza w dol potrzebna i potem dopisujemy pokery i wymagane property
    //i funkcje porownan

    //zapamietaj 3 najmocniejsze 2ki, w puli 7 kart moze byc max 3 2ki
    private bool CheckIfPair()
    {
        throw new NotImplementedException();
        byte numberOfPairs = 0;
        for (int i = 1; i < numberOfCards.Count; i++)
        {
            if (numberOfCards[i] == 2)
            {
                switch (numberOfPairs)
                {
                    case 0:
                        firstPairNumber = (byte?)(i + 1);
                        numberOfPairs++;
                        break;
                    case 1:
                        secondPairNumber = (byte?)(i + 1);
                        numberOfPairs++;
                        break;
                    case 2:
                        thirdPairNumber = (byte?)(i + 1);
                        numberOfPairs++;
                        break;
                }
            }
        }
        // ace case
        if (numberOfCards[0] == 2)
        {
            switch (numberOfPairs)
            {
                case 0:
                    firstPairNumber = (byte?)(1);
                    numberOfPairs++;
                    break;
                case 1:
                    secondPairNumber = (byte?)(1);
                    numberOfPairs++;
                    break;
                case 2:
                    thirdPairNumber = (byte?)(1);
                    numberOfPairs++;
                    break;
            }
        }
        if (numberOfPairs > 0)
        {
            return true;
        }
        return false;
    }


    private bool CheckHighestCard()
    {
        throw new NotImplementedException();

    }



}

