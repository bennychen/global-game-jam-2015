using UnityEngine;
using System.Collections;

public class LevelEndScreen : MonoBehaviour 
{
	public static bool Success { get; set; }

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

	private void OnEnable()
	{

	}
}
