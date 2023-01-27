using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostGame : MonoBehaviour
{
    void CaculateScore()
    {
        GameManager.Instance.userPos = GameManager.Instance.GetGrabablesPos();
        int score = GameManager.Instance.CalculateScore();
        GameManager.Instance.SetMessageOnScene("The score is: " + score);
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
