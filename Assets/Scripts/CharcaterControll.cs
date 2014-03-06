using UnityEngine;
using System.Collections;


public class CharcaterControll : MonoBehaviour {
	public float speed = 0.25f;
	private float vertical = 0;

	private Vector3 moveDirection ;
	//Variable for saving last bird position
	private Vector3 fixedPos;
	//Bird angle when it rotates
	public int rotateUp;
	//Variable for collision detect
	public Collision collision;
	//Varible for call method from GuI script
	public GuI callGui;
	//Varible that allows to play
	private bool check = false;
	private bool stopPlay = true;
	private bool testing = false;
	private bool goDown = false;
		
	void Start(){
		fixedPos = transform.position;
	}
	// Update is called once per frame
	void Update () {
		animation["Fly"].speed = 3f;
			if (Input.GetMouseButtonDown(0) && stopPlay){
				vertical = 0.5f;
				callGui.ClickCalculate();
				animation.CrossFade("Fly");
				if(!check){
					callGui.RemoveGetReady();
				}
				check = true;
				
			}
		
			if(check){
				vertical -= 0.025f;
			}
			moveDirection = new Vector3(speed, vertical, 0);

			CharacterController controller = GetComponent<CharacterController>();
			controller.Move(moveDirection);

			if(vertical < -0.6f){
				vertical = -0.6f;
			}	
		

			testing = true;
	}

	public void OnControllerColliderHit(ControllerColliderHit hit){
		if(testing){
			Debug.Log("TADA");
			callGui.MakeGameOver();
			stopPlay = false;
			testing = false;
			speed = 0;
		}
	}

}