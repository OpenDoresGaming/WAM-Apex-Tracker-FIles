using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCodesScript : MonoBehaviour
{
    public InputField WeeklyKillsPublicInputField;
    public InputField WeeklyKillsPrivateInputField;

    public InputField WeeklyGamesPublicInputField;
    public InputField WeeklyGamesPrivateInputField;

    public InputField WeeklyWinsPublicInputField;
    public InputField WeeklyWinsPrivateInputField;

    public InputField TournamentsPublicInputField;
    public InputField TournamentsPrivateInputField;

    GameScript game;

    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        game = canvas.GetComponent<GameScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWeeklyKillsPublic(string _name)
    {
        //add random 4 digit number to username for uniqueness
        game.WeeklyKillsPublicCode = WeeklyKillsPublicInputField.text;

        //save player
        SaveSystemGame.SaveGame(game);
    }

    public void SetWeeklyKillsPrivate(string _name)
    {
        //add random 4 digit number to username for uniqueness
        game.WeeklyKillsPrivateCode = WeeklyKillsPrivateInputField.text;

        //save player
        SaveSystemGame.SaveGame(game);
    }

    public void SetWeeklyGamesPublic(string _name)
    {
        //add random 4 digit number to username for uniqueness
        game.WeeklyGamesPublicCode = WeeklyGamesPublicInputField.text;

        //save player
        SaveSystemGame.SaveGame(game);
    }
    public void SetWeeklyGamesPrivate(string _name)
    {
        //add random 4 digit number to username for uniqueness
        game.WeeklyGamesPrivateCode = WeeklyGamesPrivateInputField.text;

        //save player
        SaveSystemGame.SaveGame(game);
    }

    public void SetWeeklyWinsPublic(string _name)
    {
        //add random 4 digit number to username for uniqueness
        game.WeeklyWinsPublicCode = WeeklyWinsPublicInputField.text;

        //save player
        SaveSystemGame.SaveGame(game);
    }

    public void SetWeeklyWinsPrivate(string _name)
    {
        //add random 4 digit number to username for uniqueness
        game.WeeklyWinsPrivateCode = WeeklyWinsPrivateInputField.text;

        //save player
        SaveSystemGame.SaveGame(game);
    }

    public void SetTournamentsPublic(string _name)
    {
        //add random 4 digit number to username for uniqueness
        game.TournamentPublicCode = TournamentsPublicInputField.text;

        //save player
        SaveSystemGame.SaveGame(game);
    }

    public void SetTournamentsPrivate(string _name)
    {
        //add random 4 digit number to username for uniqueness
        game.TournamentPrivateCode = TournamentsPrivateInputField.text;

        //save player
        SaveSystemGame.SaveGame(game);
    }
}
