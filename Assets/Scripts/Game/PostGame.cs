using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PostGame : MonoBehaviour
{
    [SerializeField] float waitTime = 5;
    void CaculateScore()
    {
        GameManager.Instance.GetUserPos();
        int score = GameManager.Instance.CalculateScore();
        GameManager.Instance.SetMessageOnDialogScreen("Lograste organizar: "
            + score + "/" + GameManager.Instance.grabables.Length,"");
        StartCoroutine("CountDown");
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Menu");
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
