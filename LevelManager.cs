using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string lastLevelName;
    public Thanks4Playing thanks4PlayingScript;

    [HideInInspector] public Scene levelLoaded;

    private ResetPlayer resetPlayerScript;

    private void Start() => DefineVariables();

    public void DefineVariables()
    {
        resetPlayerScript = gameObject.GetComponent<ResetPlayer>();
        resetPlayerScript.reseter = GameObject.FindGameObjectWithTag("Reset trigger").GetComponent<Collider>();

        if (levelLoaded.name == lastLevelName)
        {
            thanks4PlayingScript.enabled = true;
        }
    }
}