using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RockController : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("CollisionTrigger");
    }
}
