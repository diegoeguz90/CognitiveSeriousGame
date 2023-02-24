using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuringGame : MonoBehaviour
{
    [SerializeField] float waitTime = 60.0f;
    // this is the event
    public delegate void TimeOut();
    public static event TimeOut OnTimeOut;

    void PlayTheGame()
    {
        GameManager.Instance.FinalPosEqualsInitialPos();
        GameManager.Instance.ShuffleFinalPos();
        GameManager.Instance.SetGrabablesPos(GameManager.Instance.finalPos);
        StartCoroutine("CountDown");
    }
    IEnumerator CountDown()
    {
        while (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            GameManager.Instance.SetMessageOnDialogScreen("Tiempo limite: " + 
                waitTime.ToString("F0"), "Rápido tienes que coger los objetos " +
                "con un agarre de pinza y llevarlos a la ubicación inicial");
            yield return null;
        }
        yield return new WaitForSeconds(0.3f);
        OnTimeOut(); // raise the event
    }

    #region EventSuscription
    private void OnEnable()
    {
        PreGame.OnTimeOut += PlayTheGame;
    }
    private void OnDisable()
    {
        PreGame.OnTimeOut -= PlayTheGame;
    }
    #endregion
}
