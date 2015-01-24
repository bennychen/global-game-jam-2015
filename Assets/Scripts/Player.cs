using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	[SerializeField]
	public float speed = 10f;

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		//rigidbody.MovePosition(rigidbody.position + moveHorizontal * Vector3.right * Time.fixedDeltaTime * 10 + 
		                       //moveVertical * Vector3.forward * Time.fixedDeltaTime * 10);
		rigidbody.velocity = moveHorizontal * Vector3.right * speed + moveVertical * Vector3.forward * speed;
	}
}
