using UnityEngine;
using System.Collections;

public class GhostCollide : MonoBehaviour 
{
	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.CompareTag("Player"))
		{
			Player player = collider.gameObject.GetComponent<Player>();
			if (player.IsPursuingGhost)
			{
				Debug.Log("Beat level!!!!");
			}
			else
			{
				Debug.Log("Player is killed");
			}
			LevelEndScreen.Success = player.IsPursuingGhost;
			Application.LoadLevel("LevelEndScreen");
		}
	}
}
