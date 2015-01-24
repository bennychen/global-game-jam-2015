using UnityEngine;
using System.Collections;

public class DeadArea : MonoBehaviour 
{
	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.CompareTag("Player"))
		{
			// kill player
		}
	}
}
