using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    static float moveSpeedX = 0f;
    static float moveSpeedY = -2f;
    static float tempStopMoveX = 0f;     //一時停止時前の速度を保存
    static float tempStopMoveY = 0f;     //一時停止時前の速度を保存
    Rigidbody2D rb;
    static int stopFlag = 0;
    int speedFlag = 0;            //加速減速を管理
    bool right = false;           //右ボタンを押しているかの真偽値
    bool left = false;            //左ボタンを押しているかの真偽値
    float delta;
    float changeTime = 1f;

    static float positionX = 0;
    static float positionY = 4f;
    public static string sceneName;

    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        transform.position = new Vector3(positionX, positionY, 0);
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(moveSpeedX, moveSpeedY, 0);
    }

    void Update()
    {
        if (stopFlag == 0)
        {
            if (right)
            {
                GoRight();            //右に動かすためのメソッドを呼び出す
            }
            else if (left)
            {
                GoLeft();             //左に動かすためのメソッドを呼び出す
            }
            else
            {
                moveSpeedX = 0f;      //ボタンを押していない時
            }
            if (speedFlag == 1)
            {
                delta += Time.deltaTime;
                if (delta > changeTime)
                {
                    moveSpeedY = -speed;
                    speedFlag = 0;
                }
            }
        }
       rb.velocity = new Vector3(moveSpeedX, moveSpeedY, 0);
    }

    public static void StopButtonDown()
    {
        if (stopFlag == 0)
        {
            tempStopMoveX = moveSpeedX;
            tempStopMoveY = moveSpeedY;
            moveSpeedX = 0f;
            moveSpeedY = 0f;
            stopFlag = 1;
        }
        else
        {
            moveSpeedX = tempStopMoveX;
            moveSpeedY = tempStopMoveY;
            stopFlag = 0;
        }
    }

    public void RPushDown()
    {
        //右ボタンを押している間
        right = true;
    }

    public void RPushUp()
    {
        //右ボタンを押すのをやめた時
        right = false;
    }

    public void LPushDown()
    {
        //左ボタンを押している間
        left = true;
    }

    public void LPushUp()
    {
        //左ボタンを押すのをやめた時
        left = false;
    }

    public void GoRight()
    {
        moveSpeedX = speed;
    }

    public void GoLeft()
    {
        moveSpeedX = -speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                SceneManager.LoadScene("BattleScene");
                StopButtonDown();
                positionX = transform.position.x;
                positionY = transform.position.y;
                break;
            case "SpeedUp":
                moveSpeedY = -3f;
                speedFlag = 1;
                delta = 0f;
                break;
            case "SpeedDown":
                moveSpeedY = -1f;
                speedFlag = 1;
                delta = 0f;
                break;
            case "Goal":
                SceneManager.LoadScene("ResultScene");
                positionX = 0;
                positionY = 4f;
                GhostController.SetGhostPosition(0, 8f);
                break;
            default:
                break;
        }
    }
}