using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject treasureText;
    static int treasureNum = 0;

    public static int TreasureNum
    {
        get
        {
            return treasureNum;
        }
        set
        {
            treasureNum = value;
        }
    }

    void Start()
    {
        this.treasureText = GameObject.Find("TreasureNum");
    }

    void Update()
    {
        this.treasureText.GetComponent<Text>().text =
             "× " + treasureNum.ToString();
    }

    public static void CountTreasure()
    {
        treasureNum ++;
    }
}
