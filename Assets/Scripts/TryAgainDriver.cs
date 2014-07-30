using UnityEngine;
using System.Collections;

public class TryAgainDriver : MonoBehaviour {

	void OnClick(){
		GameController.Restart();
	}
}
