using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {


	void OnGUI(){
		GUI.Box(new Rect(Screen.currentResolution.width*5/100, Screen.currentResolution.height*5/100, Screen.currentResolution.width*90/100, Screen.currentResolution.height * 70/100), "Main Menu");
		if(GUI.Button(new Rect(Screen.currentResolution.width*20/100, Screen.currentResolution.height*10/100, Screen.currentResolution.width * 60 / 100, Screen.currentResolution.height * 15/100),"Start Game")){
			Application.LoadLevel(1);
		}
	}
}
