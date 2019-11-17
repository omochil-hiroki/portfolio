using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultDirector : MonoBehaviour
{
    public void MoveToWorldScene()
    {
        SceneManager.LoadScene("WorldScene");
        GameDirector.TreasureNum = 0;
    }

    void Start()
    {
        GameObject numOfTreasure;
        numOfTreasure = GameObject.Find("TreasureNum");
        int num = GameDirector.TreasureNum;
        numOfTreasure.GetComponent<Text>().text = "宝箱" + num.ToString() + "個";
    }
}
