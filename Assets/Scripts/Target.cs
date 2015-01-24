using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour 
{
	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.CompareTag("Player"))
		{
			Player player = collider.gameObject.GetComponent<Player>();
			player.StartPursueGhost();
			gameObject.SetActive(false);
		}
	}
}
