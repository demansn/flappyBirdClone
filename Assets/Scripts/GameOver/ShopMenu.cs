using UnityEngine;
using System.Collections;

public class ShopMenu : MonoBehaviour {

	private bool moveBar = false;
	private bool moveBack = false;

	private Vector3 increase;
	private Vector3 scale;

	private float stopPoint;
	private float startPoint;

	private int screenWidth;

	private GuI callGui;
	// Use this for initialization
	void Start () {
		callGui = FindObjectOfType<GuI>();

		screenWidth = Screen.currentResolution.width;
		scale = new Vector3(screenWidth / 350, this.transform.localScale.y, this.transform.localScale.z);
		this.transform.localScale = scale;
	}
	
	// Update is called once per frame
	void Update () {
		if(moveBar){
			increase = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);	
			if(transform.position.x > stopPoint + 15){					
				transform.position = increase;
			} else {
				moveBar = false;
				
			}
		}

		if(moveBack){
			increase = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);	
			if(transform.position.x < startPoint){					
				transform.position = increase;
			} else {
				moveBack = false;
				callGui.EnableButtons(1);
			}
		}
	}

	public void StartMoveShopMenu(int i){
		if(i == 1){
			moveBar = true;
		}
	}

	public void GetShopPosition(float i){
		stopPoint = i;
		startPoint = transform.position.x;
	}

	public void MoveShopBack(){
		moveBack = true;
	}
}
