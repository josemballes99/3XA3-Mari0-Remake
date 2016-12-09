using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {


	/**
	 * A string type
	 */
	public string startLevel;

	/**
	 * A string type
	 */
	public string settingsLevel;


	/**
	 * A string type
	 */
	public string helpLevel;

	/**
	 * A string type
	 */
	public string mainMenu;

	/**
	 * A method that will load the start level
	 */ 
	public void NewGame(){
		Application.LoadLevel (startLevel);
	}

	/**
	 * A method that will load the help menu
	 */ 
	public void Help(){
		Application.LoadLevel (helpLevel);
	}

	/**
	 * A method that will load the main menu
	 */ 
	public void Home(){
		Application.LoadLevel (mainMenu);
	}
}
