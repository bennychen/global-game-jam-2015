using UnityEngine;
using System.Collections;

public static class SaveManager
{
	public const int LevelCount = 1;

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
	}

	public static void LoadCurrentLevel()
	{
		LoadLevel(CurrentLevelIndex);
	}

	public static void AdvanceLevel()
	{
		CurrentLevelIndex = Mathf.Clamp(CurrentLevelIndex, 1, LevelCount);
	}

	public static void LoadLevel(int index)
	{
		if (index >= 1 && index <= LevelCount)
		{
			Application.LoadLevel("Level00" + index);
		}
	}
}
