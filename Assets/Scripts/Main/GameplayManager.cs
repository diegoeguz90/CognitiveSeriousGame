using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager _instance;
    public static GameplayManager Instance => _instance;

    // set and get for score
    private int score;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    private void Awake()
    {
        // Just a basic singleton
        if (_instance is null)
        {
            _instance = this;
            return;
        }

        Destroy(this);
    }

    public void UpScore()
    {
        Score++;
        UIManager._instance.TerminalMessage("New score: ", Score.ToString());
    }

    public void DownScore() 
    { 
        Score--;
        UIManager._instance.TerminalMessage("New score: ", Score.ToString());
    }
}
