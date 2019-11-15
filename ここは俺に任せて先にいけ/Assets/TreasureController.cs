using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : MonoBehaviour
{
	GameObject treasure;
	Animator animator;
	void Start()
	{
		treasure = GameObject.Find("TreasureBox");
		animator = GetComponent<Animator>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		animator.SetTrigger("CollisionTrigger");
	}
}

