using UnityEngine;
using System.Collections;

public class GuI : MonoBehaviour
{

		private bool callGameOver = false;
		private bool isShowGetReady = true;
		private bool isShowPoint = true;
		public bool isImmortal = false;
		private int clickCalculate;
		//Количество очков
		private int points = 49;
		//Количество лучших очков
		private int bestPoints = 0;
		//Переменная монетки
		public int coins = 0;
		//Переменная жизни
		public int health = 1;
		//Переменная бескончаемые жизни
		public int infinity = 1;
		//Переменная количества неуязвимости
		public int immortal = 1;
		//Гуи текстуры
		public GUITexture getReady;
		public GUITexture gameOver;
		public GUITexture buttonTry;
		public GUITexture buttonAchievements;
		public GUITexture buttonShop;
		public GUITexture heartTexture;
		public GUITexture infinityHeartIcon;
		public GUITexture immortalIcon;
		//Стили для отображения ГУИ текстур и текста
		public GUIStyle pointStyle;
		public GUIStyle getReadyStyle;
		public GUIStyle pointStyleEnd;
		public GUIStyle buttonStyle;
		//Переменные для сохранения параметров стартовой точки (Х,У) и ширина высота обьектов ГУИ
		private Rect pointRect;
		private Rect getReadyRect;
		private Rect scoreRect;
		private Rect bestScoreRect;
		private Rect coinsRect;
		private Rect healthRect;
		private Rect infinityRect;
		private Rect immortalRect;
		public Rect buttonRect;
		//Переменная, которая отвечает за подсчет количества падений для достижения Loser
		private int calculateFall = 0;
		
		public float buttonWidth = 0;
		public float buttonHeight = 0;
		public int buttonX = 20;
		public int buttonY = 20;		
		private int screenWidth;
		private int screenHeight;
		//Переменные для обращения в другие срипты
		private ShopMenu callShop;
		private achieveBar aBar;
		private AchieveController callAchieve;
		public CharcaterControll callCharacter;
			
void Start ()
{
		//Достаем значения переменных из кеша
		coins = PlayerPrefs.GetInt("coins");
		health = PlayerPrefs.GetInt("health");
		immortal = PlayerPrefs.GetInt("immortal");
		infinity = PlayerPrefs.GetInt("infinity");
		screenHeight = Screen.currentResolution.height;
		screenWidth = Screen.currentResolution.width;	
		//PlayerPrefs.DeleteAll();
		if(health < 10){
			health += 1;
		}
		isImmortal = false;
		//Не отображать текст GameOver
		gameOver.enabled = false;
		//Находим скрипт AchieveController.
		callAchieve = FindObjectOfType<AchieveController>();

		//Расположение ГУИ обьектов по экрану...
		pointRect = new Rect (screenWidth * 50 / 100, screenHeight * 4 / 100, screenWidth * 40 / 100, screenHeight * 7 / 100);
		scoreRect = new Rect (screenWidth* 35 / 100, screenHeight * 36 / 100, screenWidth * 20 / 100, screenHeight * 10 / 100);
		bestScoreRect = new Rect (screenWidth * 35 / 100, screenHeight * 41 / 100, screenWidth * 20 / 100, screenHeight * 10 / 100);
		coinsRect = new Rect (screenWidth * 35 / 100, screenHeight * 46 / 100, screenWidth * 20 / 100, screenHeight * 10 / 100);
		buttonRect = new Rect (Screen.width * buttonX / 100, Screen.height * buttonY / 100, Screen.width * buttonWidth / 100, Screen.height * buttonHeight / 100);
		gameOver.pixelInset = new Rect(-screenWidth*32/100, screenHeight*9/100, screenWidth*18/100, screenWidth*10/100);
		healthRect = new Rect(screenWidth * 2.5f / 100, screenHeight * 9 / 100, screenWidth * 40 / 100, screenHeight * 7 / 100);
		infinityRect = new Rect(screenWidth * 2.5f / 100, screenHeight * 16 / 100, screenWidth * 40 / 100, screenHeight * 7 / 100);
		immortalRect = new Rect(screenWidth * 2.5f / 100, screenHeight * 24 / 100, screenWidth * 40 / 100, screenHeight * 7 / 100);
		heartTexture.pixelInset = new Rect(-screenWidth*45/100, screenHeight*35/100, screenWidth*4/100, screenWidth*3/100);
		infinityHeartIcon.pixelInset = new Rect(-screenWidth*45/100, screenHeight*27/100, screenWidth*4/100, screenWidth*3/100);
		immortalIcon.pixelInset = new Rect(-screenWidth*45/100, screenHeight*17/100, screenWidth*5/100, screenWidth*4/100);
				//Если в кеше есть лучший результат очков, достаем данное число.
				if (PlayerPrefs.HasKey ("bestPoints")) {
						bestPoints = PlayerPrefs.GetInt ("bestPoints");
				}

		}
		//Метод UpDate, только для ГУИ
		void OnGUI (){		
		//Строки для отображения количества обоих видов жизней и неуязвимости	
		GUI.Label (healthRect, health.ToString(), pointStyle);
		GUI.Label (infinityRect, infinity.ToString(), pointStyle);
		GUI.Label (immortalRect, immortal.ToString(), pointStyle);
			//Когда начинается игра, прячем текст GetReady
			if (isShowGetReady) {									
			} else {				
				getReady.enabled = false;
			}
				//Если игра закончилась
				if (callGameOver) {								
						//Отображать текст GameOver
						gameOver.enabled = true;
						//Отображаются полосы со значениями очков, лучших очков, заработаных монеток
						GUI.Label (scoreRect, "Score: " + points.ToString (), pointStyleEnd);
						GUI.Label (bestScoreRect, "BestScore: " + bestPoints.ToString (), pointStyleEnd);
						GUI.Label (coinsRect, "Coins: " + coins.ToString(), pointStyleEnd);						
						//Если левая кнопка мыши вверху(клик)
						if(Input.GetMouseButtonUp(0)){
							//Возвращаем изначальные размеры всем име.щимся кнопкам
							buttonTry.pixelInset = new Rect(-screenWidth*30/100, -screenHeight*2/100, screenWidth*12/100, screenWidth*6/100);
							buttonAchievements.pixelInset = new Rect(screenWidth*38/100, screenHeight*30/100, screenWidth*12/100, screenWidth*6/100);
							buttonShop.pixelInset = new Rect(screenWidth*38/100, screenHeight*18/100, screenWidth*12/100, screenWidth*6/100);							
							//Если координаты мыши совпали с координатами кнопки TryAgain
							if(buttonTry.HitTest(Input.mousePosition)){
								//Включаем игру по новой, сохраняем лучшие значения очков
								Application.LoadLevel (0);
								callGameOver = false;
								PlayerPrefs.SetInt ("bestPoints", bestPoints); 
								PlayerPrefs.Save ();
							//Если координаты мыши совпали с координатами кнопки Achievements
							} else if(buttonAchievements.HitTest(Input.mousePosition)){
								//Находим скрипт с достижениями 
								aBar = FindObjectOfType<achieveBar>();
								//Передаем позицию, в которую необходимо двигать меню достижений
								aBar.GetPosition(transform.position.x);
								//Передаем в скрипт, что необходимо двигать меню
								aBar.StartMoveAchiveBar(1);
								//Отключаем книпки Shop и Achievements
								EnableButtons(2);
							//Если координаты мыши совпали с координатами кнопки Shop, выполняем теже действия, которые 
							//описаны выше, только для меню магазина
							} else if(buttonShop.HitTest(Input.mousePosition)){
								callShop = FindObjectOfType<ShopMenu>();
								callShop.GetShopPosition(callCharacter.transform.position.x);
								callShop.StartMoveShopMenu(1);
								EnableButtons(2);
							}
						//Если кнопка мыши внизу, и координаты мыши совпадают с координатами одной из кнопок,
						//то увеличиваем данную кнопку в размерах
						} else if(Input.GetMouseButtonDown(0) & buttonTry.HitTest(Input.mousePosition)) {			
							buttonTry.pixelInset = new Rect(-screenWidth*31/100, -screenHeight*2/100, screenWidth*13/100, screenWidth*7/100);
						} else if(Input.GetMouseButtonDown(0) & buttonAchievements.HitTest(Input.mousePosition)){
							buttonAchievements.pixelInset = new Rect(screenWidth*37/100, screenHeight*29/100, screenWidth*13/100, screenWidth*7/100);							
						} else if(Input.GetMouseButtonDown(0) & buttonShop.HitTest(Input.mousePosition)){
							buttonShop.pixelInset = new Rect(screenWidth*37/100, screenHeight*17/100, screenWidth*13/100, screenWidth*7/100);
						} 
						
				} else {
					//Если кнопка мыши вверху, возвращаем размеру иконки бессмертия прежний размер. 
					//Еще один обработчик нажатия, потому что выше обрабатывается нажатия по окончанию игры
					if(Input.GetMouseButtonUp(0)){
						immortalIcon.pixelInset = new Rect(-screenWidth*45/100, screenHeight*17/100, screenWidth*5/100, screenWidth*4/100);
					//Если нажата кнопка мыши, и координаты мыши совпадают с координатами иконки бессмертия
				} else if(Input.GetMouseButtonDown(0) & immortalIcon.HitTest(Input.mousePosition)){
						//Увеличиваем иконку в размерах
						immortalIcon.pixelInset = new Rect(-screenWidth*46/100, screenHeight*18/100, screenWidth*6/100, screenWidth*5/100);
						//Если у игрока имеется в запасе неуязвимость
						if(immortal > 0){
							//Если он уязвим
							if(!isImmortal){
								//Передаем в скрипт CharacterControll, что демон неуязвим
								callCharacter.immortalDemon = true;
								//Понижаем количество возможных неуязвимостей
								immortal -= 1;
								//Сохраняем количество возможных неуязвимостей
								PlayerPrefs.SetInt("immortal", immortal);
								PlayerPrefs.Save();
								//Включаем неуязвимость для гуи, чтобы лишний раз не понижалась цифра возможных неуязвимостей
								isImmortal = true;
							} 
						}	
					}
				}
				//Отображение текущего количества очков	
				if (isShowPoint) {
					GUI.Label (pointRect, points.ToString (), pointStyle);					
				}
				//Обработка кнопки назад на мобильном устройстве, которая закрывает игру
				if(Input.GetKeyUp(KeyCode.Escape)){
					Application.Quit();
				}
		}
		//Включение кнопок(отображение) TryAgain, Achievements, Shop.
		private void EnableButtonTry(int i){
			if(i == 1){
				buttonTry.pixelInset = new Rect(-screenWidth*30/100, -screenHeight*2/100, screenWidth*12/100, screenWidth*6/100);
				buttonAchievements.pixelInset = new Rect(screenWidth*38/100, screenHeight*30/100, screenWidth*12/100, screenWidth*6/100);
				buttonShop.pixelInset = new Rect(screenWidth*38/100, screenHeight*18/100, screenWidth*12/100, screenWidth*6/100);
			}
		}
		//Включение,выключение кнопок Achivements, Shop. Используется в момент отображения одного из двух меню
		public void EnableButtons(int i){
			if(i == 1){
				buttonAchievements.enabled = true;
				buttonShop.enabled = true;
			}
			if(i == 2){
				buttonAchievements.enabled = false;
				buttonShop.enabled = false;
			}
		}
		//Когда игра закончилась(демон умер)
		public void MakeGameOver ()
		{
				//Достаем из кеша количество падений демона
				calculateFall = PlayerPrefs.GetInt("calculateFall");
				//Включаем флажок на конец игры
				callGameOver = true;
				//Отображаем кнопки
				EnableButtonTry(1);	
				//Добавляем к количеству падений демона единицу и записываем в кеш
				calculateFall += 1;
				PlayerPrefs.SetInt("calculateFall", calculateFall);
				PlayerPrefs.Save();
				//Если количество падений поравнялось с цифрой 5, открываем достижение Loser
				if(calculateFall >= 5){
					if(!PlayerPrefs.HasKey("firstL")){
						callAchieve.PointsAchieve(5);
					}
				}
				//Обрабатывается первое падение. Достижение FirstStart
				if(!PlayerPrefs.HasKey("firstS")){
					callAchieve.PointsAchieve(6);
				}
		}
		//Метод добавляет очки игроку
		public void AddPoint ()
		{
				points += 1;
				coins += 1;
				//Сохраняем монетки в кеш
				PlayerPrefs.SetInt("coins", coins);
				PlayerPrefs.Save();
				//Удаляем из кеша число падений
				PlayerPrefs.DeleteKey("calculateFall");					
				//Если количество набранных очков больше лучших очков, перезаписываем лучшие очки
				if (points > bestPoints) {
					bestPoints = points;
				}
				//Достижение первые 10
				if(points == 10){
					if(!PlayerPrefs.HasKey("firstT")){
						callAchieve.PointsAchieve(1);
					}
				} 
				//Достижение 50
				if(points == 50){
					if(!PlayerPrefs.HasKey("firstF")){
						callAchieve.PointsAchieve(2);
					}
				}
				//Достижение 200
				if(points == 200){
					if(!PlayerPrefs.HasKey("firstH")){
						callAchieve.PointsAchieve(3);
					}
				}	
				//Достижение 1000
				if(points == 1000){
					if(!PlayerPrefs.HasKey("firstG")){
						callAchieve.PointsAchieve(4);
					}
				}
		}
		//Покупка единиц
		public void BuyThing(int i){
			if(i == 1){
				//Если количество жизни меньше 10, и монеток больше 50
				//Покупка жизней
				if(health < 10 & coins > 50){
					health += 1;
					coins -= 50;
					PlayerPrefs.SetInt("health", health);
				}
			}
			if(i == 2){
				//Покупка бесконечных жизней
				infinity = PlayerPrefs.GetInt("infinity");
				if(infinity < 3 & coins > 2500){
					infinity += 1;
					coins -= 2500;	
					PlayerPrefs.SetInt("infinity", infinity);
				}
			}
			if(i == 3){
				//Покупка неуязвимости
				if(immortal < 5 & coins > 150){
					immortal += 1;
					coins -= 150;
					PlayerPrefs.SetInt("immortal", immortal);
				}
			}
			//Сохраняем текущее количество монеток
			PlayerPrefs.SetInt("coins", coins);
			PlayerPrefs.Save();
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
