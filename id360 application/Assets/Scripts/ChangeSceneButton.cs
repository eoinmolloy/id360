using UnityEngine;
using System.Collections;

public class ChangeSceneButton : MonoBehaviour {


	public void onClick(){
		Application.LoadLevel ("room1");
		Debug.Log ("Hit");
	}

	void OnMouseDown(){
		Application.LoadLevel ("room1");

	}
}
