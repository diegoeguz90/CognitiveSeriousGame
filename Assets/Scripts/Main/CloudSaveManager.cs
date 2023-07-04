using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using System;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using System.Threading.Tasks;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class CloudSaveManager : MonoBehaviour
{
    // Singleton
    public static CloudSaveManager _instance;
    public static CloudSaveManager Instance => _instance;

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

    public async void SaveDataCloud()
    {
        Debug.Log("Save to cloud!");
        UIManager._instance.TerminalMessage("Save to cloud!", "Score" + GameplayManager._instance.Score.ToString());

        var data = new Dictionary<string, object> { { "Score", GameplayManager._instance.Score } };

        await CloudSaveService.Instance.Data.ForceSaveAsync(data);
    }

    public async void LoadDataCloud()
    {
        Dictionary<string, string> savedData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { "MyKey" });

        Debug.Log("Done: " + savedData["MyKey"]);
    }

    public async void RetrieveKeys()
    {
        List<string> keys = await CloudSaveService.Instance.Data.RetrieveAllKeysAsync();

        for (int i = 0; i < keys.Count; i++)
        {
            Debug.Log(keys[i]);
        }
    }
}