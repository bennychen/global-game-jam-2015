using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour
{

	// Use this for initialization
	void OnTriggerEnter(Collider collider){
		//进入触发器执行的代码
//		Debug.Log("collide enter !"+collider.gameObject.name);
		if(collider.gameObject.Equals(_player)){
			startShouting(collider);
		}
	}
	void OnTriggerExit(Collider collider){
//		Debug.Log("collide exit !"+collider.gameObject.name);
		if(collider.gameObject.Equals(_player)){
			stopShouting(collider);
		}
	}
	void OnTriggerStay(Collider collider){
//		Debug.Log("collide stay !"+collider.gameObject.name);
		if(collider.gameObject.Equals(_player)){
			updateListnerDistance(collider);

		}
	}
	void updateListnerDistance(Collider collider){
		if(_shouting){
			distanceFromLisnter = Vector3.Distance(transform.position,collider.gameObject.transform.position);
			Debug.Log("distance :"+distanceFromLisnter);
			if(distanceFromLisnter <= level1_soundTriggerRadius){
				// level1 warning;
			}
		}
	}

	void startShouting(Collider collider){

		updateListnerDistance(collider);
		_shouting = true;

	}

	void stopShouting(Collider collider){

		updateListnerDistance(collider);
		_shouting = false;
	}
	void Start (){
		_player = GameObject.Find("Player");
	}
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
		level0_soundTriggerRadius = 10;//level 0 trigger sound
	
	[SerializeField]
	public float
		level1_soundTriggerRadius = 5;// level 1 warning sound 

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

	private bool _shouting = false;
	private float distanceFromLisnter = 0;
	private GameObject _player ;

	public bool isShouting {get{return _shouting;}}
}
