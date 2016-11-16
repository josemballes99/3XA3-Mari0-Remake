using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public string mainMenu;

	public GameObject pauseCanvas;

	public bool isPaused;

	public void Home(){
		Application.LoadLevel (mainMenu);
	}

	public void Resume(){
		isPaused = false;
	}
	void Start(){
		isPaused = true;
	}

	// Update is called once per frame
	void Update () {
		if (isPaused) {
			pauseCanvas.SetActive (false);
		} else {
			pauseCanvas.SetActive (true);
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			isPaused = !isPaused;
		}
	}
}
