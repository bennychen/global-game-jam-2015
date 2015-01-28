using UnityEngine;
using System.Collections;

public class ContactSoundPlayer : MonoBehaviour {


	void OnTriggerEnter(Collider collider){
		//进入触发器执行的代码
//		Debug.Log("collide enter !"+collider.gameObject.name);
		if(collider.gameObject.Equals(_player)){
			startShouting(collider);
			audio.Play();
		}
	}
	void OnTriggerExit(Collider collider){
//		Debug.Log("collide exit !"+collider.gameObject.name);
		if(collider.gameObject.Equals(_player)){
			stopShouting(collider);
			audio.Stop();
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
			//Debug.Log("distance :"+distanceFromLisnter);
			if(distanceFromLisnter <= distanceThreshold){
				// level1 warning;
				audio.volume = (distanceThreshold-distanceFromLisnter)/distanceThreshold;
				float room = (distanceThreshold-distanceFromLisnter) * 1000f*(-1f);
				if(-room>1000*(distanceThreshold-reverbThreshold)){room = -10000;}
				_reverbFilter.room = room;
				currentRoom = room;
				//Debug.Log("reverbFilter.room:"+_reverbFilter.room);
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
		_reverbFilter = this.GetComponent<AudioReverbFilter>();
		if(_reverbFilter){
			Debug.Log("reverbFilter.room:"+_reverbFilter.room);
		}
		maxRoom = _reverbFilter.room;
	}

	[SerializeField]
	private float distanceThreshold = 10;
	[SerializeField]
	private float reverbThreshold = 3;
	[SerializeField]
	private float currentRoom;
	private bool _shouting = false;
	private float distanceFromLisnter = 0;
	private GameObject _player ;
	private AudioReverbFilter _reverbFilter;
	private float maxRoom;
	private float minRoom = -10000;
	public bool isShouting {get{return _shouting;}}
}
