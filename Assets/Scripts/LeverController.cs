using UnityEngine;
using System.Collections;

public class LeverController : MonoBehaviour
{

		public GameObject LevelPart;
		public GameObject wall;
		public Camera camera;
		public float levelWidth = 27;
		public float levelHeight = 30;
		private float oldX = 0;
		private float currentX = 0;
		private GameObject[] levelParts;
		public  int gapBetweenWalls = 5;
		private int levelPartCounter = 0;
		private float maxWallYPosition = 15;
		private float minWallYPosition = 1;
		private bool isWallGenerete = false;

		void Start ()
		{

				oldX = camera.transform.position.x - levelWidth;

				Vector3 r = new Vector3 (0, 0, 0);
				Vector3 newPos;

				GameObject instanceGameObject;

				while (oldX <  camera.transform.position.x + levelWidth) {

						oldX += LevelPart.transform.localScale.x;
						createLevelPart (oldX);
									
				}		
	
		}

		void Update ()
		{				

				Vector3 newPos;
				levelParts = GameObject.FindGameObjectsWithTag ("LevelPart");
				GameObject instanceGameObject = levelParts [levelParts.Length - 1];


				if (oldX < camera.transform.position.x + levelWidth) {
						oldX += instanceGameObject.transform.localScale.x;

						if (levelPartCounter < gapBetweenWalls || !isWallGenerete) {
						
								createLevelPart (oldX);
								levelPartCounter += 1;
						} else {
								createWall (oldX, Random.Range (minWallYPosition, maxWallYPosition));
								levelPartCounter = 0;
						}


				}



				for (int i = 0; i < levelParts.Length; i += 1) {
						if (levelParts [i].transform.position.x < camera.transform.position.x - levelWidth) {
								Destroy (levelParts [i]);
						}
				}
		}

		void createLevelPart (float x)
		{

				Vector3 upPartPos = new Vector3 (x, levelHeight, 0);
				Vector3 downPartPos = new Vector3 (x, 0, 0);

				Instantiate (LevelPart, upPartPos, Quaternion.identity);
				Instantiate (LevelPart, downPartPos, Quaternion.identity);


		}

		void createWall (float x, float y)
		{

				Vector3 position = new Vector3 (x, y, 0);
		
				Instantiate (wall, position, Quaternion.identity);

		}

		public void startWallGenerate ()
		{
				isWallGenerete = true;
		}

}
