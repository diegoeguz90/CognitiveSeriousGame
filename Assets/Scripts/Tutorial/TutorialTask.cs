using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static BoxTrigger;

public class TutorialTask : MonoBehaviour
{
    public void StartTask()
    {
        TutorialManager.Instance.EnableTask();
        string title = "¡Interactua con los objetos!";
        string content = "Hay objetos que al pasar la mano sobre ellos " +
            "veras que cambian de color, estos objetos puedes cogerlos " +
            "con tus manos y moverlos hacia cualquier parte. Tu tarea consiste " +
            "en meterlo en la caja";
        TutorialManager.Instance.SetDialogMessage(title, content);
    }
    void InteractableTrigger()
    {
        StartCoroutine("CountDown");
    }
    IEnumerator CountDown()
    {
        string title = "¡Bien hecho!";
        string content = "Haz realizado satisfactoriamente la tarea, con " +
            "esto has terminado el tutorial, en 3 segundos volveremos al " +
            "inicio.";
        TutorialManager.Instance.SetDialogMessage(title, content);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }

    #region EventSuscription
    private void OnEnable()
    {
        TutorialWelcome.OnTimeOut += StartTask;
        BoxTrigger.OnBoxTrigger += InteractableTrigger;
    }
    private void OnDisable()
    {
        TutorialWelcome.OnTimeOut -= StartTask;
        BoxTrigger.OnBoxTrigger -= InteractableTrigger;
    }
    #endregion
}
