using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Text m_RestartText;
	public Text m_GameOverText;
	public Text m_WinText;
	public Text m_ActivatedText;
	public bool activated;

	private bool gameOver;
	private bool restart;
	private bool win;
	private bool nextLevel;


	void Start ()
	{
		gameOver = false;
		restart = false;
		win = false;
		activated = false;
		nextLevel = false;
		m_RestartText.text = "";
		m_GameOverText.text = "";
		m_WinText.text = "";

		Debug.Log(SceneManager.sceneCountInBuildSettings);
	}

	void Update () {
		if (restart) {
			if (activated) {
			}
			if (Input.GetMouseButtonDown(0)) {
			SceneManager.LoadSceneAsync (SceneManager.GetActiveScene().buildIndex);
			}
		}

		if (nextLevel) {
			if (Input.GetMouseButtonDown(0)) {
				NextLevel();
			}
		}

		if (win) {
			this.m_RestartText.text = "Tap to go to next level";
			nextLevel = true;
		}

		if (gameOver) {
			this.m_RestartText.text = "Tap to restart";
			restart = true;
		}
	}

	void NextLevel () {
		 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void GameOver ()
	{
		this.m_GameOverText.text = "Game Over";
		gameOver = true;
	}

	public void Win ()
	{
		this.m_WinText.text = "You made it!";
		win = true;
	}

	public void ActivateDebris ()
	{
		Debug.Log("activated");
		activated = true;
	}
}
