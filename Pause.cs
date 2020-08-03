using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public Animator visualTrick;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (PauseMenu.activeSelf == false)
            {
                PauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        visualTrick.Play("Fade_Away");
        Time.timeScale = 1;
    }

    public void Quit2Menu(string sceneName) => SceneManager.LoadScene(sceneName);

    public void QuitGame()
    {
        Application.Quit();
    }
}
