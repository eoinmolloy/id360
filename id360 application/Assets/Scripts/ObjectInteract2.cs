using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]

public class ObjectInteract2 : MonoBehaviour {
	float timer;
	float gazeTime = 2.0f;
	bool gazedAt;
	public Material headPiece;
	public Material centre;
	bool skybox = true;
	Vector3 pos;

	public GameObject prefab;
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

	}

	public void PointerExit(){
		timer = 0f;
		Debug.Log ("Exit");
		gazedAt = false;

	}

	public void PointerDown(){
		Debug.Log ("Clicked");
		//Finding all other buttons in scene to make them invisible
		GameObject box1 = GameObject.Find ("Exibit1");
		GameObject box2 = GameObject.Find ("Exibit3");
		GameObject Exit = GameObject.Find ("ExitDoor");
		GameObject Up = GameObject.Find ("UpLev");
		GameObject down = GameObject.Find ("Downlev");

		GameObject cam = GameObject.Find ("GvrViewerMain");

		//original size of buttons
		Vector3 normScale = new Vector3(1, 1, 4);

		if (skybox == true) {
			RenderSettings.skybox = headPiece;
			skybox = false;


			//Video Player
			Instantiate (prefab, new Vector3(0, 1, 0), Quaternion.identity);

			//This section controls making the buttons dissappear when interacted with, they are scalled to a valued which is so small it cannot be seen
			Vector3 scaleSmaller = new Vector3(0.01f, 0.01f, 0.01f);

			box1.transform.localScale = scaleSmaller;
			box2.transform.localScale = scaleSmaller;
			Exit.transform.localScale = scaleSmaller;
			Up.transform.localScale = scaleSmaller;
			down.transform.localScale = scaleSmaller;

			prefab.transform.Rotate(75, 100, 0);
			this.transform.Rotate (0, 140, 0);
			Vector3 temp = new Vector3 (0.06f, 0.7f, 15.0f);
			gameObject.transform.position = temp;


			cam.transform.Rotate (0, 160, 0);
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play();
			audio.Play(88200);

		} else {
			RenderSettings.skybox = centre;
			skybox = true;

			//resizing buttons to normal scale
			box1.transform.localScale = normScale;
			box2.transform.localScale = normScale;
			Exit.transform.localScale = normScale;
			Up.transform.localScale = normScale;
			down.transform.localScale = normScale;

			gameObject.transform.position = pos;
			this.transform.Rotate (0, -140, 0);
		}
	}
}
