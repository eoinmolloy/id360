using UnityEngine;
using System.Collections;

public class timedInputObject : MonoBehaviour, timedInputHandler {

	// Use this for initialization
	void Start () {
		//GetComponent<Renderer> ().material.color = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HandleTimedInput(){
		Application.LoadLevel("room3");
		//GetComponent<Renderer> ().material.color = Color.red;
			
	}
}
