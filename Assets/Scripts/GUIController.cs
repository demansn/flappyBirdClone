using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	// Use this for initialization
	private GameObject gameOverPanel;

	void Start () {

		gameOverPanel = GameObject.FindWithTag("gameOverPanel");
	
	}

	void SetVisibleGameOverMenu(bool isVisible){
		gameOverPanel.SetActive(isVisible);
	}
	
}
