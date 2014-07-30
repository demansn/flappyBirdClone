using UnityEngine;
using System.Collections;

public class buyLife : MonoBehaviour {

	private Vector3 oldScale;
	private GuI callGui;

	// Use this for initialization
	void Start () {
		callGui = FindObjectOfType<GuI>();
		oldScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnMouseUp(){
		transform.localScale = oldScale;
		callGui.BuyThing(1);
	}

	private void OnMouseDown(){
		transform.localScale = new Vector3(transform.localScale.x + 0.03f, transform.localScale.y, transform.localScale.z + 0.03f);
	}

}
