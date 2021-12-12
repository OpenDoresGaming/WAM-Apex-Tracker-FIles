using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class WeekReset : MonoBehaviour
{
    //codes to access leaderboard
    //leaderboard can be found here (https://dreamlo.com/lb/yFWY8WGdwUOkk6gBCes41wwx3arDBnGkeaGxVjcLLnRQ)
    const string PrivateCode = "yFWY8WGdwUOkk6gBCes41wwx3arDBnGkeaGxVjcLLnRQ";
    const string PublicCode = "619f6be88f40bb127882946e";
    const string WebURL = "http://dreamlo.com/lb/";

    //array of scores to be filled by leaderboard
    public Highscore[] highscoresList;

    ////where the list is placed when filled
    //public Transform holder;
    //
    ////referenced text for size and shape
    //public Text newHighScoreTexts;
    //public Text text;

    public int WeeklyUpdateScore;

    GameScript game;
    public GameObject canvas;

    private void Awake()
    {
        game = canvas.GetComponent<GameScript>();
        switch (game.Name)
        {
            case "Will":
                WeeklyUpdateScore = 50;
                break;
            case "Andy":
                WeeklyUpdateScore = 40;
                break;
            case "Marc":
                WeeklyUpdateScore = 30;
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DownloadScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DownloadScores()
    {
        StartCoroutine("DownloadHighScores");
    }
    IEnumerator DownloadHighScores()
    {
        //access leaderboard and download usernames and levels
        WWW www = new WWW(WebURL + PublicCode + "/pipe/");
        yield return www;

        //debug log
        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscores(www.text);
        }
        else
        {
            print("error: " + www.error);
        }
    }
    //organize usernames and levels into readable list
    void FormatHighscores(string textStream)
    {
        //string array being filled by leaderboard information
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];
        //loop to display items in list
        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);


            print(highscoresList[i].username + ": " + highscoresList[i].score);
        }
        switch (game.Name)
        {
              case "Will":
          //will update check
          if (highscoresList[3].score == 1 && highscoresList[0].score == 49)
          {
              UpdateWeeklyReset(game.Name, WeeklyUpdateScore);
                      NewWeek();
          }
                  break;
              case "Andy":
          //andy update check
          if (highscoresList[3].score == 1 && highscoresList[1].score == 39)
          {
              UpdateWeeklyReset(game.Name, WeeklyUpdateScore);
                      NewWeek();
          }
                  break;
              case "Marc":
          //marc update check
          if (highscoresList[3].score == 1 && highscoresList[2].score == 29)
          {
              UpdateWeeklyReset(game.Name, WeeklyUpdateScore);
                      NewWeek();
          }
                break;
        }
    }
    
    // structs to format what information should be accessed
    public struct Highscore
    {
        public string username;
        public int score;

        public Highscore(string _username, int _score)
        {
            username = _username;
            score = _score;
        }
    }

    //upload username and level
    public void UpdateWeeklyReset(string username, int score)
    {
        StartCoroutine(UploadNewHighScore(username, score));
    }
    IEnumerator UploadNewHighScore(string username, int score)
    {
        //access leaderboard and upload usernames and levels
        UnityWebRequest www = new UnityWebRequest(WebURL + PrivateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score);
        yield return www;

        //debug log 
        if (string.IsNullOrEmpty(www.error))
        {
            print("upload successfull" + username + score);
        }
        else
        {
            print("error: " + www.error);
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
        SaveSystemGame.SaveGame(game);
    }
}
