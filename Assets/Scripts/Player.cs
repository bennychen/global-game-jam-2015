using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	[SerializeField]
	public  float stepSize = 100.0f;

	[SerializeField]
	public float stepDuration = 0.5f;

	public float countTime = 0.0f;

	bool isMoving = false;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	
	}
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		float moveHorizontalNum = moveHorizontal;
		float moveVerticalNum = moveVertical;

		if (moveHorizontal == 0.0f && moveVertical == 0.0f) 
		{
			countTime = 0.0f;
			isMoving = false;

			return;
		}

		if (0.0f == countTime) 
		{
			isMoving = true;
		}


		if (0.0f < countTime && isMoving)
		{
			Vector3 movement = new Vector3 (moveHorizontalNum,0.0f,moveVerticalNum);
			transform.Translate (movement*stepSize*Time.deltaTime);
		}

		countTime+=0.1f;

		if (stepDuration == countTime) 
		{
			countTime=0.0f;
		}
	}
}
