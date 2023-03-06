using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public Heart heartIcon;

    public List<Heart> listHeart = new List<Heart>();

    public int heartCnt = 3;
    public int heartIndex = 0;
    public bool isOver = false;

    public void SpawnHeart()
    {
        for (int i = 0; i < heartCnt; i++)
        {
            var heart = Instantiate(heartIcon);
            heart.transform.SetParent(this.transform);
            heart.gameObject.SetActive(true);
            listHeart.Add(heart);
        }
    }

    // Update is called once per frame
    public void LoseHeart()
    {
        Debug.LogError("LoseHeart");
        listHeart[heartIndex].gameObject.SetActive(false);
        heartIndex++;
        if (heartIndex >= heartCnt)
        {
            heartIndex = 0;
            isOver = true;
        }
        
    }
}
