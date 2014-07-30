using UnityEngine;
using System.Collections;

public class achieveBar : MonoBehaviour {
	//Точка, в которой остановится меню при движении вперед
	private float stopPoint;
	//Точка, в которой остановится меню при движении назад
	private float startPoint;
	//Флажки для контроля движения меню
	private bool moveBar = false;
	private bool moveBack = false;
	//Вектор, отвечай за движение меню.
	private Vector3 increase;
	//Переменная отвечает за размер меню, в зависимости от размера мобильного устройства
	private Vector3 scale;

	private int screenWidth;
	private int screenHeight;
	//Переменные выступают в роли bool, отвечают за показ достижений.
	private int firstStartOpen = 0; 
	private int firstTenOpen = 0;
	private int firstFiftyOpen = 0;
	private int wowHundredOpen = 0;
	private int goldThousandOpen = 0;
	private int looserOpen = 0;	

	//Загружаем игровые обьекты через иерархию. Данные обьекты будут всегда находится на панели меню
	public GameObject firstStart;
	public GameObject firstTen;
	public GameObject firstFifty;
	public GameObject wowHundred;
	public GameObject goldThousand;
	public GameObject looser;
	//Переменные для поиска внешних скриптов
	private GuI callGui;
	private AchieveController callAchieve;
	// Use this for initialization
	void Start () {
		//Находим внешние скрипты
		callAchieve = FindObjectOfType<AchieveController>();
		callGui = FindObjectOfType<GuI>();

		screenWidth = Screen.currentResolution.width;
		//Подганяем размер меню под размер экрана
		scale = new Vector3(screenWidth / 350, this.transform.localScale.y, this.transform.localScale.z);
		this.transform.localScale = scale;

	}
	
	// Update is called once per frame
	void Update () {
		//Если достижение первый старт произошло.
		if(PlayerPrefs.HasKey("firstS")){
			firstStart.renderer.material.color = new Color(1,1,1,1);
		}	
		//Первые 10
		if(PlayerPrefs.HasKey("firstT")){
			firstTen.renderer.material.color = new Color(1,1,1,1);
		}
		//Первые 50
		if(PlayerPrefs.HasKey("firstF")){
			firstFifty.renderer.material.color = new Color(1,1,1,1);
		}
		//Первые 200
		if(PlayerPrefs.HasKey("firstH")){
			wowHundred.renderer.material.color = new Color(1,1,1,1);
		}	
		//1000
		if(PlayerPrefs.HasKey("firstG")){
			goldThousand.renderer.material.color = new Color(1,1,1,1);
		}		

		//Лузер
		if(PlayerPrefs.HasKey("firstL")){
			looser.renderer.material.color = new Color(1,1,1,1);
		}
		//Если двигаем меню к точке СТОП
		if(moveBar){
			//Наращиваем Х
			increase = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);	
			if(transform.position.x > stopPoint + 15){					
				transform.position = increase;
			} else {
				moveBar = false;
			}
		}
		//Если двигаем меню к точке старт
		if(moveBack){
			increase = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);	
			if(transform.position.x < startPoint){					
				transform.position = increase;
			} else {
				moveBack = false;
				//Включаем кнопки
				callGui.EnableButtons(1);
			}
		}

	}

	public void StartMoveAchiveBar(int i){
		if(i == 1){
			moveBar = true;
		}
	}
	//getting position to move chieve bar. Takes open Ahievement first start
	public void GetPosition(float i){
		stopPoint = i;
		startPoint = transform.position.x;
	}

	public void MoveBack(){
		moveBack = true;
	}

}
