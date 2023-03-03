using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;

    public Spawner spawner;
    public AnswersSpawner ansSpawner;
    public LifeSystem life;
    public GameOver gameOver;
    public Text txtScore;

    public Button freeze;

    public Color32 green = new Color32(52, 235, 58, 255);
    public Color32 red = new Color32(235, 64, 52, 255);

    public float time = 2f;
    public float increaseDifficult = 5f;
    public int totalScore = 0;

    private int index = 0;
    public int topIndex = 0;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        spawner.SpawnQuest();
        ansSpawner.SpawnAnswer(spawner.listEq[0].result);
        life.SpawnHeart();
        AddScore(totalScore);
        freeze.onClick.AddListener(Freeze);
    }

    // Update is called once per frame
    void Update()
    {
        increaseDifficult -= Time.deltaTime;
        if (increaseDifficult < 0)
        {
            if (Time.timeScale < 5)
            {
                Time.timeScale *= 1.2f;
            }
            else
            {
                Time.timeScale = 5;
            }
            increaseDifficult = 5f;
        }


        time -= Time.deltaTime;

        if (time < 0)
        {
            spawner.listEq[index].transform.gameObject.SetActive(true);

            //listEq[index].isOnTop = true;

            index++;
            if (index >= spawner.listEq.Count)
            {
                index = 0;
            }
            time = 3f;
        }
        if (life.isOver)
        {
            //Time.timeScale = 0;
            gameOver.GameOverPopup(totalScore);
        }
    }

    public int GenRndNum(float from, float to)
    {
        return (int)Mathf.Round(UnityEngine.Random.Range(from, to));
    }

    public int GenRndNum(float from, float to, int except)
    {
        int temp = (int)Mathf.Round(UnityEngine.Random.Range(from, to));
        if (temp == except)
        {
            return temp + 1;
        }
        return temp;
    }
    public void AddScore(int score)
    {
        totalScore = score;
        txtScore.text = totalScore.ToString();
        //Debug.LogWarning("ttsc" + totalScore);
    }

    private void Freeze()
    {
        StartCoroutine(pausegame());
    }

    IEnumerator pausegame()
    {
        Time.timeScale = 0.001f;
        yield return new WaitForSeconds(0.005f);
        Time.timeScale = 1;
    }
}
