using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour
{

	// Use this for initialization
	void Start (){

	}
	void randomMove (float deltaTime){
		if (randomMoveTimeCounter <= 0) {
			randomMoveTimeCounter = randomMovePeriod;
			//randomMove aciton
			float y = Random.Range(randomMoveMin, randomMoveMax);
			float x = Random.Range(randomMoveMin, randomMoveMax);
			Vector3 movement = new Vector3 ( x,0,y);
			transform.Translate(movement);

		
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
		randomMovePeriod = 1;
	
	[SerializeField]
	private Vector2 randomMoveSize = new Vector2(-0.3f, 0.3f);
	
	public float randomMoveMin { get{return randomMoveSize.x;}}
	public float randomMoveMax { get{return randomMoveSize.y;}}
	[SerializeField]
	private float randomMoveTimeCounter = 0;
}
