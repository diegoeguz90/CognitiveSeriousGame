using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostGame : MonoBehaviour
{
    void CaculateScore()
    {
        Debug.Log("Showing score");
    }

    #region EventSuscription
    private void OnEnable()
    {
        DuringGame.OnTimeOut += CaculateScore;
    }
    private void OnDisable()
    {
        DuringGame.OnTimeOut -= CaculateScore;
    }
    #endregion
}
