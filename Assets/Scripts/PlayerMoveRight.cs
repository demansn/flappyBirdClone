using UnityEngine;
using System.Collections;

public class PlayerMoveRight : MonoBehaviour {
	
	public int speed;
	private int rotateUp;
	private int rotateDown;

	private bool check = false;
	private int timer;

	private Vector3 fixedPos;

	void FixedUpdate(){		
		rotateUp = rotateUp - 1;
		rotateDown = rotateDown + 1;
		rigidbody.AddForce(speed,-2,0, ForceMode.Acceleration);


		if(Input.GetMouseButtonDown(0)){
			rigidbody.AddForce(0,80,0, ForceMode.Acceleration);
			check = true;
			timer += 50;
			fixedPos = transform.position;
		}

		if(fixedPos.y > transform.position.y){
			check = false;
		} else {
			check = true;
		}

		/*if(check){
			rigidbody.rotation = Quaternion.AngleAxis(rotateDown, Vector3.forward);
		} else {
			rigidbody.rotation = Quaternion.AngleAxis(rotateDown, Vector3.forward);
		}*/


	}


}
