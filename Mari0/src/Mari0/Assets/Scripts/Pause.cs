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
			Time.timeScale = 1f;
		} else {
			pauseCanvas.SetActive (true);
			Time.timeScale = 0f;
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			isPaused = !isPaused;
		}
	}
}
