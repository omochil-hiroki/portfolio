using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleDirector : MonoBehaviour
{
     public static int leaveFlag;  //1or2or3 → 仲間1or2or3 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(PlayerController.sceneName);
            leaveFlag = 1;
            PlayerController.StopButtonDown();
            GhostController.StopButtonDown();
        }
    }

    public static void ResetLeaveFlag()
    {
        leaveFlag = 0;
    }

    public static int GetLeaveFlag()
    {
        return leaveFlag;
    }
}
