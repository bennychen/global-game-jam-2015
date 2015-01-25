using UnityEngine;
using System.Collections;

public class RandomPlayEffect : MonoBehaviour {

	[SerializeField]
	public float checkPlaySoundDuration = 10.0f;

	[SerializeField]
	public int playSoundPossiableRate;

	private float duration = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		duration+=Time.deltaTime;
		if(duration>=checkPlaySoundDuration)
		{
			duration=0;
			int seed = Random.Range(1,playSoundPossiableRate);
			int resault = Random.Range(1,playSoundPossiableRate);
			if(seed==resault)
			{
				audio.Play();
			}
		}
	}
}
