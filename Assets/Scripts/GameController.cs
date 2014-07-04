using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private int currentScore = 0;
	private int bestScore = 0;

	public void Save(){
		
								
		PlayerPrefs.SetInt ("bestPoints", bestScore);
		PlayerPrefs.Save ();

	}

	public void Load(){

	
	}

	public static void Restart(){
		
		Application.LoadLevel (0);
	}
}
