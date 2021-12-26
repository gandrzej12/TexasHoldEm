using System;
using System.Collections.Generic;
using Terminal.Gui;

public class Game
{
    Deck myDeck = new Deck();
    protected List<Player> playerList = new List<Player>();

    public void StartGame(){
        AddPlayers();

        ProgramGUI();
    }

    public void AddPlayers(){
        playerList.Add(new Player(3, 3));
        playerList.Add(new Player(3, 10));
        playerList.Add(new Player(3, 17));
        playerList.Add(new Player(120, 3));
        playerList.Add(new Player(120, 10));
        playerList.Add(new Player(120, 17));
    }

    static bool Quit()
    {
        var n = MessageBox.Query(50, 7, "Quit Demo", "Are you sure you want to quit this demo?", "Yes", "No");
        return n == 0;
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
                new MenuItem ("_Open", "", null),
                new MenuItem ("_Quit", "", () => { if (Quit ()) top.Running = false; })
            })
        });

        for (int i = 0; i < 6; i++)
        {
            var playerLabel = new Label($"Player {i}")
            {
                X = playerList[i].PlayerPosition_X,
                Y = playerList[i].PlayerPosition_Y
            };
            win.Add(playerLabel);
        }

        top.Add(win, menu);
        top.Add(menu);
        Application.Run();
    }
}