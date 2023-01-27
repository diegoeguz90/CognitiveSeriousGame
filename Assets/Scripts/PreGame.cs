using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PreGame : MonoBehaviour
{

    [SerializeField] float waitTime = 5.0f;
    // this is the event
    public delegate void TimeOut();
    public static event TimeOut OnTimeOut;
    private void Start()
    {
        GameManager.Instance.initalPos = 
            GameManager.Shuffle(GameManager.Instance.initalPos);
        GameManager.Instance.SetGrabablesPos(GameManager.Instance.initalPos);
        GameManager.Instance.finalPos = GameManager.Instance.initalPos;
        StartCoroutine("CountDown");
    }
    IEnumerator CountDown()
    {
        while (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            GameManager.Instance.SetMessageOnScene("Remember the initial position: " + waitTime.ToString("F0"));
            yield return null;
        }
        yield return new WaitForSeconds(0.3f);
        OnTimeOut(); // raise the event
    }

    #region EventSuscription
    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }
    #endregion
}
