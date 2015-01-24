using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour {
	
	private void OnEnable () {
		_startButton.onClick.AddListener (() =>
		                                  {
			Debug.Log("GoToLevel001");
			Application.LoadLevel("Level001");
		}); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	[SerializeField]
	private Button _startButton;

}