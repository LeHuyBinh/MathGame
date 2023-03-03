using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{

    [SerializeField] public Text mathProblem;

    public int num1;
    public int num2;
    public int result;
    public bool isCheck = false;
    public float speed = 50f;
    public float increaseDifficult = 15f;

    private int startPos = 760;
    private int endPos = -580;

    GameMaster gameMaster = GameMaster.instance;


    //private void Start()
    //{
    //    GenEquation();
    //}

    private void Update()
    {
        //increaseDifficult -= Time.deltaTime;
        //if (increaseDifficult < 0)
        //{
        //    speed = 1.3f * speed;
        //    increaseDifficult = 15f;
        //}
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        

        if (transform.localPosition.y < endPos)
        {
            if (!this.isCheck)
            {
                Debug.LogWarning("here");
                gameMaster.life.loseHeart();
                gameMaster.topIndex++;
                //Debug.LogError(gameMaster.spawner.listEq[gameMaster.topIndex].result + " + " + gameMaster.topIndex);
                gameMaster.ansSpawner.setNewAnswer(gameMaster.spawner.listEq[gameMaster.topIndex].result);
            }
            transform.Translate(Vector3.up * startPos);
            transform.gameObject.SetActive(false);
            transform.GetComponent<Image>().color = Color.black;
            //isOnTop = false;
            GenEquation();
            this.isCheck = false;

            //gameMaster.spawner.ansSpawner.SpawnAnswer(result);
        }
    }
    public void SetText(string equation)
    {
        mathProblem.text = equation;
    }

    public int GenEquation()
    {
        string tempEq = "";
        num1 = gameMaster.GenRndNum(1f, 10f);
        num2 = gameMaster.GenRndNum(1f, 10f);


        if ((UnityEngine.Random.Range(0f, 1f)) >= 0.5f)
        {
            tempEq = "" + num1 + " + " + num2;
            result = num1 + num2;
            SetText(num1 + " + " + num2);
            //Debug.LogError("Addition Result: " + result);
        }
        else
        {
            if (num1 > num2)
            {
                //tempEq = "" + num1 + " - " + num2;
                result = num1 - num2;
                SetText(num1 + " - " + num2);
            }
            else
            {
                //tempEq = "" + num2 + " - " + num1;
                result = num2 - num1;
                SetText(num2 + " - " + num1);
            }
            //Debug.LogError("Substraction Result: " + result);
        }
        //Debug.LogError("EQ: " + tempEq + "   " + result);
        return result;
    }

    public int getResult()
    {
        return result;
    }

}
