using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    public Quest equation;
    public List<Quest> listEq = new List<Quest>();


    public void SpawnQuest()
    {
        int index = 0;
        for (int i = 0; i < 2; i++)
        {
            foreach (Transform tr in transform)
            {
                Quest quest = Instantiate(equation, tr.position, Quaternion.identity);
                quest.gameObject.transform.parent = tr;
                var result = quest.GenEquation();
                index++;
                Debug.LogError("QuestResult: " + result);
                //quest.isOnTop = true;
                quest.transform.gameObject.SetActive(false);
                listEq.Add(quest);
            }
        }
    }

    //private void Freeze()
    //{
    //    StartCoroutine(pausegame());
    //}

    //IEnumerator pausegame()
    //{
    //    Time.timeScale = 0.1f;
    //    yield return new WaitForSeconds(0.5f);
    //    Time.timeScale = 1;
    //}

}
