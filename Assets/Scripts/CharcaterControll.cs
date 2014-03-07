using UnityEngine;
using System.Collections;


public class CharcaterControll : MonoBehaviour {
	public float speed = 0.20f;
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
	public LeverController lc;
	//Varible that allows to play
	private bool check = false;
	private bool stopPlay = true;
	private bool goDown = false;

	public GameObject collisionAudio;
		
	void Start(){
		fixedPos = transform.position;
	}
	// Update is called once per frame
	void Update () {

		if(stopPlay){
			animation.CrossFade("Fly");
		}
			if (Input.GetMouseButtonDown(0) && stopPlay){
				audio.Play();
				vertical = 0.4f;
				animation["Fly"].speed = 3f;
				animation.CrossFade("Fly");
				
				if(!check){
					callGui.HideGetReady();
					lc.startWallGenerate();
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
		

			
	}

	public void OnControllerColliderHit(ControllerColliderHit hit){
		if(stopPlay){	
			callGui.MakeGameOver();
			callGui.HidePoints ();
			speed = 0;	
			animation.Stop("Fly");
			collisionAudio.audio.Play();
			stopPlay = false;
		}
	}

}