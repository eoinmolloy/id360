using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ExitApplication : MonoBehaviour {

	float timer;
	float gazeTime = 2.0f;
	bool gazedAt;

	bool skybox = true;
	Vector3 pos;



	// Use this for initialization
	void Start () {
		pos = this.transform.position;
	}

	// Update is called once per frame
	void Update () {
		//Getting the child box which will act as transition
		Transform box = transform.GetChild (0);
		//Set boolean to run when gazedAtTrue
		if (gazedAt == true) {
			//Keeps track of time
			timer += Time.deltaTime;

			//setting a scale and position value based on time
			Vector3 newScale = new Vector3 (box.localScale.x, box.localScale.y, timer / gazeTime);
			Vector3 newPos = new Vector3 (box.localPosition.x, box.localPosition.y,-0.5f+(timer / gazeTime) / 2);
			box.localScale = newScale;
			box.localPosition = newPos;
			if (timer >= gazeTime) {
				ExecuteEvents.Execute (gameObject, new PointerEventData (EventSystem.current), ExecuteEvents.pointerDownHandler);
				timer = 0f;
			}
		} 
	}

	public void PointerEnter(){
		Debug.Log ("Entered");
		gazedAt = true;
		timer = 0f;
	}

	public void PointerExit(){
		Debug.Log ("Exit");
		gazedAt = false;
	}

	public void PointerDown(){
		Debug.Log ("down");
		Application.Quit();
	}
}
