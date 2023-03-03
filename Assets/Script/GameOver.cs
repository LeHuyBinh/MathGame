using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Button btnRetry;
    public Text txtScore;
    // Start is called before the first frame update
   public void GameOverPopup(int point)
    {
        gameObject.SetActive(true);
        txtScore.text = "SCORE: " + point.ToString();
    }

    private void Start()
    {
        btnRetry.onClick.AddListener(HandleRetry);
    }

    private void HandleRetry()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
    }
}
