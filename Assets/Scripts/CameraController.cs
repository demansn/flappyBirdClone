using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	//переменная для обьекта игрок
	public GameObject player;
	//переменная для передачи позиции игрока
	private Vector3 offset;
		
	// Use this for initialization
	void Start () {
		//Передача переменной стартовой позиции камеры
		offset = transform.position;
	}


	
	// Update is called once per frame
	void LateUpdate () {
		//Запись в переменную координат Х от обьекта игрок 
		offset.x = player.transform.position.x;
		//Передача координат камеры посредством Vector3
		transform.position = offset;
	}
}
