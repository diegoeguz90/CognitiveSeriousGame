using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWelcome : MonoBehaviour
{
    float waitTime = 3.0f;
    // this is the event
    public delegate void TimeOut();
    public static event TimeOut OnTimeOut;
    // Start is called before the first frame update
    void Start()
    {
        BeginTutorial();
    }
    void BeginTutorial()
    {
        TutorialManager.Instance.DisableTask();
        StartCoroutine("CountDown");
    }
    IEnumerator CountDown()
    {
        while (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            string title = "¡Bienvenido al tutorial!";
            string content = "En este tutorial aprenderas a interactuar " +
                "con la realidad virtual mientras utilizas el Meta Quest 2. " +
                "Iniciamos en: " + waitTime.ToString("F0");
            TutorialManager.Instance.SetDialogMessage(title, content);
            yield return null;
        }
        yield return new WaitForSeconds(0.3f);
        OnTimeOut(); // raise the event
    }
}
