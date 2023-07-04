using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Netcode.Transports.UTP;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.Events;

public class LoginManager : MonoBehaviour
{
    // Singleton
    public static LoginManager _instance;
    public static LoginManager Instance => _instance;

    String message; 

    private void Awake()
    {
        // Singleton
        if (_instance is null)
        {
            _instance = this;
            return;
        }

        Destroy(this);
    }

    async void Start()
    {
        // Initialize unity services
        await UnityServices.InitializeAsync();

        // Setup events listeners
        SetupEvents();

        // Unity Login
        await SignInAnonymouslyAsync();
    }

    void SetupEvents()
    {
        AuthenticationService.Instance.SignedIn += () => {
            // Shows how to get a playerID
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");
            message = $"PlayerID: {AuthenticationService.Instance.PlayerId}";

            // Shows how to get an access token
            Debug.Log($"Access Token: {AuthenticationService.Instance.AccessToken}");
        };

        AuthenticationService.Instance.SignInFailed += (err) => {
            Debug.LogError(err);
        };

        AuthenticationService.Instance.SignedOut += () => {
            Debug.Log("Player signed out.");
        };
    }

    async Task SignInAnonymouslyAsync()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            Debug.Log("Sign in anonymously succeeded!");
            message = message + "\nSign in anonymously succeeded!";
            UIManager._instance.TerminalMessage("Terminal", message);
        }
        catch (Exception ex)
        {
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
    }
}
