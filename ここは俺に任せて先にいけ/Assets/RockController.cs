﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RockController : MonoBehaviour
{
    GameObject rock;
    Animator animator;
    void Start()
    {
        rock = GameObject.Find("Rock");
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("CollisionTrigger");
    }
}
