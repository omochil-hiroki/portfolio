using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldDirector : MonoBehaviour
{
    public void MoveToEscapeScene()
    {
        SceneManager.LoadScene("EscapeScene");
    }

    public void MoveToStage2()
    {
        SceneManager.LoadScene("Stage2");
    }
}
