using UnityEngine;
using System.Collections;
//Идентичный скрипт с backAchieveButton, применяется к возврату меню магазина
public class backShopButton : MonoBehaviour {

	private  ShopMenu callShop;
	
	private Vector3 oldScale;

	// Use this for initialization
	void Start () {
		callShop = FindObjectOfType<ShopMenu>();
		oldScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown(){
		transform.localScale = new Vector3(transform.localScale.x + 0.025f,transform.localScale.y,transform.localScale.z + 0.025f);
	}
	
	private void OnMouseUp(){
		transform.localScale = oldScale;
		callShop.MoveShopBack();
	}

}
