using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemberController : MonoBehaviour
{
    public float stopTime = 0.5f;
    float delta = 0f;
    float speed = 0.1f;
    void Start()
    {
        
    }

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.stopTime)
        {
            transform.Translate(this.speed, 0, 0);
        }
        if (transform.position.x > 4f)
        {
            Destroy(gameObject);
            GhostController.StopButtonDown();
        }
    }
}
