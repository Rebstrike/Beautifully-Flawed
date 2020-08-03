using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject FPSCounter;
	public GameObject pauseMenu;
    public GameObject settingsCanvas;

    void Start () {
		if(FPSCounter.activeInHierarchy == false)
		{
            FPSCounter.SetActive(true);
		}
		if(pauseMenu.activeInHierarchy == true)
		{
			pauseMenu.SetActive(false);
		}
	}

	void Update () {
		if (Input.GetButtonDown("Pause"))
		{
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
		}
	}

	public void Resume()
	{
		Time.timeScale = 1;
		pauseMenu.SetActive(false);
		FPSCounter.SetActive(true);
	}

	public void GoToMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
	}

    public void Settings()
    {
        pauseMenu.SetActive(false);
        settingsCanvas.SetActive(true);
    }

    public void OgMenu(string ogCanvas)
    {
        GameObject.Find(ogCanvas).SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Quit()
	{
		Application.Quit();
	}
}