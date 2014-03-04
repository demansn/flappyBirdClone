using UnityEngine;
using System.Collections;

public class LeverController : MonoBehaviour
{

		public GameObject LevelPart;
		public Camera camera;
		public float levelWidth = 10;
		// Use this for initialization
		void Start ()
		{

				float newXPos = 0;

				Vector3 r = new Vector3 (0, 0, 0);
				Vector3 newPos;

				GameObject instanceGameObject;

				while (newXPos <  camera.transform.position.x + levelWidth) {

						newPos = new Vector3 (newXPos, 0, 0);
						instanceGameObject = (GameObject)Instantiate (LevelPart, newPos, Quaternion.identity);
						newXPos += instanceGameObject.transform.localScale.x;

				}

				Debug.Log (camera.pixelRect.x + " " + camera.pixelRect.y);
		           
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				Debug.Log (camera.transform.position.x + " " + camera.rect.y);
		}
}
