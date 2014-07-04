using UnityEngine;
using System.Collections;

public class GuI : MonoBehaviour
{

		private bool callGameOver = false;
		private bool isShowGetReady = true;
		private bool isShowPoint = true;
		private int clickCalculate;
		private int points = 0;
		private int bestPoints = 0;
		public Texture getReady;
		public GUIStyle pointStyle;
		public GUIStyle getReadyStyle;
		public GUIStyle pointStyleEnd;
		private Rect pointRect;
		private Rect getReadyRect;
		private Rect scoreRect;
		private Rect bestScoreRect;
		public Rect buttonRect;
		public GUIStyle buttonStyle;

		public float buttonWidth = 0;
		public float buttonHeight = 0;
		public int buttonX = 20;
		public int buttonY = 20;


void Start ()
{
	
	pointRect = new Rect (Screen.currentResolution.width * 30 / 100, Screen.currentResolution.height * 4 / 100, Screen.currentResolution.width * 40 / 100, Screen.currentResolution.height * 7 / 100);
	
				getReadyRect = new Rect (Screen.currentResolution.width * 30 / 100, Screen.currentResolution.height * 20 / 100, Screen.currentResolution.width * 40 / 100, Screen.currentResolution.height * 10 / 100);
				scoreRect = new Rect (Screen.currentResolution.width * 47 / 100, Screen.currentResolution.height * 33 / 100, Screen.currentResolution.width * 20 / 100, Screen.currentResolution.height * 10 / 100);
				bestScoreRect = new Rect (Screen.currentResolution.width * 47 / 100, Screen.currentResolution.height * 38 / 100, Screen.currentResolution.width * 20 / 100, Screen.currentResolution.height * 10 / 100);
				buttonRect = new Rect (Screen.width * buttonX / 100, Screen.height * buttonY / 100, Screen.width * buttonWidth / 100, Screen.height * buttonHeight / 100);


				if (PlayerPrefs.HasKey ("bestPoints")) {
						bestPoints = PlayerPrefs.GetInt ("bestPoints");
				}
		
		}

		void OnGUI (){		

			
		
			if (isShowGetReady) {
				GUI.Label (getReadyRect, "GET READY", getReadyStyle);						
			}

				if (callGameOver) {

						GUI.Label (getReadyRect, "Game Over", getReadyStyle);
						GUI.Label (scoreRect, "Score: " + points.ToString (), pointStyleEnd);
						GUI.Label (bestScoreRect, "BestScore: " + bestPoints.ToString (), pointStyleEnd);
						
						buttonRect = new Rect (Screen.currentResolution.width * buttonX / 100, Screen.currentResolution.height * buttonY / 100, Screen.currentResolution.width * buttonWidth / 100, Screen.currentResolution.height * buttonHeight / 100);
		
						if (GUI.Button (buttonRect, "Try Again")) {
								Application.LoadLevel (0);
								callGameOver = false;
								PlayerPrefs.SetInt ("bestPoints", bestPoints);
								PlayerPrefs.Save ();
						}
				}
			
				if (isShowPoint) {
						GUI.Label (pointRect, points.ToString (), pointStyle);
				}
		}

		public void MakeGameOver ()
		{
				callGameOver = true;
		}

		public void AddPoint ()
		{
				points += 1;
		
				if (points > bestPoints) {
						bestPoints = points;
				}
		}
	
		public void HidePoints ()
		{

				isShowPoint = false;

		}

		public void HideGetReady ()
		{
				isShowGetReady = false;		
		}
}
