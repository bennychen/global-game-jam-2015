using UnityEngine;
using System.Collections;

public class IntroScreen : MonoBehaviour 
{
	private void Start () 
	{
		StartCoroutine(FlashScreen(startTime));
		StartCoroutine(EnterHomeScreen());
	}

	private IEnumerator FlashScreen(float delay)
	{
		yield return new WaitForSeconds(delay);
		Go.to(mainCamera, duration, new GoTweenConfig().colorProp("backgroundColor", Color.white).
		      setEaseType(GoEaseType.BounceInOut).setIterations(1, GoLoopType.PingPong));
		yield return new WaitForSeconds(duration);
		Go.to(mainCamera, duration, new GoTweenConfig().colorProp("backgroundColor", Color.black).
		      setEaseType(GoEaseType.BounceInOut).setIterations(1, GoLoopType.PingPong));
	}

	private IEnumerator EnterHomeScreen()
	{
		yield return new WaitForSeconds(totalSoundTime);
		Application.LoadLevel("MainMenu");
	}

	public Camera mainCamera;
	public GoEaseType easeType;
	public float startTime;
	public float duration = 1f;
	public float totalSoundTime = 10f;
}
