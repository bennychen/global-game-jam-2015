using UnityEngine;
using System.Collections;

public class InGameUI : MonoBehaviour {

	public GameObject compass;
	public GameObject mug;

	private Player _player;

	private void Update()
	{
		if (_player == null)
		{
			_player = FindObjectOfType<Player>();
		}
		compass.SetActive(!_player.IsPursuingGhost);
		mug.SetActive(_player.IsPursuingGhost);
	}
}
