using UnityEngine;
using System.Collections;

public static class SaveManager
{
	public const int LevelCount = 3;

	public static int CurrentLevelIndex
	{
		get
		{
			return PlayerPrefs.GetInt("current_level", 1);
		}
		set
		{
			PlayerPrefs.SetInt("current_level", value);
		}
	}

	public static void Reset()
	{
		PlayerPrefs.DeleteAll();
		Debug.Log("PlayerPrefs.DeleteAll()");
	}

	public static void LoadCurrentLevel()
	{
		LoadLevel(CurrentLevelIndex);
	}

	public static void AdvanceLevel()
	{
		CurrentLevelIndex = Mathf.Clamp(CurrentLevelIndex, CurrentLevelIndex + 1, LevelCount);
		Debug.Log("CurrentLevelIndex:"+CurrentLevelIndex);
	}

	public static void LoadLevel(int index)
	{
		if (index >= 1 && index <= LevelCount)
		{
			Application.LoadLevel("LevelMatthew00" + index);
			Debug.Log("LoadLevel :"+index);
		}
	}
}
