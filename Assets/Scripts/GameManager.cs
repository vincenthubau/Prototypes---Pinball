using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	public int playerLives = 3;
	bool paused = false;
	public static GameManager gameManager;

	GameObject lifeTextObject;
	Text lifeText;
	public GameObject pauseCanvas;
	public GameObject gameOverCanvas;

	void Awake(){
		gameManager = this;
		lifeTextObject = GameObject.Find("LifeText");
		lifeText = lifeTextObject.GetComponent<Text>();
		if(Time.timeScale == 0){
			Time.timeScale = 1;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(playerLives <=0){
			GameOver();
		}

		//Pause the game
			if(Input.GetButtonUp("Pause")){
				PauseGame();
		}
	}

	public void PauseGame(){
		if(paused){
			pauseCanvas.SetActive(false);
			Time.timeScale = 1;
			paused = false;
		}
		else{
			Time.timeScale = 0;
			paused = true;
			pauseCanvas.SetActive(true);
		}
	}

	void GameOver(){
		Time.timeScale = 0;
		gameOverCanvas.SetActive(true);
	}

	void LoseLife(){
		Debug.Log("I'm dead");
		playerLives--;
		lifeText.text = "Lifes:\n" + playerLives;
	}
}
