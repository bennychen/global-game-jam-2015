using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HomeScreen : MonoBehaviour 
{
	public tk2dSprite door;
	public tk2dSprite doorOpen;
	public float animDelay = 1f;
	public float duration;
	public float closeDoorDuration = 0.5f;
	public AudioClip openDoor;
	public AudioClip closeDoor;
	public AudioClip intro;
	public AudioSource audioSource;

	public IEnumerator ClickStartButton()
	{
		audioSource.clip = openDoor;
		audioSource.Play();
		yield return new WaitForSeconds(animDelay);
		Go.to(door, duration, new GoTweenConfig().colorProp("color", new Color(1, 1, 1, 0)).setEaseType(GoEaseType.SineOut));
		Go.to(doorOpen, duration, new GoTweenConfig().colorProp("color", new Color(1, 1, 1, 1)).setEaseType(GoEaseType.SineOut));
		//SaveManager.LoadCurrentLevel();

		yield return new WaitForSeconds(duration + 1);

		audioSource.clip = intro;
		audioSource.Play ();

		yield return new WaitForSeconds(35);

		Go.to (doorOpen.transform, closeDoorDuration, new GoTweenConfig().scale(Vector3.one * 3f));
		Go.to (doorOpen, closeDoorDuration, new GoTweenConfig().colorProp("color", new Color(1, 1, 1, 0)));
		audioSource.clip = closeDoor;
		audioSource.Play();

		yield return new WaitForSeconds(closeDoorDuration);
		SaveManager.LoadCurrentLevel();

	}
	
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			SaveManager.LoadCurrentLevel();
		}
	}
}