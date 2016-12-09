/*! 
 *  \brief     Pause script
 *  \details   This script is used to pause the game
 *  \author    Ninetendo
 */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour {


	/**
	 * A string type
	 */ 
	public string mainMenu;

	/**
	 * A GameObject type
	 */ 
	public GameObject pauseCanvas;

	/**
	 * A GameObject type
	 */ 
	public GameObject deadCanvas;

	/**
	 * A bool type
	 */ 
	public bool isPaused;

	/**
	 * A bool type
	 */ 
	public bool isDead;

	/**
	 * A method that loads the main menu
	 */ 
	public void Home(){
		SceneManager.LoadScene("MainMenu");
	}

	/**
	 * An enumerator that stalls the game
	 */ 
	IEnumerator WaitDead() {
		Stop ();
		yield return new WaitForSeconds(3 * Time.timeScale);
		isDead = false;
	}

	/**
	 * A method that stops the time
	 */ 
	public void Stop(){
		Time.timeScale = 0.0000001f;
		AudioListener.pause = true;
	}

	/**
	 * A method that resumes the game
	 */ 
	public void Resume(){
		Time.timeScale = 1f;
		AudioListener.pause = false;
	}

	/**
	 * A method that starts the game
	 */ 
	void Start(){
		isPaused = false;
		isDead = true;
	}

	/**
	 * A method that updates once per frame and checks to see what state the game is for pausing
	 */ 
	void Update () {
		if (isPaused) {
			pauseCanvas.SetActive (true);
			Stop ();
		} else if (isDead){
			deadCanvas.SetActive (true);
			StartCoroutine(WaitDead());
		} else {
			deadCanvas.SetActive (false);
			pauseCanvas.SetActive (false);
			Resume ();
		}

		if (Input.GetKeyDown (KeyCode.P)||Input.GetKeyDown (KeyCode.Escape)) {
			isPaused = !isPaused;
		}
	}

	/**
	 * A method that loads the level through a collision trigger
	 * @param other is unused in this case and method
	 */ 
	void OnTriggerEnter2D(Collider2D other){
            SceneManager.LoadScene("Level1");
            isDead = true;
	}
}
