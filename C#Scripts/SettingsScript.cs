using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.IO;

public class SettingsScript : MonoBehaviour
{

    private string WeeklyKillsPrivateCode;
    private string WeeklyKillsPublicCode;

    private string WeeklyGamesPrivateCode;
    private string WeeklyGamesPublicCode;

    private string WeeklyWinsPrivateCode;
    private string WeeklyWinsPublicCode;

    private int WeeklyKills;
    private int WeeklyGames;
    private int WeeklyWins;

    private bool NameChanged;


    const string WebURL = "http://dreamlo.com/lb/";
    public Text SuccessText;
    public Text NameChangeFailText;
    public string OldUsername;
    public string NameToDelete;

    public InputField UsernameChangeInputField;
    public InputField NameToDeleteInputField;
    public GameObject BusySpinner;
    public GameObject ChangeUsernamePanel;
    public GameObject SettingsPanel;
    public GameObject DeleteEntryPanel;
    public GameObject ThemePanel;
    public GameObject ChangeKeyBindsPanel;

    public GameObject DelppButton;

    public Button ChangeNameBackButton;
    public Button ChangeNameConfirmButton;

    GameScript game;
    // Start is called before the first frame update
    private void Awake()
    {
        game = GetComponent<GameScript>();
        
    }
    void Start()
    {
        print(game.Name);
        WeeklyKillsPublicCode = game.WeeklyKillsPublicCode;
        WeeklyGamesPublicCode = game.WeeklyGamesPublicCode;
        WeeklyWinsPublicCode = game.WeeklyWinsPublicCode;

        WeeklyKillsPrivateCode = game.WeeklyKillsPrivateCode;
        WeeklyGamesPrivateCode = game.WeeklyGamesPrivateCode;
        WeeklyWinsPrivateCode = game.WeeklyWinsPrivateCode;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.F1))
        {
            DelppButton.SetActive(true);
        }
    }
    public void DeleteEntryPanelOpen()
    {
        DeleteEntryPanel.SetActive(true);
        NameToDelete = "";
    }
    public void DeleteEntryPanelClose()
    {
        DeleteEntryPanel.SetActive(false);
    }

    public void ReportBug()
    {
        Application.OpenURL("mailto:opendoresgaming@gmail.com" + "?subject=WAM Apex Tracker Bug Report" + "&body=Below you can report a problem or suggestion for WAM Apex Tracker.    " +
            "What is the bug?: ________________    Where is the bug?: ______________________   What is todays date?: __________________      What were you doing to get this bug?: _________________________       " +
            "Can you do it again and get the same bug?: ______________________     Add any suggestions you have here: ____________     Thank you for taking the time to Email me, every bug found helps a lot :).");
    }

    public void Donate()
    {
        Application.OpenURL("https://opendoresgaming.itch.io/wam-apex-tracker");
    }
    public void ThemePanelOpen()
    {
        ThemePanel.SetActive(true);
    }
    public void ThemePanelClosed()
    {
        ThemePanel.SetActive(false);
    }
    public void KeybindsPanelOpen()
    {
        ChangeKeyBindsPanel.SetActive(true);
    }
    public void KeybindsPanelClosed()
    {
        ChangeKeyBindsPanel.SetActive(false);
    }

    public void ChangeUsernamePanelOpen()
    {
        NameChanged = false;
        OldUsername = "";
        ChangeUsernamePanel.SetActive(true);
    }
    public void SettingsBack()
    {
        SceneManager.LoadScene("Main Scene");
    }
    public void ChangeUsernamePanelClose()
    {
        if(NameChanged == false && OldUsername !="")
        {
            game.Name = OldUsername;
            SaveSystemGame.SaveGame(game);
            OldUsername = "";
        ChangeUsernamePanel.SetActive(false);
        }
        else if (NameChanged == false && OldUsername == "")
        {
            ChangeUsernamePanel.SetActive(false);
        }
        else if(NameChanged == true)
        {
            ChangeUsernamePanel.SetActive(false);
        }
    }

    public void CreateAddressText()
    {
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Local Leaderboard Web Addresses.txt", "Local Leaderboard" +
    " Web Addressses\n\nWeekly Kills:\nhttp://dreamlo.com/lb/" + game.WeeklyKillsPrivateCode + "\n\nWeekly Games:\nhttp://dreamlo.com/lb/" +
    game.WeeklyGamesPrivateCode + "\n\nWeekly Wins:\nhttp://dreamlo.com/lb/" + game.WeeklyWinsPrivateCode + "\n\nTournaments:\nhttp://dreamlo.com/lb/" +
    game.TournamentPrivateCode +"\n\n(If you are sending this file to your squad, you can delete the following before sending. They are just information in case you\n" +
    "want to delete your local stats or forget your username.)\n\nUsername:\n" + game.Name + "\n\nLocal Save Location (Do not mess with this unless you want all your stats gone)" +
    "\n" + Application.persistentDataPath);

        SuccessText.text = "File Successfuly Created!\nCheck your Desktop!";
    }

    public void CreateArtistText()
    {
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ForArtists.txt", "Background Image Dimenstions:\n" +
            "640 x 480 (4:3)\n\nRound Button Dimensions:\n70 x 70\n\nRectangle Button Dimensions\n160 x 30\n\nWAM Logo Dimesnsions\n" +
            "300 x 300\n\nFont:\nArial\n\n\n\n" +
            "The Email address to send whatever you make to is\nopendoresgaming@gmail.com\n\nZip files are always welcome, along with a" +
            " quick text explaining where what is for.\nAlso include how you would like to be credited (Name, portfolio link, " +
            "whatever else you feel is relevant).\nLastly this is not a paid job. This would be out of the goodness of your heart." +
            "\nAnd for that, I thank you.");

    }
    public void SetOldName(string _name)
    {
        if (UsernameChangeInputField.text != "")
        {


            OldUsername = game.Name;

            game.Name = UsernameChangeInputField.text;
            SaveSystemGame.SaveGame(game);
        }
    }
    public void SetNameToDelete(string _name)
    {
        if (NameToDeleteInputField.text != "")
        {

            NameToDelete = NameToDeleteInputField.text;
        }
    }

    public void BeginChangeUsername()
    {
        WeeklyKills = (int)(game.MondayKills + game.TuesdayKills + game.WednsdayKills + game.ThursdayKills + game.FridayKills + game.SaturdayKills + game.SundayKills);
        WeeklyGames = (int)(game.MondayGP + game.TuesdayGP + game.WednsdayGP + game.ThursdayGP + game.FridayGP + game.SaturdayGP + game.SundayGP);
        WeeklyWins = (int)(game.MondayWins + game.TuesdayWins + game.WednsdayWins + game.ThursdayWins + game.FridayWins + game.SaturdayWins + game.SundayWins);
        StartCoroutine("ChangeUsername");

    }
    IEnumerator ChangeUsername()
    {
        if (game.Name != "" || game.Name != "New Player" || game.Name != "new player" || game.Name != "New player" || game.Name != "new Player")
        {
            ChangeNameBackButton.interactable = false;
            ChangeNameConfirmButton.interactable = false;
            UsernameChangeInputField.interactable = false;
            NameChangeFailText.text = "Please do not close tracker!";
            BusySpinner.SetActive(true);
        DelKillUsername(OldUsername);
        yield return new WaitForSeconds(3);
        DelGameUsername(OldUsername);
        yield return new WaitForSeconds(3);
        DelWinUsername(OldUsername);
        yield return new WaitForSeconds(1);
            if (game.WeeklyKillsPublicCode != "")
            {
                AddnewWeeklyKills(game.Name, WeeklyKills);
            }
            yield return new WaitForSeconds(3);
            if (game.WeeklyGamesPublicCode != "")
            {
                AddnewWeeklyGames(game.Name, WeeklyGames);
            }
            yield return new WaitForSeconds(3);
            if (game.WeeklyWinsPublicCode != "")
            {
                AddnewWeeklyWins(game.Name, WeeklyWins);
            }
            NameChangeFailText.text = "Name Changed Successfully";
            BusySpinner.SetActive(false);
            NameChanged = true;
            ChangeNameBackButton.interactable = true;
            ChangeNameConfirmButton.interactable = true;
            UsernameChangeInputField.interactable = true;
        }
        else
        {
            NameChangeFailText.text = "Please pick a different Username!";
            BusySpinner.SetActive(false);
            ChangeNameBackButton.interactable = true;
            ChangeNameConfirmButton.interactable = true;
            UsernameChangeInputField.interactable = true;
        }

    }

    public void BeginDeleteEntry()
    {
        StartCoroutine("DeleteUsername");
    }
    IEnumerator DeleteUsername()
    {
            BusySpinner.SetActive(true);
            DelKillUsername(NameToDelete);
            yield return new WaitForSeconds(3);
            DelGameUsername(NameToDelete);
            yield return new WaitForSeconds(3);
            DelWinUsername(NameToDelete);
        yield return new WaitForSeconds(2);
            BusySpinner.SetActive(false);

    }

    public void DelKillUsername(string username)
    {
        StartCoroutine(DeleteKillUsername(username));
    }
    IEnumerator DeleteKillUsername(string username)
    {
        //Connect to leaderboard and upload username and highest level
        WWW www = new WWW(WebURL + WeeklyKillsPrivateCode + "/delete/" + WWW.EscapeURL(username));
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

    public void DelGameUsername(string username)
    {
        StartCoroutine(DeleteGameUsername(username));
    }
    IEnumerator DeleteGameUsername(string username)
    {

        //Connect to leaderboard and upload username and highest level
        WWW www = new WWW(WebURL + WeeklyGamesPrivateCode + "/delete/" + WWW.EscapeURL(username));
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

    public void DelWinUsername(string username)
    {
        StartCoroutine(DeleteWinUsername(username));
    }
    IEnumerator DeleteWinUsername(string username)
    {

         //Connect to leaderboard and upload username and highest level
         WWW www = new WWW(WebURL + WeeklyWinsPrivateCode + "/delete/" + WWW.EscapeURL(username));
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

    public void PrivacyPolicyOpen()
    {
        Application.OpenURL("https://opendoresgaming.com/Privacy-Policy/");
    }
    private void OnApplicationQuit()
    {
        if (NameChanged == false && OldUsername != "") 
        {
            game.Name = OldUsername;
            SaveSystemGame.SaveGame(game);
            print(game.Name);
        }
    }

    public void delpp()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}
