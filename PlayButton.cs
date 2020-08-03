using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

    public void loadLevel(string sceneToLoad)
    {
        StartCoroutine(LoadAsync(sceneToLoad));
    }

    IEnumerator LoadAsync(string sceneToLoad)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Single);

        while (!operation.isDone) {
            Debug.Log(operation.progress);

            yield return null;
        }
    }
}
