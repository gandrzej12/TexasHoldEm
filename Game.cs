using System;
using System.Collections.Generic;
using Terminal.Gui;
using TexasHoldEm;

public class Game
{
    Deck myDeck = new Deck();
    protected List<Player> playerList = new List<Player>();
    protected List<Card> tableCards = new List<Card>();

    public void StartGame()
    {
        GameSetup();
        ProgramGUI();
    }

    private void GameSetup(){
        myDeck = new Deck();
        tableCards= new List<Card>();
        AddPlayers();
        TossCardsToPlayers();
        FlopStateCards();
        TurnStateCards();
        RiverStateCards();
    }


    public void AddPlayers()
    {
        playerList.Clear();
        playerList.Add(new Player(3, 3));
        playerList.Add(new Player(3, 10));
        playerList.Add(new Player(3, 17));
        playerList.Add(new Player(120, 3));
        playerList.Add(new Player(120, 10));
        playerList.Add(new Player(120, 17));
    }

    public void TossCardsToPlayers()
    {
        for (int i = 0; i < 6; i++)
        {
            playerList[i].GivePlayerTwoCards(myDeck.PickACard(), myDeck.PickACard());
        }
    }

    public void FlopStateCards()
    {
        tableCards.Add(myDeck.PickACard());
        tableCards.Add(myDeck.PickACard());
        tableCards.Add(myDeck.PickACard());
    }
    public void TurnStateCards()
    {
        tableCards.Add(myDeck.PickACard());
    }

    public void RiverStateCards()
    {
        tableCards.Add(myDeck.PickACard());
    }

    static bool Quit()
    {
        var n = MessageBox.Query(50, 7, "Quit Simulation", "Are you sure?", "Yes", "No");
        return n == 0;
    }

    private void showPlayerCards(int playerNumber, Card card, Window myWin, int offset)
    {
        List<string> firstOrSecondCard= card.cardToGUI();
        for (int j = 0; j < firstOrSecondCard.Count; j++)
        {
            var cardRow = new Label(firstOrSecondCard[j])
            {
                X = playerList[playerNumber].PlayerPosition_X + offset,
                Y = (playerList[playerNumber].PlayerPosition_Y + 1 + j),
                ColorScheme = new ColorScheme()
                {
                    Normal = card.CardColor
                },
            };
            myWin.Add(cardRow);
        }
    }

    private void showTableCards(Window myWin)
    {
        int posX=50;
        int posY=10;
        int offset=9;
        for (int i = 0; i < tableCards.Count; i++)
        {
            List<string> card = tableCards[i].cardToGUI();
            for (int j = 0; j < card.Count; j++)
            {
                var cardRow = new Label(card[j])
                {
                    X = posX+ offset*i,
                    Y = posY+j,
                    ColorScheme = new ColorScheme()
                    {
                        Normal = tableCards[i].CardColor
                    },
                };
                myWin.Add(cardRow);
            }
        }
    }

    private void AddElementsGUI(Window win){
        for (int i = 0; i < 6; i++)
        {
            var playerLabel = new Label($"Player {i}")
            {
                X = playerList[i].PlayerPosition_X,
                Y = playerList[i].PlayerPosition_Y
            };
            win.Add(playerLabel);

            Card firstCard = playerList[i].GetFirstCard();
            showPlayerCards(i, firstCard, win, 0);

            Card secondCard = playerList[i].GetSecondCard();
            showPlayerCards(i, secondCard, win, 9);

            showTableCards(win);
        }
    }

    public void ProgramGUI()
    {
        Application.Init();
        var top = Application.Top;
        var tframe = top.Frame;

        var win = new Window("Texas HoldEm ~@G")
        {
            X = 0,
            Y = 1,
            Width = Dim.Fill(),
            Height = Dim.Fill() - 1
        };
        var menu = new MenuBar(new MenuBarItem[] {
            new MenuBarItem ("_F9", new MenuItem [] {
                //new MenuItem ("_Open", "", null),
                new MenuItem ("_Quit", "", () => { if (Quit ()) top.Running = false; }),
                new MenuItem ("_Restart", "", () => { GameSetup(); win.RemoveAll();AddElementsGUI(win);}),
            })
        });

        AddElementsGUI(win);

        top.Add(win, menu);
        top.Add(menu);
        Application.Run();
    }
}