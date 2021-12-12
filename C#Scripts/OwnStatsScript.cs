using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwnStatsScript : MonoBehaviour
{

    public GameObject canvas;

    public Text GPText;
    public Text KillsText;
    public Text WinsText;
    public Text SummaryText;

    GameScript game;
    private void OnEnable()
    {
        game = canvas.GetComponent<GameScript>();

        GPText.text = "Lifetime Games Played - " + game.LifetimeGames;
        KillsText.text = "Lifetime Kills - " + game.LifetimeKills;
        WinsText.text = "Lifetime Wins - " + game.LifetimeWins;

        SummaryText.text = "Lifetime K/G\n" + Math.Round((game.LifetimeKills / game.LifetimeGames),2) + "\n\nLifetime Win %\n" + Math.Round((game.LifetimeWins / game.LifetimeGames * 100),2) +"%";
    }
}
