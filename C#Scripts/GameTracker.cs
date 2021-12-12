using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameTracker : MonoBehaviour
{
    private string WeeklyKillsPrivateCode;
    private string WeeklyKillsPublicCode;

    private string WeeklyGamesPrivateCode;
    private string WeeklyGamesPublicCode;

    private string WeeklyWinsPrivateCode;
    private string WeeklyWinsPublicCode;



    const string WebURL = "http://dreamlo.com/lb/";

    public Text GamesPlayedText;
    public Text KillsText;
    public Text WinsText;
    public Text TitleText;
    public Text Summarytext;
    public Text WeeklySummaryText;

    private string TodaysDay;
    private string Username;
    private int WeeklyKills;
    private int WeeklyGames;
    private int WeeklyWins;

    GameScript game;

    
    // Start is called before the first frame update
    void Start()
    {
        game = GetComponent<GameScript>();

        WeeklyKillsPublicCode = game.WeeklyKillsPublicCode;
        WeeklyGamesPublicCode = game.WeeklyGamesPublicCode;
        WeeklyWinsPublicCode = game.WeeklyWinsPublicCode;

        WeeklyKillsPrivateCode = game.WeeklyKillsPrivateCode;
        WeeklyGamesPrivateCode = game.WeeklyGamesPrivateCode;
        WeeklyWinsPrivateCode = game.WeeklyWinsPrivateCode;

        TodaysDay = DateTime.Now.DayOfWeek.ToString();
        //Username = game.Name;
        Username = "New+Player";
        TitleText.text = "Daily Stats\n" + TodaysDay;
        switch(TodaysDay)
        {
            case "Monday":
                  GamesPlayedText.text = "Games Played: " +  game.MondayGP;
                  KillsText.text = "Kills: " + game.MondayKills;
                  WinsText.text = "Wins: " + game.MondayWins;
                Summarytext.text = "Today's K/G - " + (game.MondayKills / game.MondayGP);

                break;
            case "Tuesday":
                GamesPlayedText.text = "Games Played: " + game.TuesdayGP;
                KillsText.text = "Kills: " + game.TuesdayKills;
                WinsText.text = "Wins: " + game.TuesdayWins;
                Summarytext.text = "Today's K/G - " + Math.Round(game.TuesdayKills / game.TuesdayGP, 2);

                break;
            case "Wednesday":
                GamesPlayedText.text = "Games Played: " + game.WednsdayGP;
                KillsText.text = "Kills: " + game.WednsdayKills;
                WinsText.text = "Wins: " + game.WednsdayWins;
                Summarytext.text = "Today's K/G - " + Math.Round(game.WednsdayKills / game.WednsdayGP, 2);

                break;
            case "Thursday":
                GamesPlayedText.text = "Games Played: " + game.ThursdayGP;
                KillsText.text = "Kills: " + game.ThursdayKills;
                WinsText.text = "Wins: " + game.ThursdayWins;
                Summarytext.text = "Today's K/G - " + Math.Round(game.ThursdayKills / game.ThursdayGP, 2);
                

                break;
            case "Friday":
                GamesPlayedText.text = "Games Played: " + game.FridayGP;
                KillsText.text = "Kills: " + game.FridayKills;
                WinsText.text = "Wins: " + game.FridayWins;
                Summarytext.text = "Today's K/G - " + Math.Round(game.FridayKills / game.FridayGP, 2);

                break;
            case "Saturday":
                GamesPlayedText.text = "Games Played: " + game.SaturdayGP;
                KillsText.text = "Kills: " + game.SaturdayKills;
                WinsText.text = "Wins: " + game.SaturdayWins;
                Summarytext.text = "Today's K/G - " + Math.Round(game.SaturdayKills / game.SaturdayGP, 2);

                break;
            case "Sunday":
                GamesPlayedText.text = "Games Played: " + game.SundayGP;
                KillsText.text = "Kills: " + game.SundayKills;
                WinsText.text = "Wins: " + game.SundayWins;
                Summarytext.text = "Today's K/G - " + Math.Round(game.SundayKills / game.SundayGP, 2);

                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        WeeklySummaryText.text = "Weekly K/G - " + Math.Round((game.MondayKills + game.TuesdayKills + game.WednsdayKills + game.ThursdayKills + game.FridayKills + game.SaturdayKills + game.SundayKills)
    / (game.MondayGP + game.TuesdayGP + game.WednsdayGP + game.ThursdayGP + game.FridayGP + game.SaturdayGP + game.SundayGP), 2);

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(game.GameInputKey))
        {
            switch (TodaysDay)
            {
                case "Monday":
                    game.MondayGP--;
                    GamesPlayedText.text = "Games Played: " + game.MondayGP;
                    Summarytext.text = "Today's K/G - " + (game.MondayKills / game.MondayGP);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Tuesday":
                    game.TuesdayGP--;
                    GamesPlayedText.text = "Games Played: " + game.TuesdayGP;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.TuesdayKills / game.TuesdayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Wednesday":
                    game.WednsdayGP--;
                    GamesPlayedText.text = "Games Played: " + game.WednsdayGP;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.WednsdayKills / game.WednsdayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Thursday":
                    game.ThursdayGP--;
                    GamesPlayedText.text = "Games Played: " + game.ThursdayGP;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.ThursdayKills / game.ThursdayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Friday":
                    game.FridayGP--;
                    GamesPlayedText.text = "Games Played: " + game.FridayGP;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.FridayKills / game.FridayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Saturday":
                    game.SaturdayGP--;
                    GamesPlayedText.text = "Games Played: " + game.SaturdayGP;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.SaturdayKills / game.SaturdayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Sunday":
                    game.SundayGP--;
                    GamesPlayedText.text = "Games Played: " + game.SundayGP;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.SundayKills / game.SundayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
            }
            game.LifetimeGames--;
        }

        else if (Input.GetKeyDown(game.GameInputKey))
        {
            switch (TodaysDay)
            {
                case "Monday":
                    game.MondayGP++;
                    GamesPlayedText.text = "Games Played: " + game.MondayGP;
                    Summarytext.text = "Today's K/G - " + (game.MondayKills / game.MondayGP);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Tuesday":
                    game.TuesdayGP++;
                    GamesPlayedText.text = "Games Played: " + game.TuesdayGP;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.TuesdayKills / game.TuesdayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Wednesday":
                    game.WednsdayGP++;
                    GamesPlayedText.text = "Games Played: " + game.WednsdayGP;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.WednsdayKills / game.WednsdayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Thursday":
                    game.ThursdayGP++;
                    GamesPlayedText.text = "Games Played: " + game.ThursdayGP;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.ThursdayKills / game.ThursdayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Friday":
                    game.FridayGP++;
                    GamesPlayedText.text = "Games Played: " + game.FridayGP;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.FridayKills / game.FridayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Saturday":
                    game.SaturdayGP++;
                    GamesPlayedText.text = "Games Played: " + game.SaturdayGP;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.SaturdayKills / game.SaturdayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Sunday":
                    game.SundayGP++;
                    GamesPlayedText.text = "Games Played: " + game.SundayGP;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.SundayKills / game.SundayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
            }
            game.LifetimeGames++;
        }
        //if this doesnt suck add shift functions for deleting

        if (Input.GetKey(KeyCode.LeftControl) &&  Input.GetKeyDown(game.KillInputKey))
        {
            switch (TodaysDay)
            {
                case "Monday":
                    game.MondayKills--;
                    KillsText.text = "Kills: " + game.MondayKills;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.MondayKills / game.MondayGP,2);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Tuesday":
                    game.TuesdayKills--;
                    KillsText.text = "Kills: " + game.TuesdayKills;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.TuesdayKills / game.TuesdayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Wednesday":
                    game.WednsdayKills--;
                    KillsText.text = "Kills: " + game.WednsdayKills;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.WednsdayKills / game.WednsdayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Thursday":
                    game.ThursdayKills--;
                    KillsText.text = "Kills: " + game.ThursdayKills;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.ThursdayKills / game.ThursdayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Friday":
                    game.FridayKills--;
                    KillsText.text = "Kills: " + game.FridayKills;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.FridayKills / game.FridayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Saturday":
                    game.SaturdayKills--;
                    KillsText.text = "Kills: " + game.SaturdayKills;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.SaturdayKills / game.SaturdayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Sunday":
                    game.SundayKills--;
                    KillsText.text = "Kills: " + game.SundayKills;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.SundayKills / game.SundayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
            }
            game.LifetimeKills--;
        }

       else if (Input.GetKeyDown(game.KillInputKey))
        {
            switch (TodaysDay)
            {
                case "Monday":
                    game.MondayKills++;
                    KillsText.text = "Kills: " + game.MondayKills;
                    Summarytext.text = "Today's K/G - " + (game.MondayKills / game.MondayGP);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Tuesday":
                    game.TuesdayKills++;
                    KillsText.text = "Kills: " + game.TuesdayKills;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.TuesdayKills / game.TuesdayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Wednesday":
                    game.WednsdayKills++;
                    KillsText.text = "Kills: " + game.WednsdayKills;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.WednsdayKills / game.WednsdayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Thursday":
                    game.ThursdayKills++;
                    KillsText.text = "Kills: " + game.ThursdayKills;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.ThursdayKills / game.ThursdayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Friday":
                    game.FridayKills++;
                    KillsText.text = "Kills: " + game.FridayKills;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.FridayKills / game.FridayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Saturday":
                    game.SaturdayKills++;
                    KillsText.text = "Kills: " + game.SaturdayKills;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.SaturdayKills / game.SaturdayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Sunday":
                    game.SundayKills++;
                    KillsText.text = "Kills: " + game.SundayKills;
                    Summarytext.text = "Today's K/G - " + Math.Round(game.SundayKills / game.SundayGP, 2);
                    SaveSystemGame.SaveGame(game);
                    break;
            }
            game.LifetimeKills++;
        }

        if (Input.GetKey(KeyCode.LeftControl) &&Input.GetKeyDown(game.WinInputKey))
        {
            switch (TodaysDay)
            {
                case "Monday":
                    game.MondayWins--;
                    WinsText.text = "Wins: " + game.MondayWins;
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Tuesday":
                    game.TuesdayWins--;
                    WinsText.text = "Wins: " + game.TuesdayWins;
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Wednesday":
                    game.WednsdayWins--;
                    WinsText.text = "Wins: " + game.WednsdayWins;
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Thursday":
                    game.ThursdayWins--;
                    WinsText.text = "Wins: " + game.ThursdayWins;
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Friday":
                    game.FridayWins--;
                    WinsText.text = "Wins: " + game.FridayWins;
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Saturday":
                    game.SaturdayWins--;
                    WinsText.text = "WIns: " + game.SaturdayWins;
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Sunday":
                    game.SundayWins--;
                    WinsText.text = "Wins: " + game.SundayWins;
                    SaveSystemGame.SaveGame(game);
                    break;
            }
            game.LifetimeWins--;
        }

        else if (Input.GetKeyDown(game.WinInputKey))
        {
            switch (TodaysDay)
            {
                case "Monday":
                    game.MondayWins++;
                    WinsText.text = "Wins: " + game.MondayWins;
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Tuesday":
                    game.TuesdayWins++;
                    WinsText.text = "Wins: " + game.TuesdayWins;
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Wednesday":
                    game.WednsdayWins++;
                    WinsText.text = "Wins: " + game.WednsdayWins;
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Thursday":
                    game.ThursdayWins++;
                    WinsText.text = "Wins: " + game.ThursdayWins;
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Friday":
                    game.FridayWins++;
                    WinsText.text = "Wins: " + game.FridayWins;
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Saturday":
                    game.SaturdayWins++;
                    WinsText.text = "WIns: " + game.SaturdayWins;
                    SaveSystemGame.SaveGame(game);
                    break;
                case "Sunday":
                    game.SundayWins++;
                    WinsText.text = "Wins: " + game.SundayWins;
                    SaveSystemGame.SaveGame(game);
                    break;
            }
            game.LifetimeWins++;
        }

    }
        public void DelWeek()
        {
            GamesPlayedText.text = "Games Played: 0";
            KillsText.text = "Kills: 0";
            WinsText.text = "Wins: 0";
            Summarytext.text = "Today's K/G - 0";
        }

    private void OnApplicationFocus()
    {
        game = GetComponent<GameScript>();
        if(game.Name != "New Player")
        {
        Username = game.Name;
        WeeklyKills = (int)(game.MondayKills + game.TuesdayKills + game.WednsdayKills + game.ThursdayKills + game.FridayKills + game.SaturdayKills + game.SundayKills);
        WeeklyGames = (int)(game.MondayGP + game.TuesdayGP + game.WednsdayGP + game.ThursdayGP + game.FridayGP + game.SaturdayGP + game.SundayGP);
        WeeklyWins = (int)(game.MondayWins + game.TuesdayWins + game.WednsdayWins + game.ThursdayWins + game.FridayWins + game.SaturdayWins + game.SundayWins);
            if (game.WeeklyKillsPublicCode != "")
            {
            AddnewWeeklyKills(Username, WeeklyKills);
            }
            if (game.WeeklyGamesPublicCode != "")
            {
             AddnewWeeklyGames(Username, WeeklyGames);
            }
            if (game.WeeklyWinsPublicCode != "")
            {
            AddnewWeeklyWins(Username, WeeklyWins);
            }
        
        }
        
    }

    public void AddnewWeeklyKills(string username, int kills)
    {
        StartCoroutine(UploadNewWeeklyKills(username, kills));
    }
    IEnumerator UploadNewWeeklyKills(string username, int kills)
    {
       
        //Connect to leaderboard and upload username and highest level
        WWW www = new WWW(WebURL + WeeklyKillsPrivateCode + "/add/" + WWW.EscapeURL(username) + "/" + kills);
        yield return www;

        //debug prints
        if (string.IsNullOrEmpty(www.error))
        {
            //print("upload successful " + username + kills);
        }
        else
        {
            print("error: " + www.error);
        }

    }

    public void AddnewWeeklyGames(string username, int games)
    {
        StartCoroutine(UploadNewWeeklyGames(username, games));
    }
    IEnumerator UploadNewWeeklyGames(string username, int games)
    {

        //Connect to leaderboard and upload username and highest level
        WWW www = new WWW(WebURL + WeeklyGamesPrivateCode + "/add/" + WWW.EscapeURL(username) + "/" + games);
        yield return www;

        //debug prints
        if (string.IsNullOrEmpty(www.error))
        {
            //print("upload successful " + username + games);
        }
        else
        {
            print("error: " + www.error);
        }

    }
    public void AddnewWeeklyWins(string username, int wins)
    {
        StartCoroutine(UploadNewWeeklyWins(username, wins));
    }
    IEnumerator UploadNewWeeklyWins(string username, int wins)
    {

        //Connect to leaderboard and upload username and highest level
        WWW www = new WWW(WebURL + WeeklyWinsPrivateCode + "/add/" + WWW.EscapeURL(username) + "/" + wins);
        yield return www;

        //debug prints
        if (string.IsNullOrEmpty(www.error))
        {
            //print("upload successful " + username + wins);
        }
        else
        {
            print("error: " + www.error);
        }

    }

    /*public void DelScrewup(string username)
    {
        StartCoroutine(DeleteScrewup(username));
    }
    IEnumerator DeleteScrewup(string username)
    {

        ////Connect to leaderboard and upload username and highest level
        //WWW www = new WWW(WebURL + WeeklyWinsPrivateCode + "/delete/" + WWW.EscapeURL(username));
        //yield return www;

        ////Connect to leaderboard and upload username and highest level
        //WWW www = new WWW(WebURL + WeeklyKillsPrivateCode + "/delete/" + WWW.EscapeURL(username));
        //yield return www;

        ////Connect to leaderboard and upload username and highest level
        //WWW www = new WWW(WebURL + WeeklyGamesPrivateCode + "/delete/" + WWW.EscapeURL(username));
        //yield return www;

        //debug prints
        if (string.IsNullOrEmpty(www.error))
        {
            //print("upload successful " + username + wins);
        }
        else
        {
            print("error: " + www.error);
        }

    }*/
}
