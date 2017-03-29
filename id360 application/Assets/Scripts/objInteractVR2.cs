using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class objInteractVR2 : MonoBehaviour {
	float timer;
	float gazeTime = 3.0f;
	bool gazedAt;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gazedAt == true) {
			//Keeps track of time
			timer += Time.deltaTime;

			if (timer >= gazeTime) {
				ExecuteEvents.Execute (gameObject, new PointerEventData (EventSystem.current), ExecuteEvents.pointerDownHandler);
				timer = 0f;
			}
		} 
	}

	public void PointerEnter(){
		Debug.Log ("Entered");
		gazedAt = true;

	}

	public void PointerExit(){
		timer = 0f;
		Debug.Log ("Exit");
		gazedAt = false;

	}

	public void PointerDown(){
		Application.LoadLevel ("room2");
	}
}
