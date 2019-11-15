using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostController : MonoBehaviour
{
    float speedX = 1f;
    float speedY = 2.2f;
    float moveSpeedX;
    float moveSpeedY;
    float tempStopMoveX = 0f;     //一時停止時前の速度を保存
    float tempStopMoveY = 0f;     //一時停止時前の速度を保存
    Rigidbody2D ghostRb;
    float distanceX;               //主人公と敵のx座標の差
    float distanceY;               //主人公と敵のy座標の差
    int stopFlag = 0;
    GameObject ghost;
    GameObject mainCharacter;


    void Start()
    {
        ghost = GameObject.Find("Ghost");
        mainCharacter = GameObject.Find("MainCharacter");
        ghost.transform.position = new Vector3(0, 8, 0);
        moveSpeedX = 0f;
        moveSpeedY = -speedY;
        ghostRb = ghost.GetComponent<Rigidbody2D>();
        ghostRb.velocity = new Vector3(moveSpeedX, moveSpeedY, 0);
    }

    void Update()
    {
        if (stopFlag == 0)
        {
            distanceX = mainCharacter.transform.position.x -
            ghost.transform.position.x;
            distanceY = mainCharacter.transform.position.y -
                ghost.transform.position.y;
            //敵キャラのx軸方向の動きを制御
            if (distanceX > 0.01f)
            {
                moveSpeedX = speedX;
            }
            else if (distanceX < -0.01f)
            {
                moveSpeedX = -speedX;
            }
            else
            {
                moveSpeedX = 0f;
            }
            //敵キャラのy軸方向の動きを制御
            if (distanceY > 0.1f)
            {
                moveSpeedY = speedY;
            }
            else if (distanceY < -0.1f)
            {
                moveSpeedY = -speedY;
            }
            else
            {
                moveSpeedY = 0f;
            }
        }
        ghostRb.velocity = new Vector3(moveSpeedX, moveSpeedY, 0);
    }

    public void StopButtonDown()
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
}