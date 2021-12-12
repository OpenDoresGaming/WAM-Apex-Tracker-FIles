using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstUseScript : MonoBehaviour
{

    public GameObject TextPanel1;
    public GameObject FirstUsePanel;
    public GameObject canvas;

    GameScript game;
    // Start is called before the first frame update
    void Start()
    {
        game = canvas.GetComponent<GameScript>();

    }
    public void FirstUsePanelOff()
    {
        Destroy(FirstUsePanel);
        game.FirstUse = false;
        SaveSystemGame.SaveGame(game);
    }

    public void LoadApexGG()
    {
        Application.OpenURL("https://apex.tracker.gg/");
    }
}
