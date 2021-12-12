using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetNameScript : MonoBehaviour
{

    //input field to enter usenrame
    public InputField NameField;

    //button to confirm new name
    public Button NameConfirmButton;


    //canvas holding referenced scripts
    public GameObject NamePanel;


    //referenced script
    GameScript game;

    // Start is called before the first frame update
    void Start()
    {
        //get referenced script
        game = GetComponent<GameScript>();

        //check if player name has been se

        //limit username length
        NameField.characterLimit = 10;
    }



    //set the players username
    public void SetUsername(string _name)
    {
        //add random 4 digit number to username for uniqueness
        game.Name = NameField.text;

        //save player
        SaveSystemGame.SaveGame(game);
    }

    //turn off input container and turn on start button
    public void ConfirmButton()
    {
        if (!string.IsNullOrEmpty(NameField.text))
        {
            Destroy(NamePanel);
        }
        else if (string.IsNullOrEmpty(NameField.text))
        {
            NameConfirmButton.interactable = false;
        }
    }
}
