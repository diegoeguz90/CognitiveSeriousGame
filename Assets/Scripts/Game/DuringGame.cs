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
        SceneManager.Instance.FinalPosEqualsInitialPos();
        SceneManager.Instance.ShuffleFinalPos();
        SceneManager.Instance.SetGrabablesPos(SceneManager.Instance.finalPos);
        StartCoroutine("CountDown");
    }
    IEnumerator CountDown()
    {
        while (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            SceneManager.Instance.SetMessageOnDialogScreen("Tiempo limite: " + 
                waitTime.ToString("F0"), "R?ido tienes que coger los objetos " +
                "con un agarre de pinza y llevarlos a la ubicaci? inicial");
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
