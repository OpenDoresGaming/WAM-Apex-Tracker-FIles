using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FirstPlay : MonoBehaviour
{


    const string WebURL = "http://dreamlo.com/lb/";




    // Start is called before the first frame update
    GameScript game;
    private void Awake()
    {
        game = GetComponent<GameScript>();
    }
    void Start()
    {

        if (!PlayerPrefs.HasKey("Version"))
        {
            PlayerPrefs.SetString("Version","1.0.0");
            PlayerPrefs.Save();

            game.Name = "New Player";
            game.FirstUse = true;
            game.MondayGP = 0;
            game.MondayKills = 0;
            game.MondayWins = 0;

            game.TuesdayGP = 0;
            game.TuesdayKills = 0;
            game.TuesdayWins = 0;

            game.WednsdayGP = 0;
            game.WednsdayKills = 0;
            game.WednsdayWins = 0;

            game.ThursdayGP = 0;
            game.ThursdayKills = 0;
            game.ThursdayWins = 0;

            game.FridayGP = 0;
            game.FridayKills = 0;
            game.FridayWins = 0;

            game.SaturdayGP = 0;
            game.SaturdayKills = 0;
            game.SaturdayWins = 0;

            game.SundayGP = 0;
            game.SundayKills = 0;
            game.SundayWins = 0;

            game.LifetimeGames = 0;
            game.LifetimeKills = 0;
            game.LifetimeWins = 0;

            game.WeeklyKillsPublicCode = "";
            game.WeeklyKillsPrivateCode = "";
            game.WeeklyGamesPublicCode = "";
            game.WeeklyGamesPrivateCode = "";
            game.WeeklyWinsPublicCode = "";
            game.WeeklyWinsPrivateCode = "";
            game.TournamentPublicCode = "";
            game.TournamentPrivateCode = "";

            game.GameInputKey = KeyCode.F10;
            game.KillInputKey = KeyCode.F11;
            game.WinInputKey = KeyCode.F12;

            // game.WeeklyReset = true;

            SaveSystemGame.SaveGame(game);


        }
    }
    public void NewWeek()
    {
        game.MondayGP = 0;
        game.MondayKills = 0;
        game.MondayWins = 0;

        game.TuesdayGP = 0;
        game.TuesdayKills = 0;
        game.TuesdayWins = 0;

        game.WednsdayGP = 0;
        game.WednsdayKills = 0;
        game.WednsdayWins = 0;

        game.ThursdayGP = 0;
        game.ThursdayKills = 0;
        game.ThursdayWins = 0;

        game.FridayGP = 0;
        game.FridayKills = 0;
        game.FridayWins = 0;

        game.SaturdayGP = 0;
        game.SaturdayKills = 0;
        game.SaturdayWins = 0;

        game.SundayGP = 0;
        game.SundayKills = 0;
        game.SundayWins = 0;

        if(game.WeeklyKillsPrivateCode != "")
        {
        RemoveWeeklyKills(game.Name);
        }
        if (game.WeeklyGamesPrivateCode != "")
        {
        RemoveWeeklyGames(game.Name);
        }
        if (game.WeeklyWinsPrivateCode != "")
        {
        RemoveWeeklyWins(game.Name);
        }
        SaveSystemGame.SaveGame(game);
    }
    public void RemoveWeeklyKills(string username)
    {
        StartCoroutine(DeleteWeeklyKills(username));
    }

    IEnumerator DeleteWeeklyKills(string username)
    {
        //Connect to leaderboard and upload username and highest level
        WWW www = new WWW(WebURL + game.WeeklyKillsPrivateCode + "/delete/" + WWW.EscapeURL(username));
        yield return www;
    }

    public void RemoveWeeklyGames(string username)
    {
        StartCoroutine(DeleteWeeklyGames(username));
    }

    IEnumerator DeleteWeeklyGames(string username)
    {
        //Connect to leaderboard and upload username and highest level
        WWW www = new WWW(WebURL + game.WeeklyGamesPrivateCode + "/delete/" + WWW.EscapeURL(username));
        yield return www;
    }

    public void RemoveWeeklyWins(string username)
    {
        StartCoroutine(DeleteWeeklyWins(username));
    }

    IEnumerator DeleteWeeklyWins(string username)
    {
        //Connect to leaderboard and upload username and highest level
        WWW www = new WWW(WebURL + game.WeeklyWinsPrivateCode + "/delete/" + WWW.EscapeURL(username));
        yield return www;
    }
}
