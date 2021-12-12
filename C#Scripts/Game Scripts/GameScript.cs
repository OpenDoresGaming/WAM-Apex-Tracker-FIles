using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameScript : MonoBehaviour
{
    public bool FirstUse;

    public float MondayWins;
    public float TuesdayWins;
    public float WednsdayWins;
    public float ThursdayWins;
    public float FridayWins;
    public float SaturdayWins;
    public float SundayWins;
           
    public float MondayKills;
    public float TuesdayKills;
    public float WednsdayKills;
    public float ThursdayKills;
    public float FridayKills;
    public float SaturdayKills;
    public float SundayKills;
           
    public float MondayGP;
    public float TuesdayGP;
    public float WednsdayGP;
    public float ThursdayGP;
    public float FridayGP;
    public float SaturdayGP;
    public float SundayGP;
    public string Mondate;
    public string Name;

    public float LifetimeGames;
    public float LifetimeKills;
    public float LifetimeWins;

    public string WeeklyKillsPublicCode;
    public string WeeklyKillsPrivateCode;

    public string WeeklyGamesPublicCode;
    public string WeeklyGamesPrivateCode;

    public string WeeklyWinsPublicCode;
    public string WeeklyWinsPrivateCode;

    public string TournamentPublicCode;
    public string TournamentPrivateCode;

    public KeyCode GameInputKey;
    public KeyCode KillInputKey;
    public KeyCode WinInputKey;

    private void Awake()
    {
        LoadGame();
    }
    
    public void LoadGame()
    {
        GameData data = SaveSystemGame.LoadGame();

        FirstUse = data.FirstUse;

        MondayWins = data.MondayWins;
        TuesdayWins = data.TuesdayWins;
        WednsdayWins = data.WednsdayWins;
        ThursdayWins = data.ThursdayWins;
        FridayWins = data.FridayWins;
        SaturdayWins = data.SaturdayWins;
        SundayWins = data.SundayWins;

        MondayGP = data.MondayGP;
        TuesdayGP = data.TuesdayGP;
        WednsdayGP = data.WednsdayGP;
        ThursdayGP = data.ThursdayGP;
        FridayGP = data.FridayGP;
        SaturdayGP = data.SaturdayGP;
        SundayGP = data.SundayGP;

        MondayKills = data.MondayKills;
        TuesdayKills = data.TuesdayKills;
        WednsdayKills = data.WednsdayKills;
        ThursdayKills = data.ThursdayKills;
        FridayKills = data.FridayKills;
        SaturdayKills = data.SaturdayKills;
        SundayKills = data.SundayKills;
        Mondate = data.Mondate;
        Name = data.Name;
        LifetimeGames = data.LifetimeGames;
        LifetimeKills = data.LifetimeKills;
        LifetimeWins = data.LifetimeWins;

        WeeklyKillsPublicCode = data.WeeklyKillsPublicCode;
        WeeklyKillsPrivateCode = data.WeeklyKillsPrivateCode;
        WeeklyGamesPublicCode = data.WeeklyGamesPublicCode;
        WeeklyGamesPrivateCode = data.WeeklyGamesPrivateCode;
        WeeklyWinsPublicCode = data.WeeklyWinsPublicCode;
        WeeklyWinsPrivateCode = data.WeeklyWinsPrivateCode;
        TournamentPublicCode = data.TournamentPublicCode;
        TournamentPrivateCode = data.TournamentPrivateCode;

        GameInputKey = data.GameInputKey;
        KillInputKey = data.KillInputKey;
        WinInputKey = data.WinInputKey;
    }
}
