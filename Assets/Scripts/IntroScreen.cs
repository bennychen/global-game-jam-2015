using UnityEngine;
using System.Collections;

public class IntroScreen : MonoBehaviour 
{
	[SerializeField]
	public tk2dSprite image;

	private void Start () 
	{
		StartCoroutine(FlashScreen(startTime));
		StartCoroutine(EnterHomeScreen());
	}

	private IEnumerator FlashScreen(float delay)
	{
		yield return new WaitForSeconds(delay);
		Go.to(image, duration, new GoTweenConfig().colorProp("color", Color.white).
		      setEaseType(GoEaseType.BounceInOut).setIterations(1, GoLoopType.PingPong));
		yield return new WaitForSeconds(duration);
		Go.to(image, duration, new GoTweenConfig().colorProp("color", Color.black).
		      setEaseType(GoEaseType.BounceInOut).setIterations(1, GoLoopType.PingPong));
	}

	private IEnumerator EnterHomeScreen()
	{
		yield return new WaitForSeconds(totalSoundTime);
		Application.LoadLevel("MainMenu");
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			Application.LoadLevel("MainMenu");
		}
	}

	public Camera mainCamera;
	public GoEaseType easeType;
	public float startTime;
	public float duration = 1f;
	public float totalSoundTime = 10f;
}
