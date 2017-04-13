using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public string sceneName;
	public void LoadScene(string sceneName){
		SceneManager.LoadScene (sceneName);
	}
}
