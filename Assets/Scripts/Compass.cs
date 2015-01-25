using UnityEngine;
using System.Collections;

public class Compass : MonoBehaviour 
{
	private void FixedUpdate () 
	{
		transform.LookAt(Target.transform.position);
	}

	private Target Target
	{
		get
		{
			if (_target == null)
			{
				_target = FindObjectOfType<Target>();
			}
			return _target;
		}
	}

	private Target _target;
}
