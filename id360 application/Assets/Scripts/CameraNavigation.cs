using UnityEngine;
using System.Collections;

public class CameraNavigation : MonoBehaviour {
	private Transform cameraTransform;
	private Transform cameraRotate;

	void Start(){
		cameraTransform = Camera.main.transform;
	}

	void Update(){
		if (cameraRotate != null) {
			cameraTransform.rotation = Quaternion.Slerp (cameraTransform.rotation, cameraRotate.rotation, 4 * Time.deltaTime);
		}
	}

	public void camLookAt(Transform target){
		cameraRotate = target;
	}

}
