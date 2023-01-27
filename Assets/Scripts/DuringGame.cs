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
        GameManager.Instance.finalPos = 
            GameManager.Shuffle(GameManager.Instance.initalPos);
        GameManager.Instance.SetGrabablesPos(GameManager.Instance.finalPos);
        StartCoroutine("CountDown");
    }
    IEnumerator CountDown()
    {
        while (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            GameManager.Instance.SetMessageOnScene("Limit time: " + waitTime.ToString("F0"));
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
