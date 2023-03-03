using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{

    public Text txtResult;
    public Button btn;
    public bool isTrue = false;
    public int score;
    //Spawner ten = Spawner.instance;
    GameMaster gameMaster = GameMaster.instance;

    private void Start()
    {
        btn.onClick.AddListener(HandleClick);
    }

    private void HandleClick()
    {
        Debug.Log("RIGHT");
        if (this.isTrue)
        {
            this.isTrue = false;
            Quest topQuest = gameMaster.spawner.listEq[gameMaster.topIndex];

            topQuest.GetComponent<Image>().color = gameMaster.green; // mau xanh

            gameMaster.topIndex++;
            if (gameMaster.topIndex >= gameMaster.spawner.listEq.Count)
            {
                gameMaster.topIndex = 0;
            }
            gameMaster.ansSpawner.setNewAnswer(gameMaster.spawner.listEq[gameMaster.topIndex].result);
            topQuest.isCheck = true;
            score = gameMaster.totalScore + 1;

            Debug.Log(score);
            gameMaster.AddScore(score);
        }
        else // wrong case
        {
            Quest topQuest = gameMaster.spawner.listEq[gameMaster.topIndex];

            topQuest.GetComponent<Image>().color = gameMaster.red; // mau do
            Debug.Log("" + topQuest.mathProblem.text.ToString() + "   +" + txtResult.text.ToString());

            gameMaster.topIndex++;
            if (gameMaster.topIndex >= gameMaster.spawner.listEq.Count)
            {
                gameMaster.topIndex = 0;
            }
            gameMaster.ansSpawner.setNewAnswer(gameMaster.spawner.listEq[gameMaster.topIndex].result);
            topQuest.isCheck = true;
            gameMaster.life.loseHeart();
        }
    }

    public void SetText(int result)
    {
        txtResult.text = result.ToString();
    }

}
