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
        SceneManager.Instance.GetUserPos();
        int score = SceneManager.Instance.CalculateScore();
        SceneManager.Instance.SetMessageOnDialogScreen("Lograste organizar: "
            + score + "/" + SceneManager.Instance.grabables.Length,"");
        StartCoroutine("CountDown");
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(waitTime);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
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
