using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager _instance;

    [SerializeField] TMP_Text TerminalTitle;
    [SerializeField] TMP_Text TerminalContent;
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

    public void TerminalMessage(string title, string content)
    {
        TerminalTitle.text = title;
        TerminalContent.text = content;
    }
}
