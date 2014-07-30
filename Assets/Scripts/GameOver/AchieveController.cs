using UnityEngine;
using System.Collections;

public class AchieveController : MonoBehaviour {
	//Текстура, на которую будет пременена анимация
	public GUITexture firstStartShow;
	public GUITexture firstTenShow;
	public GUITexture firstFiftyShow;
	public GUITexture wowHundredShow;
	public GUITexture goldThousandShow;
	public GUITexture looserShow;
	//Переменная, для наращивания прозрачности текстуры. Alpha
	private float growUp;
	//Флажки, для зацикливания анимации текстуры
	private bool flagFirstStart = true;
	private bool flagFirstTen = true;
	private bool flagFirstFifty = true;
	private bool flagWowHundred = true;
	private bool flagGoldThousand = true;
	private bool flagLooser = true;

	private bool flagAnimate = true;
	//Флажки, для старта анимации текстуры
	public int firstS = 0;
	public int firstT = 0;
	public int firstF = 0;
	public int firstH = 0;
	public int firstG = 0;
	public int firstL = 0;
	private int screenWidth;
	private int screenHeight;

	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteAll();
		screenWidth = Screen.currentResolution.width;
		screenHeight = Screen.currentResolution.height;
		//Стартовое расположение текстур
		firstStartShow.pixelInset = new Rect(-screenWidth*10/100, screenHeight*18/100, screenWidth*18/100, screenWidth*8/100);
		firstStartShow.color = new Color(1,1,1,0);
		
		firstTenShow.pixelInset = new Rect(-screenWidth*10/100, screenHeight*18/100, screenWidth*18/100, screenWidth*8/100);
		firstTenShow.color = new Color(1,1,1,0);
		
		firstFiftyShow.pixelInset = new Rect(-screenWidth*10/100, screenHeight*18/100, screenWidth*18/100, screenWidth*8/100);
		firstFiftyShow.color = new Color(1,1,1,0);
		
		wowHundredShow.pixelInset = new Rect(-screenWidth*10/100, screenHeight*18/100, screenWidth*18/100, screenWidth*8/100);
		wowHundredShow.color = new Color(1,1,1,0);
		
		goldThousandShow.pixelInset = new Rect(-screenWidth*10/100, screenHeight*18/100, screenWidth*18/100, screenWidth*8/100);
		goldThousandShow.color = new Color(1,1,1,0);
		
		looserShow.pixelInset = new Rect(-screenWidth*10/100, screenHeight*18/100, screenWidth*18/100, screenWidth*8/100);
		looserShow.color = new Color(1,1,1,0);
	}
	
	// Update is called once per frame
	void Update () {
		//Первый старт. Проигрываем анимацию
		if(firstS == 1){
			Animate(firstStartShow);
			PlayerPrefs.SetInt("firstS", firstS);
		} 
		//Первые 10
		if(firstT == 1){
			Animate(firstTenShow);
			PlayerPrefs.SetInt("firstT", firstT);
		} 
		//50
		if(firstF == 1){
			Animate(firstFiftyShow);
			PlayerPrefs.SetInt("firstF", firstF);
		} 
		//200
		if(firstH == 1){
			Animate(wowHundredShow);
			PlayerPrefs.SetInt("firstH", firstH);
		} 
		//1000
		if(firstG == 1){
			Animate(goldThousandShow);
			PlayerPrefs.SetInt("firstG", firstG);
		} 
		//Loser
		if(firstL == 1){
			Animate(looserShow);
			PlayerPrefs.SetInt("firstL", firstL);
		} 
		PlayerPrefs.Save();
	}

	public void PointsAchieve(int i){
		if(i == 1){
			firstT = 1;
		} 
		if(i == 2){
			firstF = 1;
		}
		if(i == 3){
			firstH = 1;
		}
		if(i == 4){
			firstG = 1;
		}
		if(i == 5){
			firstL = 1;
		}
		if(i == 6){
			firstS = 1;
		}
	}

	private void Animate(GUITexture textureAnimate){
		if(firstS == 1 || firstT == 1 || firstF == 1 || firstH == 1 || firstG ==1 || firstL == 1){	
			if(flagAnimate){
				if(textureAnimate.color.a < 1){
					growUp += 0.02f;
				} else {
					flagAnimate = false;
				}
			} else {
				growUp -= 0.02f;
			}

			if(textureAnimate.color.a < -1){
				growUp = 0;
				firstS = 0;
				firstT = 0;
				firstF = 0;
				firstH = 0;
				firstG = 0;
				firstL = 0;
			}
			textureAnimate.color = new Color(1,1,1,growUp);
		} else {
			textureAnimate.color = new Color(1,1,1,0);
			flagAnimate = true;
		}

	}

}
