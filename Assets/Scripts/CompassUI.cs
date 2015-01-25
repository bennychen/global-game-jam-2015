using UnityEngine;
using System.Collections;

public class CompassUI : MonoBehaviour 
{
	[SerializeField]
	private float vibrationMaxRange = 15;
	[SerializeField]
	private float vibrationDuration = 0.3f;
	[SerializeField]
	private float vibrationScale = 0.1f;

	private Player player;
	private bool _shaking;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>();
		this.shake(1.0f);
	}
	void shake(float vibrationRate){
		if(!_shaking){
			_shaking = true;
			Go.to(transform, vibrationDuration, new GoTweenConfig().shake(Vector3.one *vibrationRate, GoShakeType.Position).onComplete(onShakeFinish));
		}

	}

	void onShakeFinish(AbstractGoTween tween){
		_shaking = false;
//		Debug.Log("distanceFromBug:"+distance);
		isNeedShake();
	}

	void isNeedShake(){
		if(!_shaking){
			float distance = player.distanceFromMug;
			if(distance < vibrationMaxRange){
				float rate = vibrationScale*(vibrationMaxRange-distance)/vibrationMaxRange;
				shake (rate);
			}
		}

	}

	// Update is called once per frame
	void Update () {
		transform.localRotation = Quaternion.Euler(-Vector3.forward * player.compass.transform.eulerAngles.y);
		isNeedShake();
	}
}
