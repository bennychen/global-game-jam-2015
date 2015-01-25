using UnityEngine;
using System.Collections;

public class LevelEndScreen : MonoBehaviour 
{
	public static bool Success { get; set; }

	public tk2dSprite Win;
	public tk2dSprite Fail;
	public AudioClip WinAudio;
	public AudioClip FailAudio;

	public void Restart()
	{
		SaveManager.LoadCurrentLevel();
	}

	public void Next()
	{
		if (SaveManager.CurrentLevelIndex >= SaveManager.LevelCount)
		{
			Application.LoadLevel("FinishScreen");
		}
		else
		{
			SaveManager.AdvanceLevel();
			SaveManager.LoadCurrentLevel();
		}
	}

	private void Update()
	{
		Win.gameObject.SetActive(Success);
		Fail.gameObject.SetActive(!Success);

		if (Input.GetKeyDown(KeyCode.R))
		{
			Restart ();
		}
		if (Input.GetKeyDown(KeyCode.N))
		{
			Next ();
		}
	}

	private void OnEnable()
	{
		GetComponent<AudioSource>().PlayClip(Success ? WinAudio : FailAudio);
	}
}
