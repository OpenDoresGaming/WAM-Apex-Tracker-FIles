using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{

    public bool FirstUse;
    //Blorp Attributes
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


    public GameData (GameScript game)
    {

        FirstUse = game.FirstUse;
        MondayWins = game.MondayWins;
        TuesdayWins = game.TuesdayWins;
        WednsdayWins = game.WednsdayWins;
        ThursdayWins = game.ThursdayWins;
        FridayWins = game.FridayWins;
        SaturdayWins = game.SaturdayWins;
        SundayWins = game.SundayWins;

        MondayGP = game.MondayGP;
        TuesdayGP = game.TuesdayGP;
        WednsdayGP = game.WednsdayGP;
        ThursdayGP = game.ThursdayGP;
        FridayGP = game.FridayGP;
        SaturdayGP = game.SaturdayGP;
        SundayGP = game.SundayGP;

        MondayKills = game.MondayKills;
        TuesdayKills = game.TuesdayKills;
        WednsdayKills = game.WednsdayKills;
        ThursdayKills = game.ThursdayKills;
        FridayKills = game.FridayKills;
        SaturdayKills = game.SaturdayKills;
        SundayKills = game.SundayKills;
        Mondate = game.Mondate;
        Name = game.Name;
        LifetimeGames = game.LifetimeGames;
        LifetimeKills = game.LifetimeKills;
        LifetimeWins = game.LifetimeWins;

        WeeklyKillsPublicCode = game.WeeklyKillsPublicCode;
        WeeklyKillsPrivateCode = game.WeeklyKillsPrivateCode;
        WeeklyGamesPublicCode = game.WeeklyGamesPublicCode;
        WeeklyGamesPrivateCode = game.WeeklyGamesPrivateCode;
        WeeklyWinsPublicCode = game.WeeklyWinsPublicCode;
        WeeklyWinsPrivateCode = game.WeeklyWinsPrivateCode;
        TournamentPublicCode = game.TournamentPublicCode;
        TournamentPrivateCode = game.TournamentPrivateCode;

        GameInputKey = game.GameInputKey;
        KillInputKey = game.KillInputKey;
        WinInputKey = game.WinInputKey;
    }
    
} 


