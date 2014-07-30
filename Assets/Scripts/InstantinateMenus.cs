using UnityEngine;
using System.Collections;

public class InstantinateMenus : MonoBehaviour {

	//Берем Меню магазина и достижений из префабов.
	public GameObject shopMenu;
	public GameObject achiveBar;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

	public void CreateMenus(){
		//Создаем оба меню в указаном месте и с заданым вращением
		Instantiate(shopMenu, new Vector3(transform.position.x + 5, transform.position.y - 5, transform.position.z), Quaternion.Euler(90,180,0));
		Instantiate(achiveBar, new Vector3(transform.position.x + 5, transform.position.y - 5, transform.position.z),Quaternion.Euler(90,180,0));
	}

}
