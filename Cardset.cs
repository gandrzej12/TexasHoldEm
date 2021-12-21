using System;
using System.Collections.Generic;
using TexasHoldEm;

public class Cardest
{
    //z setu allCards tworzymy zbiory dla specifiedCards
    private List<Card> allCards = new List<Card>();
    //private List<Card> specifiedCards = new List<Card>();

    //private int value = 0;
    //private int level = 0;

    private CardSymbol symbolIfColor;
    int StrenghtOfStreigh = 0;
    int WhichNumberOfFour=99;//zmienic na byte? ustawiac null zamiast 99
    int WhichNumberOfThree=99;//zmienic na byte? ustawiac null zamiast 99

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

    //Kolor po polsku: ten sam znaczek
    //Powinno działać dobrze
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

    
    //Strit po polsku: po kolei
    //Powinno działać dobrze
    //sprawdz scenariusz z asem najmniejszy i najwiekszy
    private bool CheckIfStreigh(){
        StrenghtOfStreigh = 0;
        for(int i = 0; 4+i <13;i++){
            if(
            numberOfCards[0+i]>=1 && 
            numberOfCards[1+i]>=1 && 
            numberOfCards[2+i]>=1 &&
            numberOfCards[3+i]>=1 &&
            numberOfCards[4+i]>=1 
            ){
                StrenghtOfStreigh = i;
                return true;
            }       
        }
        if(
            numberOfCards[9]>=1 && 
            numberOfCards[10]>=1 && 
            numberOfCards[11]>=1 &&
            numberOfCards[12]>=1 &&
            numberOfCards[0]>=1 
            ){
                StrenghtOfStreigh = 10;
                return true;
            }
        return false;    
    }

    
    //Kareta po polsku: cztery takie same figury
    //ok bo moze istniec tylko jedna czworka
    private bool CheckIfFour(){
        throw new NotImplementedException();
        for(int i = 0; i < numberOfCards.Count; i++){
            if(numberOfCards[i]==4){
                WhichNumberOfFour=i+1;
                return true;
            }
        }
        WhichNumberOfFour=99;
        return false;
    }

    //zostanie najsilniejsza trojka
    private bool CheckIfThree(){
        throw new NotImplementedException();
        bool thereIsThree=false;       
        for(int i = 0; i < numberOfCards.Count; i++){
            if(numberOfCards[i]==3){
                WhichNumberOfThree=i+1;
                thereIsThree=true;
                //return true;
            }
        }
        return thereIsThree;
    }

    //not implemented 4 real
    private bool CheckIfPair(){
        throw new NotImplementedException();
        for(int i=0; i <numberOfCards.Count;i++){
            if(numberOfCards[i]==2){
                //zapisz symbol do zmiennej okreslonego typu- typ silny, typ slaby
                //dopisz do siły level siłę setu para
                //jeżeli typ silny i typ slaby jest zajety to porownaj z mocą
                //zwroc true
            }
        }
    }

    




}

