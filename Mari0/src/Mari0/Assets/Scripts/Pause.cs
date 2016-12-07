using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour {

	public string mainMenu;

	public GameObject pauseCanvas;

	public GameObject deadCanvas;

	public bool isPaused;

	public bool isDead;

	public void Home(){
		SceneManager.LoadScene("MainMenu");
	}

	IEnumerator WaitDead() {
		Stop ();
		yield return new WaitForSeconds(3 * Time.timeScale);
		isDead = false;
	}

	public void Stop(){
		Time.timeScale = 0.0000001f;
		AudioListener.pause = true;
	}

	public void Resume(){
		Time.timeScale = 1f;
		AudioListener.pause = false;
	}
	void Start(){
		isPaused = false;
		isDead = true;
	}

	// Update is called once per frame
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

	void OnTriggerEnter2D(Collider2D other){
      //  if(other.gameObject.transform.position.y > 6.5) {
            SceneManager.LoadScene("Level1");
            isDead = true;
       // }
        
		
	}
}
