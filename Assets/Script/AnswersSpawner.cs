using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswersSpawner : MonoBehaviour
{
    [SerializeField] private int result;

    public Answer resultEq;
    
    private List<Answer> listAns = new List<Answer>();

    public void SpawnAnswer(int result)
    {
        foreach (Transform tr in transform)
        {
            Answer answer = Instantiate(resultEq, tr.position, Quaternion.identity);
            listAns.Add(answer);
            answer.gameObject.transform.parent = tr;
        }
        setNewAnswer(result);
    }
    public void setNewAnswer(int result)
    {

        foreach (Answer ans in listAns)
        {
            ans.SetText(GameMaster.instance.GenRndNum(1f, 20f,result));
            ans.isTrue = false;
        }

        var index = GameMaster.instance.GenRndNum(0f, 2.0f);
        listAns[index].SetText(result);
        listAns[index].isTrue = true;
    }
}
