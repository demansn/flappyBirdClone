using UnityEngine;
using System.Collections;

public class PlayerMoveRight : MonoBehaviour {
	//Bird speed when it goes right
	public int speed;
	//Bird angle when it rotates
	private int rotateUp;
	//Variable for collision detect
	public Collision collision;
	//Variable for saving last bird position
	private Vector3 fixedPos;
	//Varible for call method from GuI script
	public GuI callGui;
	//Variable for change force to make bird goes up.
	public int forceUp = 500;
	//Varible for gravity
	public int gravity = 15;
	//Varible that allows to play
	private bool check;

	void Start(){
		check = false;
	}

	void FixedUpdate(){		
		if(check){
			//bird allways go right
			rigidbody.AddForce(speed,-gravity,0, ForceMode.Acceleration);


			//If left mouse button down, makes bird to fly up
			if(Input.GetMouseButtonDown(0)){
				rigidbody.AddForce(0,forceUp,0, ForceMode.Acceleration);
				Debug.Log(check);
			}

			//If bird goes up it rotates up, else it rotates down
			if(fixedPos.y > transform.position.y){
				rotateUp = rotateUp - 4;
				rigidbody.rotation = Quaternion.AngleAxis(rotateUp, Vector3.forward);
			} else { 
				rotateUp = rotateUp + 5;
				rigidbody.rotation = Quaternion.AngleAxis(rotateUp, Vector3.forward);
			}

			//Bird rotate to static digrees
			if(rotateUp > 45){
				rotateUp = 45;
			} else if(rotateUp < -70){
				rotateUp = -70;
			}


			//remember old position of the bird
			fixedPos = transform.position;

		}
	}
	//If bird touch collision than game over
	/*void OnCollisionEnter(Collision collision){
		callGui.MakeGameOver(1);
		check = false;
	}*/


}
