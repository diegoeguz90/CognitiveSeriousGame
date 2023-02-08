using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] TMP_Text titleDialog;
    [SerializeField] TMP_Text descriptionDialog;
    [SerializeField] GameObject TutorialMenu;
    [SerializeField] GameObject TutorialTask;
    [SerializeField] GameObject SphereInteractable; 

    // singleton instance
    public static TutorialManager Instance { get; private set; }
    private void Awake()
    {
        // if there is an instance, and it's not me, delete myself
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public void SetDialogMessage(string title, string content)
    {
        titleDialog.text = title;
        descriptionDialog.text = content;
    }
    public void FinishTutorial()
    {
        Application.Quit();
    }
    public void EnableMenu()
    {
        TutorialMenu.SetActive(true);
    }
    public void DisableMenu()
    {
        TutorialMenu.SetActive(false);
    }
    public void EnableTask()
    {
        TutorialTask.SetActive(true);
    }
    public void DisableTask()
    {
        TutorialTask.SetActive(false);
    }
}
