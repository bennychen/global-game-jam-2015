using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour {
	[SerializeField]
	public float level0_soundTriggerRadius = 100;//level 0 trigger sound
	[SerializeField]
	public float level1_soundTriggerRadius = 50;// level 1 warning sound 
	[SerializeField]
	public float level2_soundTriggerRadius = 30;// level 2 serverly warning zone
	[SerializeField]
	public float level3_soundTriggerRadius = 15;// level 3 dead man!

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
