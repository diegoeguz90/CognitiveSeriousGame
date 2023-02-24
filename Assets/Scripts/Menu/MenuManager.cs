using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] TMP_Text titleDialog;
    [SerializeField] TMP_Text contentDialog;

    // singleton instance
    public static MenuManager Instance { get; private set; }
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
    private void Start()
    {
        titleDialog.text = "Bienvenido!";
        contentDialog.text = "Este el menu, para interacturar debes extender " +
            "tus manos, al presionar los botones frente a ti puedes: \n " +
            "1) Verde para ir al juego. \n " +
            "2) Amarillo para ir al tutorial. \n" +
            "3) Rojo para salir. ";
    }
    public void GoToGame()
    {
        SceneManager.LoadScene("MemoryMessGame");
    }
    public void GoToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
