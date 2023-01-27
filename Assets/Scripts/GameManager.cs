using Oculus.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // singleton instance
    public static GameManager Instance { get; private set; }
    // cache variables
    public GameObject[] grabables;
    // variables
    public Vector3[] initalPos, finalPos, userPos;
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

        grabables = GameObject.FindGameObjectsWithTag("Grabable");
        initalPos = new Vector3[grabables.Length];
        finalPos = new Vector3[grabables.Length];
        userPos = new Vector3[grabables.Length];
        SetInitialPos();
    }
    private void SetInitialPos()
    {
        for(int i=0; i < grabables.Length; i++)
        {
            this.initalPos[i] = this.grabables[i].transform.position;
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
    public Vector3[] GetGrabablesPos()
    {
        Vector3[] grabablesPos = new Vector3[this.grabables.Length];
        for(int i=0; i < this.grabables.Length; i++)
        {
            grabablesPos[i] = this.grabables[i].transform.position;
        }
        return grabablesPos;
    }
    public static Vector3[] Shuffle(Vector3[] myVector3)
    {
        int nVector3 = myVector3.Length;
        System.Random _random = new System.Random();
        for(int i = nVector3 - 1; i > 0; i--)
        {
            int randomIndex = _random.Next(0, i);
            Vector3 temp = myVector3[randomIndex];
            myVector3[randomIndex] = myVector3[i];
            myVector3[i] = temp;
        }
        return myVector3;
    }
}
