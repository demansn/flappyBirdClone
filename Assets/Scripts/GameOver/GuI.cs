using UnityEngine;
using System.Collections;

public class GuI : MonoBehaviour {

	private bool callGameOver = false;
	private int clickCalculate;

	void OnGUI(){
		if(callGameOver){
			GUI.Box(new Rect(Screen.currentResolution.width*5/100, Screen.currentResolution.height*5/100, Screen.currentResolution.width*90/100, Screen.currentResolution.height*30/100),"Game Over");
				if(GUI.Button(new Rect(Screen.currentResolution.width*30/100, Screen.currentResolution.height*10/100, Screen.currentResolution.width*40/100, Screen.currentResolution.height*10/100), "Try Again")){
					Application.LoadLevel(1);
					callGameOver = false;
				}
		}
		GUI.Label(new Rect(Screen.currentResolution.width * 5/100, Screen.currentResolution.height * 10 / 100, Screen.currentResolution.width * 20/100, Screen.currentResolution.height * 7/100), "Button Clicks " + clickCalculate);
	}

	public void MakeGameOver(int i){
		if(i == 1){
			callGameOver = true;
		}
	}

	public void ClickCalculate(int i){
		if(i == 1){
			clickCalculate++;
			i = 0;
		}
	}
}
