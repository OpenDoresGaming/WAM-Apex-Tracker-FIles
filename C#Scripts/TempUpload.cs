using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class TempUpload : MonoBehaviour
{
    //leaderboard can be found here (https://dreamlo.com/lb/yFWY8WGdwUOkk6gBCes41wwx3arDBnGkeaGxVjcLLnRQ)
    const string PrivateCode = "yFWY8WGdwUOkk6gBCes41wwx3arDBnGkeaGxVjcLLnRQ";
    const string PublicCode = "619f6be88f40bb127882946e";
    const string WebURL = "http://dreamlo.com/lb/";
    // Start is called before the first frame update

    public string Username = "Andy";
    public int Score = 40;
    void Start()
    {
        UploadNewDay(Username, Score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UploadNewDay(string username, int day)
    {
        StartCoroutine(AddnewDay(username, day));
    }

    IEnumerator AddnewDay(string username, int day)
    {

            //Connect to leaderboard and upload username and highest level
           WWW www = new WWW(WebURL + PrivateCode + "/add/" + WWW.EscapeURL(username) + "/" + day);
            yield return www;

            //debug prints
            if (string.IsNullOrEmpty(www.error))
            {
                print("upload successfull " + username + " " + day);
            }
            else
            {
                print("error: " + www.error);
            }
        
    }
}
