using System;
using System.Collections.Generic;
using TexasHoldEm;

public class Deck
{
    private List<Card> list=new List<Card>();
    private Queue<Card> queue=new Queue<Card>();

    private void addCardsWithSymbol(CardSymbol symbol){
        for (var i = 2; i <= 14; i++)
        {
            list.Add(new Card(symbol, i));
        }
    }

    private void QueueToList(){
        foreach (var card in queue)
        {
            list.Add(card);
        }
        queue.Clear();
    }

    private void ListToQueue(){
        foreach (var card in list)
        {
            queue.Enqueue(card);
        }
        list.Clear();
    }

    public Deck()
    {
        addCardsWithSymbol(CardSymbol.CLUB);
        addCardsWithSymbol(CardSymbol.DIAMOND);
        addCardsWithSymbol(CardSymbol.HEART);
        addCardsWithSymbol(CardSymbol.SPADE);

        ListToQueue();

        Shufle();
    }

    public void Shufle(){
        //Load to array
        QueueToList();
        //what to do in array?
        Random rand = new Random();
        for (int i = 0; i < list.Count; i++)
        {   
            // Random for remaining positions.
            int r = i + rand.Next(list.Count - i);            
            //swapping the elements
            Card temp = list[r];
            list[r] = list[i];
            list[i] = temp;      
        }
        ListToQueue();
    }

    public Card PickACard(){
        return queue.Dequeue();
    }
}