using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour
{

	// Use this for initialization
	void Start (){

	}
	void randomMove (float deltaTime){
		if (randomMoveTimeCounter <= 0) {
			randomMoveTimeCounter = 15;
			//randomMove aciton
			float y = Random.Range(randomMoveMin, randomMoveMax);
			float x = Random.Range(randomMoveMin, randomMoveMax);

		} else {
			randomMoveTimeCounter -= deltaTime;
		}
	}

	// Update is called once per frame
	void Update (){
		this.randomMove(Time.deltaTime);
	}
	[SerializeField]
	public float
		level0_soundTriggerRadius = 100;//level 0 trigger sound
	
	[SerializeField]
	public float
		level1_soundTriggerRadius = 50;// level 1 warning sound 
	
	[SerializeField]
	public float
		level2_soundTriggerRadius = 30;// level 2 serverly warning zone
	
	[SerializeField]
	public float
		level3_soundTriggerRadius = 15;// level 3 dead man!
	
	[SerializeField]
	public float
		randomMovePeriod = 15;
	
	[SerializeField]
	private Vector2 randomMoveSize = new Vector2(0, 3);
	
	public float randomMoveMin { get{return randomMoveSize.x;}}
	public float randomMoveMax { get{return randomMoveSize.y;}}
	private float randomMoveTimeCounter = 15;
}
