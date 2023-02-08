using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    private void Start()
    {
        ShowMenu();
    }
    void ShowMenu()
    {
        TutorialManager.Instance.DisableTask();
        TutorialManager.Instance.EnableMenu();
        string title = "¡Presiona los botones!";
        string content = "Para que ocurra algo, debes extender tus manos " +
            "hasta verlas. Presiona el boton rojo para salir ó " +
            "presiona el boton verde para continuar";
        TutorialManager.Instance.SetDialogMessage(title, content);
    }

    #region EventSuscription
    private void OnEnable()
    {
        TutorialTask.OnTaskFinish += ShowMenu;
    }
    private void OnDisable()
    {
        TutorialTask.OnTaskFinish -= ShowMenu;
    }
    #endregion
}
