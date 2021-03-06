﻿using UnityEngine;
using System.Collections;

public class WallBlock : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		for (int i = 0; i < collision.contacts.Length; i++)
		{
			ContactPoint contactPoint = collision.contacts[i];
			if (contactPoint.otherCollider.CompareTag("Player"))
			{
				//Debug.Log("player collider wall - " + (-contactPoint.normal));
				GetComponent<AudioSource>().Play();
				Player player = contactPoint.otherCollider.GetComponent<Player>();
				player.FreezePlayer(0.5f);
				player.rigidbody.AddForce(-contactPoint.normal * 50);
				break;
			}
		}
	}
}
