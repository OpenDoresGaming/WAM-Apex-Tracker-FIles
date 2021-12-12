using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PanelControl : MonoBehaviour
{
    //Update leaderboard can be found here - https://dreamlo.com/lb/wLyUBHtsuESEJv-n-rbEFQBacETitcpEOahO7KHVmyCw
    const string UpdatePublicCode = "61b359fd8f40bb3920264266";
    const string UpdatePrivateCode = "wLyUBHtsuESEJv-n-rbEFQBacETitcpEOahO7KHVmyCw";
    public Updates[] updateList;
    const string WebURL = "http://dreamlo.com/lb/";

    public Button MondayButton;
    public Button TuesdayButton;
    public Button WednsdayButton;
    public Button ThursdayButton;
    public Button FridayButton;
    public Button SaturdayButton;
    public Button SundayButton;

    public GameObject NamePanel;
    public GameObject FirstUsePanel;
    public GameObject MondayPanel;
    public GameObject TuesdayPanel;
    public GameObject WednsdayPanel;
    public GameObject ThursdayPanel;
    public GameObject FridayPanel;
    public GameObject SaturdayPanel;
    public GameObject SundayPanel;

    public GameObject UpdateWindow;

    public GameObject OwnStatsPanel;

    public static short PanelDay;

    public Image BGImage;


    GameScript game;
    private string TodaysDay;
    // Start is called before the first frame update
    void Start()
    {
        game = GetComponent<GameScript>();

        StartCoroutine("CheckForUpdate");

        if(game.Name == "New Player")
        {
            NamePanel.SetActive(true);
        }
        else
        {
            Destroy(NamePanel);
        }
        if(game.FirstUse == true)
        {
            FirstUsePanel.SetActive(true);
        }
        else
        {
            Destroy(FirstUsePanel);
        }

        TodaysDay = DateTime.Now.DayOfWeek.ToString();
        switch (TodaysDay)
        {
            case "Monday":
                MondayButton.interactable = false;
                break;
            case "Tuesday":
                TuesdayButton.interactable = false;
                break;
            case "Wednesday":
                WednsdayButton.interactable = false;
                break;
            case "Thursday":
                ThursdayButton.interactable = false;
                break;
            case "Friday":
                FridayButton.interactable = false;
                break;
            case "Saturday":
                SaturdayButton.interactable = false;
                break;
            case "Sunday":
                SundayButton.interactable = false;
                break;
        }
    }

    private void OnApplicationPause(bool pause)
    {
        BGImage.color = Color.gray;
    }
    private void OnApplicationFocus(bool focus)
    {
        BGImage.color = new Color32(0, 0, 0, 200);
    }

    private void OnApplicationQuit()
    {
        
    }

    public void ClosePanel()
    {
        MondayPanel.SetActive(false);
        TuesdayPanel.SetActive(false);
        WednsdayPanel.SetActive(false);
        ThursdayPanel.SetActive(false);
        FridayPanel.SetActive(false);
        SaturdayPanel.SetActive(false);
        SundayPanel.SetActive(false);
        OwnStatsPanel.SetActive(false);
    }
    public void Monday()
    {
        PanelDay = 1;
        MondayPanel.SetActive(true);
        TuesdayPanel.SetActive(false);
        WednsdayPanel.SetActive(false);
        ThursdayPanel.SetActive(false);
        FridayPanel.SetActive(false);
        SaturdayPanel.SetActive(false);
        SundayPanel.SetActive(false);
    }
    public void Tuesday()
    {
        PanelDay = 2;
        MondayPanel.SetActive(false);
        TuesdayPanel.SetActive(true);
        WednsdayPanel.SetActive(false);
        ThursdayPanel.SetActive(false);
        FridayPanel.SetActive(false);
        SaturdayPanel.SetActive(false);
        SundayPanel.SetActive(false);
    }
    public void Wednesday()
    {
        PanelDay = 3;
        MondayPanel.SetActive(false);
        TuesdayPanel.SetActive(false);
        WednsdayPanel.SetActive(true);
        ThursdayPanel.SetActive(false);
        FridayPanel.SetActive(false);
        SaturdayPanel.SetActive(false);
        SundayPanel.SetActive(false);
    }
    public void Thursday()
    {
        PanelDay = 4;
        MondayPanel.SetActive(false);
        TuesdayPanel.SetActive(false);
        WednsdayPanel.SetActive(false);
        ThursdayPanel.SetActive(true);
        FridayPanel.SetActive(false);
        SaturdayPanel.SetActive(false);
        SundayPanel.SetActive(false);
    }
    public void Friday()
    {
        PanelDay = 5;
        MondayPanel.SetActive(false);
        TuesdayPanel.SetActive(false);
        WednsdayPanel.SetActive(false);
        ThursdayPanel.SetActive(false);
        FridayPanel.SetActive(true);
        SaturdayPanel.SetActive(false);
        SundayPanel.SetActive(false);
    }
    public void Saturday()
    {
        PanelDay = 6;
        MondayPanel.SetActive(false);
        TuesdayPanel.SetActive(false);
        WednsdayPanel.SetActive(false);
        ThursdayPanel.SetActive(false);
        FridayPanel.SetActive(false);
        SaturdayPanel.SetActive(true);
        SundayPanel.SetActive(false);
    }
    public void Sunday()
    {
        PanelDay = 7;
        MondayPanel.SetActive(false);
        TuesdayPanel.SetActive(false);
        WednsdayPanel.SetActive(false);
        ThursdayPanel.SetActive(false);
        FridayPanel.SetActive(false);
        SaturdayPanel.SetActive(false);
        SundayPanel.SetActive(true);
    }
    public void OwnStats()
    {
        PanelDay = 7;
        MondayPanel.SetActive(false);
        TuesdayPanel.SetActive(false);
        WednsdayPanel.SetActive(false);
        ThursdayPanel.SetActive(false);
        FridayPanel.SetActive(false);
        SaturdayPanel.SetActive(false);
        SundayPanel.SetActive(false);
        OwnStatsPanel.SetActive(true);
    }

    public void Online()
    {
        SceneManager.LoadScene("Online Scene");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings Scene");
    }
    IEnumerator CheckForUpdate()
    {
        //access leaderboard and download usernames and levels
        WWW www = new WWW(WebURL + UpdatePublicCode + "/pipe/");
        yield return www;
        //debug log
        if (string.IsNullOrEmpty(www.error))
        {
            FormatUpdates(www.text);
        }
        else
        {
            print("error: " + www.error);
        }
    }

    //organize usernames and levels into readable list
    void FormatUpdates(string textStream)
    {
        //string array being filled by leaderboard information
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        updateList = new Updates[entries.Length];

        if (updateList.Length > 1) //When updating change this number +1
        {
            UpdateWindow.SetActive(true);
        }
    }

    public struct Updates
    {
        public string username;
        public int score;

        public Updates(string _username, int _score)
        {
            username = _username;
            score = _score;
        }
    }

    public void OpenItchio()
    {
        Application.OpenURL("https://opendoresgaming.itch.io/wam-apex-tracker");
    }

    public void CloseUpdatePanel()
    {
        UpdateWindow.SetActive(false);
    }

}
