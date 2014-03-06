using UnityEngine;
using System.Collections;

public class GuI : MonoBehaviour
{

		private bool callGameOver = false;
		private bool removeGetReady = true;
		private int clickCalculate;
		private int point = 0;
		public Texture getReady;
		public GUIStyle pointStyle;
		public GUIStyle getReadyStyle;
		private Rect pointRect;
		private Rect getReadyRect;

		void Start ()
		{
				
				pointRect = new Rect (Screen.width / 2, Screen.currentResolution.height * 4 / 100, Screen.currentResolution.width * 20 / 100, Screen.currentResolution.height * 7 / 100);
				getReadyRect = new Rect (Screen.width / 2, Screen.currentResolution.height * 15 / 100, Screen.currentResolution.width * 20 / 100, Screen.currentResolution.height * 10 / 100);
		}

		void OnGUI ()
		{
				if (removeGetReady) {
						GUI.Label (getReadyRect, "GET READY", getReadyStyle);			
						//GUI.DrawTexture (new Rect (Screen.currentResolution.width * 40 / 100, Screen.currentResolution.height * 20 / 100, Screen.currentResolution.width * 20 / 100, Screen.currentResolution.height * 10 / 100), getReady);
				}
				if (callGameOver) {
						GUI.Box (new Rect (Screen.currentResolution.width * 5 / 100, Screen.currentResolution.height * 5 / 100, Screen.currentResolution.width * 90 / 100, Screen.currentResolution.height * 30 / 100), "Game Over");
						if (GUI.Button (new Rect (Screen.currentResolution.width * 30 / 100, Screen.currentResolution.height * 10 / 100, Screen.currentResolution.width * 40 / 100, Screen.currentResolution.height * 10 / 100), "Try Again")) {
								Application.LoadLevel (0);
								callGameOver = false;
						}
				}
				GUI.Label (new Rect (Screen.currentResolution.width * 5 / 100, Screen.currentResolution.height * 10 / 100, Screen.currentResolution.width * 20 / 100, Screen.currentResolution.height * 7 / 100), "Button Clicks " + clickCalculate);
				GUI.Label (pointRect, point.ToString (), pointStyle);
		}

		public void MakeGameOver ()
		{
				callGameOver = true;
		}

		public void ClickCalculate ()
		{
				clickCalculate++;		
		}

		public void AddPoint ()
		{
				point += 1;
		}

		public void RemoveGetReady ()
		{
				removeGetReady = false;		
		}
}
