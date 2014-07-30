using UnityEngine;
using System.Collections;


public class CharcaterControll : MonoBehaviour {
	//Скорость полета демона вперед.
	public float speed = 0.20f;
	//Скорость полета демонна вверх,вниз.
	private float vertical = 0;
	//Переменная для передачи скоростей демону
	private Vector3 moveDirection;
	//Bird angle when it rotates
	private int rotateUp;
	//Таймер, который дает демону временную неуязвимость после столкновения с препятствием
	private int timer = 80;
	//Таймер, который определяет сколько будет неуязвим демон
	private int immortalTimer = 200;
	//Переменная отвечает за изменение цвета демона
	private float growUp;
	//Variable for collision detect
	public Collision collision;
	//Varible for call method from GuI script
	public GuI callGui;
	public LeverController lc;
	//Varible that allows to play
	private bool check = false;
	private bool stopPlay = true;
	private bool removeHealth = false;
	private bool die = false;
	private bool collisionSoundPlay = true;
	private bool changeDemonColor = false;
	private bool flagChangeColor = true;
	//Флажок, который отвечает за включения бессмертия игрока
	public bool immortalDemon = true;
	//Обьект(подобьект в обьекте игрока), отвечающий за цвет демона
	public GameObject demonColor;
	//Звук, который активируется после пролета игроком в арку
	public GameObject collisionAudio;
	//Переменная для поиска контроллера, который отобразит оба меню после смерти
	private InstantinateMenus instMenus;
	//Переменная для поиска скрипта меню достижений
	private achieveBar aBar;
	//Переменная для поиска скрипта меню магазина
	private ShopMenu callShop;

	void Start(){
		//Находим скрипт, который отобразит оба меню
		instMenus = FindObjectOfType<InstantinateMenus>();
		//Изначально демон смертный
		immortalDemon = false;
		//Находим скрипт, который отвечает за меню достижений
		aBar = FindObjectOfType<achieveBar>();	
		//Находим скрипт, который отвечает за меню магазина
		callShop = FindObjectOfType<ShopMenu>();
		growUp = 1;
		//Изначальный цвет демона красный r = 1.
		demonColor.renderer.material.color = new Color(1,0,0);
		//Время, которое демон будет бессмертным во время включения Immortal
		immortalTimer = 1000;
	}
	// Update is called once per frame
	void Update () {
		//Если игра не окончена
		if(stopPlay){
			//Проигрываем анимацию полета
			animation.CrossFade("Fly");
		}
			//Если нажата кнопка мыши(монитор устройства Touch), и игра не окончена
			if (Input.GetMouseButtonDown(0) && stopPlay){
				//ПРоигрываем звук взамаха крыльев
				audio.Play();
				//Демон подлетает вверх
				vertical = 0.4f;
				//Изменение скорости проигрывания анимации полета демона
				animation["Fly"].speed = 3f;
				//Check изначально False
				if(!check){
					//Обращаемся в скрипт ГУИ, прячем текст GetReady
					callGui.HideGetReady();
					//Обращаемся в скрипт LevelController, начинаем генерировать стены
					lc.startWallGenerate();
				}

				check = true;
				
			}
			//Демон постоянно падает вниз
			if(check){
				vertical -= 0.025f;
			}
			//Записываем параметры передвижения передвижения демона
			moveDirection = new Vector3(speed, vertical, 0);
			//Находим CharacterController у демона
			CharacterController controller = GetComponent<CharacterController>();
			//Передаем контроллеру параметры передвижения
			controller.Move(moveDirection);
			//Фиксируем максимальную скорость падения демона
			if(vertical < -0.6f){
				vertical = -0.6f;
			}	
		//Если неуязвимость закончилась
		if(immortalTimer <= 0){
			//Обноваляем таймер
			immortalTimer = 1000;
			//Делаем демона уязвимым
			immortalDemon = false;
			//Разрешаем игроку включать неуязвимость
			callGui.isImmortal = false;
		}
		//Если демон неуязвим
		if(immortalDemon){
			//Меняем цвет на белый
			demonColor.renderer.material.color = new Color(1,1,1);
			//Уменьшаем таймер отвечающий за неуязвимость
			immortalTimer -= 1;
		//Если демон уязвим
		} else {
			//Если необхоидмо отнять жизнь
			if(removeHealth){
				//Если игра не окончена
				if(stopPlay){
					//Понижаем таймер, который отвечает за временную неуязвимость демона
					timer -= 1;	
				} else {
					//Не меняем цвет демона(Мигание)
					changeDemonColor = false;
				}
			}
			//Если таймер отвечающий за временную неуязвимость меньше 0
			if(timer <= 0){
				timer = 80;
				//Отнимаем у игрока 1 жизнь
				callGui.health -= 1;
				//Записываем количество жизней в кеш
				PlayerPrefs.SetInt("health", callGui.health);
				PlayerPrefs.Save();
				//Выключаем необходимость жизнь отнять
				removeHealth = false;
				//Даем добро на проигрывание звука столкновения
				collisionSoundPlay = true;
				//Заканчиваем мигание демона
				changeDemonColor = false;
				//Если у игрока закончились жизни и игра окончена
				if(callGui.health < 1 && stopPlay ){	
					//Жизни присваеваем 0
					callGui.health = 0;
					//Переходим на жизни, которые не обнуляются при начале игры(Инфинити)
					callGui.infinity -= 1;
					//Если инфинити закончились
					if(callGui.infinity < 1){
						callGui.infinity = 0;
						//Говорим, что демон умер
						die = true;	
					}
				}
			}
			//Если необходимо изменить цвет демона
			if(changeDemonColor){
				//Флажок для выполнения цикла анимации
				if(flagChangeColor){
					//Пока (красный цвет), меньше либо равен 1
					if(demonColor.renderer.material.color.r <= growUp){						
						//Понижаем красный, до момента пока демон не станет черным
						growUp -= 0.1f;						
						//Когда демон стал черным
					} if(demonColor.renderer.material.color.r <= 0){
						//Меняем цикл в обратную сторону, и делаем демона красынм
						flagChangeColor = false;
					}
				} else {
					growUp += 0.1f;
					//Когда демон стал максимально красным, включаем цикл по новой
					if(demonColor.renderer.material.color.r >= 1.5f){
						flagChangeColor = true;
					}
				}					
				//Передаем изменения переменной в цикле обьекту демона
				demonColor.renderer.material.color = new Color(growUp, 0, 0);
			} else {
				//Если анимация мигания окончена, делаем демона красным
				demonColor.renderer.material.color = new Color(1,0,0);
			}
		}
	}
	//Метод, который вызывается в момент столкновения демона с обьектами
	public void OnControllerColliderHit(ControllerColliderHit hit){	
		if(immortalDemon){
		} else {
			//Если демон уязвим
			if(collisionSoundPlay){
				//Изначально ТРУ
				if(stopPlay){
					//Проигрываем звук столкновения
					collisionAudio.audio.Play();
					//Разрешаем мигать демону
					changeDemonColor = true;
					//Флажок, который позволяет проиграть звук столкновения 1 раз
					collisionSoundPlay = false;
				}
			}
			//Запускаем процесс отнятия жизней,мигания,минимальной неуязвимости
			removeHealth = true;
		}
		//Если демон умер. Все жизни равны 0
		if(die){	
			//Добавляем из префабов меню достижений и магазин
			instMenus.CreateMenus();
			//Говорим ГУИ об окончании игры
			callGui.MakeGameOver();
			//Прячем очки вверху по центру
			callGui.HidePoints ();
			//Ставим скорость демона на 0
			speed = 0;	
			//Выключаем анимацию полета
			animation.Stop("Fly");
			//Выключаем флажок, который блокирует основные действия
			stopPlay = false;
			//Делаем весь список под данным флажком всего один раз
			die = false;
			//Выключаем возможность проигрывания звука
			collisionSoundPlay = false;
			//Удаляем из КЕША переменную жизней.
			PlayerPrefs.DeleteKey("health");
		}


		
	}
	
}