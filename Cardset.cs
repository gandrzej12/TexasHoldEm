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

    byte? FourWhichKind = null;
    byte? FourLastCardStrength = null;

    byte? WhichNumberOfThree = null;

    private byte? FirstPairNumber = null;
    private byte? SecondPairNumber = null;
    private byte? ThirdPairNumber = null;

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
        throw new NotImplementedException();
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
        byte tempFourStrength= CheckFourStrength();
        if(tempFourStrength>0){
            FourWhichKind=tempFourStrength;
            FourLastCardStrength=CheckFourLastCard(FourWhichKind);
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
    private byte CheckFourStrength()
    {
        byte strengthOfFour=0;

        for (byte i = 2; i < numberOfCards.Count; i++)//if confused, go to see numberofcards initialization
        {
            if (numberOfCards[i] == 4)
            {
                strengthOfFour = i;
            }
        }
        return strengthOfFour;
    }

    //zostanie najsilniejsza trojka
    private bool CheckIfThree()
    {
        throw new NotImplementedException();
        bool thereIsThree = false;
        for (int i = 1; i < numberOfCards.Count; i++)
        {
            if (numberOfCards[i] == 3)
            {
                WhichNumberOfThree = i + 1;
                thereIsThree = true;
            }
        }
        if (numberOfCards[0] == 3)
        {//Aces
            WhichNumberOfThree = 1;
            thereIsThree = true;
        }
        return thereIsThree;
    }

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
                        FirstPairNumber = (byte?)(i + 1);
                        numberOfPairs++;
                        break;
                    case 1:
                        SecondPairNumber = (byte?)(i + 1);
                        numberOfPairs++;
                        break;
                    case 2:
                        ThirdPairNumber = (byte?)(i + 1);
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
                    FirstPairNumber = (byte?)(1);
                    numberOfPairs++;
                    break;
                case 1:
                    SecondPairNumber = (byte?)(1);
                    numberOfPairs++;
                    break;
                case 2:
                    ThirdPairNumber = (byte?)(1);
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

