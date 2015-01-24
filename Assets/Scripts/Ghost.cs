using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour
{
	// Use this for initialization

	void randomMove (float deltaTime){
		if(!randomMoveEnbaled)return;
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
		randomMovePeriod = 1;
	
	[SerializeField]
	private Vector2 randomMoveSize = new Vector2(-0.3f, 0.3f);
	
	public float randomMoveMin { get{return randomMoveSize.x;}}
	public float randomMoveMax { get{return randomMoveSize.y;}}
	[SerializeField]
	private float randomMoveTimeCounter = 0;

	[SerializeField]
	private bool randomMoveEnbaled = true;

}
