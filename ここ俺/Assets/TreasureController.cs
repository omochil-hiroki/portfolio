using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : MonoBehaviour
{
	Animator animator;

	void Start()
	{
        animator = GetComponent<Animator>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "MainCharacter")
        {
            animator.SetTrigger("CollisionTrigger");
            GameDirector.CountTreasure();
        }
    }
}

