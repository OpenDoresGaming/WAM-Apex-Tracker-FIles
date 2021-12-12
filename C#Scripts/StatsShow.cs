using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StatsShow : MonoBehaviour
{

    public Text GamesPlayedText;
    public Text KillsText;
    public Text WinsText;
    public Text Summarytext;

    public GameObject canvas;

    GameScript game;
    private void OnEnable()
    {
        game = canvas.GetComponent<GameScript>();

        switch (PanelControl.PanelDay)
        {
            case 1:
                GamesPlayedText.text = "Games Played: " + game.MondayGP;
                KillsText.text = "Kills: " + game.MondayKills;
                WinsText.text = "Wins: " + game.MondayWins;
                Summarytext.text = "K/G - " + (game.MondayKills / game.MondayGP);
                break;
            case 2:
                GamesPlayedText.text = "Games Played: " + game.TuesdayGP;
                KillsText.text = "Kills: " + game.TuesdayKills;
                WinsText.text = "Wins: " + game.TuesdayWins;
                Summarytext.text = "K/G - " + Math.Round(game.TuesdayKills / game.TuesdayGP, 2);
                break;
            case 3:
                GamesPlayedText.text = "Games Played: " + game.WednsdayGP;
                KillsText.text = "Kills: " + game.WednsdayKills;
                WinsText.text = "Wins: " + game.WednsdayWins;
                Summarytext.text = "K/G - " + Math.Round(game.WednsdayKills / game.WednsdayGP, 2);
                break;
            case 4:
                GamesPlayedText.text = "Games Played: " + game.ThursdayGP;
                KillsText.text = "Kills: " + game.ThursdayKills;
                WinsText.text = "Wins: " + game.ThursdayWins;
                Summarytext.text = "K/G - " + Math.Round(game.ThursdayKills / game.ThursdayGP, 2);
                break;
            case 5:
                GamesPlayedText.text = "Games Played: " + game.FridayGP;
                KillsText.text = "Kills: " + game.FridayKills;
                WinsText.text = "Wins: " + game.FridayWins;
                Summarytext.text = "K/G - " + Math.Round(game.FridayKills / game.FridayGP, 2);
                break;
            case 6:
                GamesPlayedText.text = "Games Played: " + game.SaturdayGP;
                KillsText.text = "Kills: " + game.SaturdayKills;
                WinsText.text = "Wins: " + game.SaturdayWins;
                Summarytext.text = "K/G - " + Math.Round(game.SaturdayKills / game.SaturdayGP, 2);
                break;
            case 7:
                GamesPlayedText.text = "Games Played: " + game.SundayGP;
                KillsText.text = "Kills: " + game.SundayKills;
                WinsText.text = "Wins: " + game.SundayWins;
                Summarytext.text = "K/G - " + Math.Round(game.SundayKills / game.SundayGP, 2);

                break;
        }
    }
}
