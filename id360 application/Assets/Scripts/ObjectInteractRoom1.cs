using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
[RequireComponent(typeof(AudioSource))]
public class ObjectInteractRoom1 : MonoBehaviour {
		float timer;
		float gazeTime = 3.0f;
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
		//controls when the reticle passes over object
		public void PointerEnter(){
			Debug.Log ("Entered");
			gazedAt = true;
			timer = 0f;
		}
		//when the reticled exits object area
		public void PointerExit(){
			Debug.Log ("Exit");
			gazedAt = false;
		}
		//controls clicking of object
		public void PointerDown(){
			Debug.Log ("Clicked");

			//Finding all other buttons in scene to make them invisible
			GameObject box1 = GameObject.Find ("exit");
			GameObject box2 = GameObject.Find ("Room1Move");


			//original size of buttons
			Vector3 normScale = new Vector3(1, 1, 4);

			//Transform obj = transform.position;
			if (skybox == true) {
				//Video Player
				Instantiate (prefab, new Vector3(0, 1, 0), Quaternion.identity);

				RenderSettings.skybox = headPiece;
				skybox = false;

				//This section controls making the buttons dissappear when interacted with, they are scalled to a valued which is so small it cannot be seen
				Vector3 scaleSmaller = new Vector3(0.01f, 0.01f, 0.01f);

				box1.transform.localScale = scaleSmaller;
				box2.transform.localScale = scaleSmaller;

				this.transform.Rotate (0, 270, 0);
				Vector3 temp = new Vector3 (0.06f, 0.7f, -15.0f);
				gameObject.transform.position = temp;
				AudioSource audio = GetComponent<AudioSource>();
				audio.Play(88200);


			} else {
				RenderSettings.skybox = centre;
				skybox = true;
				gameObject.transform.position = pos;

				//resizing buttons to normal scale
				box1.transform.localScale = normScale;
				box2.transform.localScale = normScale;

				this.transform.Rotate (0, -270, 0);
			}
		}
}
