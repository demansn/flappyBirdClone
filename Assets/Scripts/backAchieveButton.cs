using UnityEngine;
using System.Collections;

public class backAchieveButton : MonoBehaviour {
	//Переменная для использования скрипта меню достижений
	private  achieveBar aBar;
	//Перменна для сохранения старых размеров кнопки 
	private Vector3 oldScale;
	// Use this for initialization
	void Start () {
		//Находим скрипт меню достижений
		aBar = FindObjectOfType<achieveBar>();
		//Сохранение старого размера кнопки
		oldScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnMouseDown(){
		//увеличение размера кнопки при нажатии 
		transform.localScale = new Vector3(transform.localScale.x + 0.025f,transform.localScale.y,transform.localScale.z + 0.025f);
	}

	private void OnMouseUp(){
		//возвращение прежнего размера кнопки при отжатии
		transform.localScale = oldScale;
		//Двигаем меню назад
		aBar.MoveBack();
	}
}
