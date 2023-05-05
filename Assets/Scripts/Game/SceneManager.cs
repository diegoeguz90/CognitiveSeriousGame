using Oculus.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
// libraries for access to UI objects
using UnityEngine.UI;
using TMPro;

public class SceneManager : MonoBehaviour
{
    // singleton instance
    public static SceneManager Instance { get; private set; }
    // cache variables
    [SerializeField] TMP_Text titleOnScene, contentOnScene;
    public GameObject[] grabables;
    // variables
    public Vector3[] initialPos, finalPos, userPos;
    // awake
    private void Awake()
    {
        // if there is an instance, and it's not me, delete myself
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 90;

        grabables = GameObject.FindGameObjectsWithTag("Grabable");
        initialPos = new Vector3[grabables.Length];
        finalPos = new Vector3[grabables.Length];
        userPos = new Vector3[grabables.Length];
        SetInitialPos();
    }
    private void SetInitialPos()
    {
        for(int i=0; i < grabables.Length; i++)
        {
            this.initialPos[i] = this.grabables[i].transform.position;
            this.finalPos[i] = this.initialPos[i];
        }
    }
    public void SetGrabablesPos(Vector3[] vectorIn)
    {
        int n = vectorIn.Length;
        for (int i =0; i<n; i++)
        {
             this.grabables[i].transform.position = vectorIn[i];
        }
    }
    public void GetUserPos()
    {
        Vector3[] grabablesPos = new Vector3[this.grabables.Length];
        for(int i=0; i < this.grabables.Length; i++)
        {
            this.userPos[i] = this.grabables[i].transform.position;
        }
    }
    public void ShuffleInitialPos()
    {
        int nVector3 = initialPos.Length;
        System.Random _random = new System.Random();
        for(int i = nVector3 - 1; i > 0; i--)
        {
            int randomIndex = _random.Next(0, i);
            Vector3 temp = initialPos[randomIndex];
            initialPos[randomIndex] = initialPos[i];
            initialPos[i] = temp;
        }
    }
    public void ShuffleFinalPos()
    {
        int nVector3 = finalPos.Length;
        System.Random _random = new System.Random();
        for (int i = nVector3 - 1; i > 0; i--)
        {
            int randomIndex = _random.Next(0, i);
            Vector3 temp = finalPos[randomIndex];
            finalPos[randomIndex] = finalPos[i];
            finalPos[i] = temp;
        }
    }
    public void FinalPosEqualsInitialPos()
    {
        for(int i=0; i<this.grabables.Length; i++)
        {
            this.finalPos[i] = this.initialPos[i];
        }
    }
    public int CalculateScore()
    {
        int score = 0;
        for(int i=0; i < this.grabables.Length; i++)
        {
            if (this.userPos[i] == this.initialPos[i])
                score++;
        }
        return score;
    }
    public void SetMessageOnDialogScreen(string title, string content)
    {
        this.titleOnScene.text = title;
        this.contentOnScene.text = content;
    }
}
