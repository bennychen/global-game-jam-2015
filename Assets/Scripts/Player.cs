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
		Debug.Log (transform.position.x+stepSize*Horizontal);
		Vector3 movement = new Vector3 (transform.position.x+stepSize*Horizontal,transform.position.y+stepSize*Vertical,0.0f);
		
		transform.Translate (movement);
		//Vector3 movement = new Vector3 (moveVertical,0.0f,moveHorizontal);
		//transform.Translate (movement*Time.deltaTime);
	}
}
