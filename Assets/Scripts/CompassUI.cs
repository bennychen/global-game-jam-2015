using UnityEngine;
using System.Collections;

public class CompassUI : MonoBehaviour 
{
	private Player player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.localRotation = Quaternion.Euler(-Vector3.forward * player.compass.transform.eulerAngles.y);
	}
}
