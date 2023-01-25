using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    // singleton instance
    public static GameHandler Instance { get; private set; }
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
    }
}
