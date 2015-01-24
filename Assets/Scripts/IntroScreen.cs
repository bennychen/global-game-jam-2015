using UnityEngine;
using System.Collections;

public class IntroScreen : MonoBehaviour 
{
	private void Start () 
	{
		StartCoroutine(EnterHomeScreen());
	}

	private IEnumerator EnterHomeScreen()
	{
		yield return new WaitForSeconds(3f);
		Application.LoadLevel("MainMenu");
	}
}
