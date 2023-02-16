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
        GameManager.Instance.ShuffleInitialPos();
        GameManager.Instance.SetGrabablesPos(GameManager.Instance.initialPos);

        StartCoroutine("CountDown");
    }
    IEnumerator CountDown()
    {
        while (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            GameManager.Instance.SetMessageOnDialogScreen("¡Hola! Pon atención", "Debes memorizar la ubicación de los objetos, tiempo limite: " + waitTime.ToString("F0"));
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
