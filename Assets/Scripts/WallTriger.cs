using UnityEngine;
using System.Collections;

public class WallTriger : MonoBehaviour {

	private Camera mainCamera;

	private GuI gui;

	void Start(){
		mainCamera = Camera.main;
		gui = mainCamera. GetComponent<GuI>();
	}

	void OnTriggerExit(Collider other) {
		audio.Play ();
		gui.AddPoint ();

	}
}
