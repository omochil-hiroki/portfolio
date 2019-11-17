using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemberGenerator : MonoBehaviour
{
    public GameObject member1;
    GameObject enemy;
    GameObject battleDirector;
    void Start()
    {
        enemy = GameObject.Find("Ghost");
    }

    void Update()
    {
        switch (BattleDirector.GetLeaveFlag())
        {
            case 1:
                GameObject member = Instantiate(member1) as GameObject;
                member.transform.position = new Vector3(enemy.transform.position.x,
                    enemy.transform.position.y - 1, 0);
                BattleDirector.ResetLeaveFlag();
                GhostController.StopButtonDown();
                break;
        }
    }
}
