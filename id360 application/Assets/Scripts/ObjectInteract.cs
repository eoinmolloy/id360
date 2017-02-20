using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class ObjectInteract : MonoBehaviour {
	float timer;
	float gazeTime = 2.0f;
	bool gazedAt;
	public Material headPiece;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Set boolean to run when gazedAtTrue
		if (gazedAt == true) {
			//Keeps track of time
			timer += Time.deltaTime;

			//Getting the child box which will act as transition
			Transform box = transform.GetChild (0);
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
	}

	public void PointerExit(){
		Debug.Log ("Exit");
		gazedAt = false;
	}

	public void PointerDown(){
		Debug.Log ("Clicked");
		RenderSettings.skybox = headPiece;

	}
}
