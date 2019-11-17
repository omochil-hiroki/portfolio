using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostController : MonoBehaviour
{
    float speedX = 1f;
    float speedY = 2.4f;
    public static float moveSpeedX;
    public static float moveSpeedY;
    Rigidbody2D ghostRb;
    public static int stopFlag = 0;
    GameObject mainCharacter;

    static float ghostPositionX = 0;
    static float ghostPositionY = 8f;


    void Start()
    {
        this.mainCharacter = GameObject.Find("MainCharacter");
        moveSpeedX = 0f;
        moveSpeedY = -this.speedY;
        transform.position = new Vector3(ghostPositionX, ghostPositionY, 0);
        this.ghostRb = GetComponent<Rigidbody2D>();
        this.ghostRb.velocity = new Vector3(moveSpeedX, moveSpeedY, 0);
    }

    void Update()
    {
        float distanceX;               //主人公と敵のx座標の差
        float distanceY;               //主人公と敵のy座標の差
        if (stopFlag == 0)
        {
            distanceX = mainCharacter.transform.position.x -
                transform.position.x;
            distanceY = mainCharacter.transform.position.y -
                transform.position.y;
            //敵キャラのx軸方向の動きを制御
            if (distanceX > 0.01f)
            {
                moveSpeedX = this.speedX;
            }
            else if (distanceX < -0.01f)
            {
                moveSpeedX = -this.speedX;
            }
            else
            {
                moveSpeedX = 0f;
            }
            //敵キャラのy軸方向の動きを制御
            if (distanceY > 0.1f)
            {
                moveSpeedY = this.speedY;
            }
            else if (distanceY < -0.1f)
            {
                moveSpeedY = -this.speedY;
            }
            else
            {
                moveSpeedY = 0f;
            }
        }
        ghostRb.velocity = new Vector3(moveSpeedX, moveSpeedY, 0);
    }

    public static void StopButtonDown()
    {
        float tempStopMoveX = 0f;     //一時停止時前の速度を保存
        float tempStopMoveY = 0f;     //一時停止時前の速度を保存
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "MainCharacter":
                StopButtonDown();
                ghostPositionX = transform.position.x;
                ghostPositionY = transform.position.y + 1;
                break;
            default:
                break;
        }
    }

    public static void SetGhostPosition(float ghostPosX, float ghostPosY)
    {
        ghostPositionX = ghostPosX;
        ghostPositionY = ghostPosY;
    }
}