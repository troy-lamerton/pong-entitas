using UnityEngine;

public class PauseContinueGame : MonoBehaviour {

	[SerializeField]
	private GameObject pausePanel;

	void Start() {
		pausePanel.SetActive(false);
		Debug.Log ("esceeas");
	}
	void Update() {
		if(Input.GetKeyDown (KeyCode.Escape)) {
			Debug.Log ("esc");
			if (!pausePanel.activeInHierarchy) {
				PauseGame();
			} else {
				ContinueGame();   
			}
		} 
	}
	void PauseGame() {
		Time.timeScale = 0;
		pausePanel.SetActive(true);
		//Disable scripts that still work while timescale is set to 0
	} 
	void ContinueGame()	{
		Time.timeScale = 1;
		pausePanel.SetActive(false);
		//enable the scripts again
	}
}
