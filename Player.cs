using System;
using System.Collections.Generic;
using System.Linq;
using TexasHoldEm;

public class Player
{
    public int PlayerPosition_X { get; set; }
    public int PlayerPosition_Y { get; set; }
    private List<Card> playerCards = new List<Card>();

    public Player(int posX, int posY)
    {
        PlayerPosition_X = posX;
        PlayerPosition_Y = posY;
    }

    public void GivePlayerTwoCards(Card FirstCard,Card SecondCard){
        playerCards.Add(FirstCard);
        playerCards.Add(SecondCard);
    }

    public Card GetFirstCard(){
        return playerCards[0];
    }
    public Card GetSecondCard(){
        return playerCards[1];
    }

}