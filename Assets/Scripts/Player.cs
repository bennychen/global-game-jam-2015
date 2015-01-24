using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	[SerializeField]
	public  float stepSize = 10;
	Vector3 lasttime;
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
		//Debug.Log (moveHorizontal);

		float Horizontal = 0.0f;
		float Vertical = 0.0f;
		if(moveHorizontal>0)
		{
			Horizontal = 1.0f;
		}
		else if(moveHorizontal<0)
		{
			Horizontal = -1.0f;
		}

		if(moveVertical>0)
		{
			Vertical = 1.0f;
		}
		else if(moveVertical<0)
		{
			Vertical = -1.0f;
		}
		//Debug.Log (gameObject.transform.position.y);
		//Vector3 movement = new Vector3 (gameObject.transform.position.y+stepSize*Horizontal*Time.deltaTime,0.0f,gameObject.transform.position.x+stepSize*Vertical*Time.deltaTime);
		//transform.Translate (movement);
		//Vector3 movement = new Vector3 (moveHorizontal*stepSize*-1.0f,0.0f,moveVertical*stepSize*-1.0f);
		Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);
		//Vector3 movement = new Vector3 (moveHorizontal*stepSize*-1.0f,0.0f,moveVertical*stepSize*-1.0f);
		transform.Translate (movement*stepSize*Time.deltaTime);
	}
}
