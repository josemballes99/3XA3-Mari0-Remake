using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string startLevel;

	public string settingsLevel;

	public string helpLevel;

	public string mainMenu;

	public void NewGame(){
		Application.LoadLevel (startLevel);
	}

	public void Help(){
		Application.LoadLevel (helpLevel);
	}

	public void Home(){
		Application.LoadLevel (mainMenu);
	}
}
