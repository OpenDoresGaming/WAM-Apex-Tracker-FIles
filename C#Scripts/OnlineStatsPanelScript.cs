using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class OnlineStatsPanelScript : MonoBehaviour
{
   // private string WeeklyKillsPrivateCode;
   // private string WeeklyKillsPublicCode;
   //
   // private string WeeklyGamesPrivateCode;
   // private string WeeklyGamesPublicCode;
   //
   // private string WeeklyWinsPrivateCode;
   // private string WeeklyWinsPublicCode;
   //
   // private string TournamentsPrivateCode;
   // private string TournamentsPublicCode;


    const string WebURL = "http://dreamlo.com/lb/";

    //array of scores to be filled by leaderboard
    public Highscore[] killshighscoresList;
    public Highscore[] gameshighscoresList;
    public Highscore[] winshighscoresList;
    public Highscore[] tournamentscoresList;

    //where the list is placed when filled
    public Transform killsholder;
    public Transform gamesholder;
    public Transform winsholder;
    public Transform tournamentsholder;

    //referenced text for size and shape
    public Text newHighScoreTexts;
    public Text Referencetext;

    public InputField TournamentNameField;
    public InputField TournamentDateField;
    public InputField TournamentPositionField;

    public GameObject TournamentsPanel;
    public GameObject HelpPanel;
    public GameObject SetCodesPanel;
    public GameObject LeaderboardsPanel;

    GameScript game;

    private string TourneyName;
    private string TourneyDate;
    private string NameDate;
    private int Placement;


    private void Awake()
    {
        game = GetComponent<GameScript>();
       //WeeklyKillsPublicCode = game.WeeklyKillsPublicCode;
       //WeeklyGamesPublicCode = game.WeeklyGamesPublicCode;
       //WeeklyWinsPublicCode = game.WeeklyWinsPublicCode;
       //TournamentsPublicCode = game.TournamentPublicCode;
       //
       //WeeklyKillsPrivateCode = game.WeeklyKillsPrivateCode;
       //WeeklyGamesPrivateCode = game.WeeklyGamesPrivateCode;
       //WeeklyWinsPrivateCode = game.WeeklyWinsPrivateCode;
       //TournamentsPrivateCode = game.TournamentPrivateCode;


    }
    private void Start()
    {
        if(game.WeeklyKillsPublicCode != "")
        {
        DownloadWeeklyKillScores();
        }
        if (game.WeeklyGamesPublicCode != "")
        {
        DownloadWeeklyGameScores();
        }
        if (game.WeeklyWinsPublicCode != "")
        {
        DownloadWeeklyWinScores();
        }
        if (game.TournamentPublicCode != "")
        {
        DownloadTournamentScores();
        }
    }

    public void DownloadWeeklyKillScores()
    {
        StartCoroutine("DownloadKillScores");
    }

    IEnumerator DownloadKillScores()
    {
        //access leaderboard and download usernames and levels
        WWW www = new WWW(WebURL + game.WeeklyKillsPublicCode + "/pipe/");
        yield return www;
        //debug log
        if (string.IsNullOrEmpty(www.error))
        {
            FormatKillsHighscores(www.text);
        }
        else
        {
            print("error: " + www.error);
        }
    }

    //organize usernames and levels into readable list
    void FormatKillsHighscores(string textStream)
    {
        //string array being filled by leaderboard information
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        killshighscoresList = new Highscore[entries.Length];

        //loop to display items in list
        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            killshighscoresList[i] = new Highscore(username, score);
            newHighScoreTexts = (Instantiate(Referencetext, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), killsholder));



            newHighScoreTexts.name = ("Score " + i.ToString());

            //print(highscoresList[i].username + ": " + highscoresList[i].score);



            //this line will change the ui text 
            newHighScoreTexts.text = (killshighscoresList[i].username + ": Weekly Kills:\n " + killshighscoresList[i].score);
        }
    }

    public void DownloadWeeklyGameScores()
    {
        StartCoroutine("DownloadGameScores");
    }

    IEnumerator DownloadGameScores()
    {
        //access leaderboard and download usernames and levels
        WWW www = new WWW(WebURL + game.WeeklyGamesPublicCode + "/pipe/");
        yield return www;
        //debug log
        if (string.IsNullOrEmpty(www.error))
        {
            FormatGamesHighscores(www.text);
        }
        else
        {
            print("error: " + www.error);
        }
    }

    //organize usernames and levels into readable list
    void FormatGamesHighscores(string textStream)
    {
        //string array being filled by leaderboard information
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        gameshighscoresList = new Highscore[entries.Length];

        //loop to display items in list
        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            gameshighscoresList[i] = new Highscore(username, score);
            newHighScoreTexts = (Instantiate(Referencetext, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), gamesholder));



            newHighScoreTexts.name = ("Score " + i.ToString());

            //print(highscoresList[i].username + ": " + highscoresList[i].score);



            //this line will change the ui text 
            newHighScoreTexts.text = (gameshighscoresList[i].username + ": Weekly Games:\n" + gameshighscoresList[i].score);
        }
    }

    public void DownloadWeeklyWinScores()
    {
        StartCoroutine("DownloadWinScores");
    }

    IEnumerator DownloadWinScores()
    {
        //access leaderboard and download usernames and levels
        WWW www = new WWW(WebURL + game.WeeklyWinsPublicCode + "/pipe/");
        yield return www;
        //debug log
        if (string.IsNullOrEmpty(www.error))
        {
            FormatWinsHighscores(www.text);
        }
        else
        {
            print("error: " + www.error);
        }
    }

    //organize usernames and levels into readable list
    void FormatWinsHighscores(string textStream)
    {
        //string array being filled by leaderboard information
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        winshighscoresList = new Highscore[entries.Length];

        //loop to display items in list
        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            winshighscoresList[i] = new Highscore(username, score);
            newHighScoreTexts = (Instantiate(Referencetext, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), winsholder));



            newHighScoreTexts.name = ("Score " + i.ToString());

            //print(highscoresList[i].username + ": " + highscoresList[i].score);



            //this line will change the ui text 
            newHighScoreTexts.text = (winshighscoresList[i].username + ": Weekly Wins:\n" + winshighscoresList[i].score);
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

    public void DownloadTournamentScores()
    {
        StartCoroutine("DownloadTourneyScores");
    }

    IEnumerator DownloadTourneyScores()
    {
        //access leaderboard and download usernames and levels
        WWW www = new WWW(WebURL + game.TournamentPublicCode + "/pipe/");
        yield return www;
        //debug log
        if (string.IsNullOrEmpty(www.error))
        {
            FormatTournamentscores(www.text);
        }
        else
        {
            print("error: " + www.error);
        }
    }

    //organize usernames and levels into readable list
    void FormatTournamentscores(string textStream)
    {
        //string array being filled by leaderboard information
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        tournamentscoresList = new Highscore[entries.Length];

        //loop to display items in list
        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            tournamentscoresList[i] = new Highscore(username, score);
            newHighScoreTexts = (Instantiate(Referencetext, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), tournamentsholder));



            newHighScoreTexts.name = ("Score " + i.ToString());

            //print(highscoresList[i].username + ": " + highscoresList[i].score);



            //this line will change the ui text 
            newHighScoreTexts.text = (tournamentscoresList[i].username + "\nPlacement - " + tournamentscoresList[i].score);
        }
    }


    public void SetTourneyName(string _name)
    {
        //add random 4 digit number to username for uniqueness
        TourneyName = TournamentNameField.text;
    }
    public void SetTourneyDate(string _name)
    {
        //add random 4 digit number to username for uniqueness
        TourneyDate = TournamentDateField.text;
    }
    public void SetTourneyPlacement(string _name)
    {
        Placement = int.Parse(TournamentPositionField.text);
    }


    public void SendTournamentData()
    {
        NameDate = TourneyName + "_" + TourneyDate;

        AddnewTournament(NameDate, Placement);
    }

    public void AddnewTournament(string nameDate, int position)
    {
        StartCoroutine(UploadNewTournament(nameDate, position));
    }
    IEnumerator UploadNewTournament(string nameDate, int position)
    {

        //Connect to leaderboard and upload username and highest level
        WWW www = new WWW(WebURL + game.TournamentPrivateCode + "/add/" + WWW.EscapeURL(nameDate) + "/" + position);
        yield return www;

        //debug prints
        if (string.IsNullOrEmpty(www.error))
        {
            print("upload successful " + nameDate + position);
        }
        else
        {
            print("error: " + www.error);
        }

    }



    public void OnlineBack()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void OpenCodesPanel()
    {
        LeaderboardsPanel.SetActive(false);
        SetCodesPanel.SetActive(true);
    }
    public void CloseCodesPanel()
    {
        SceneManager.LoadScene("Online Scene");
    }


    public void CloseTournamentPanel()
    {
        TournamentsPanel.SetActive(false);
    }
    public void OpenTournamentPanel()
    {
        TournamentsPanel.SetActive(true);
    }
    public void CloseHelpPanel()
    {
        HelpPanel.SetActive(false);
    }
    public void OpenHelpPanel()
    {
        HelpPanel.SetActive(true);
    }

    public void OpenTutorial()
    {
        Application.OpenURL("https://youtu.be/oDEnNnQFsoE");
    }
    public void OpenDreamlo()
    {
        Application.OpenURL("https://dreamlo.com/");
    }
}
