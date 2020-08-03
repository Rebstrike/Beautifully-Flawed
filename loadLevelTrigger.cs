using UnityEngine; using UnityEngine.SceneManagement;  public class loadLevelTrigger : MonoBehaviour {     public string sceneToLoadName;     public GameObject[] movables;     public LevelManager levelManagerScript;          private Collider playerCollider;      private void OnEnable() => SceneManager.sceneLoaded += OnLevelLoaded;

    private void Start() => playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();

    private void OnTriggerEnter(Collider collider)     {         if (collider == playerCollider && SceneManager.GetActiveScene().name != sceneToLoadName)         {             SceneManager.LoadSceneAsync(sceneToLoadName, LoadSceneMode.Additive);         }     }      private void OnLevelLoaded(Scene sceneLoaded, LoadSceneMode mode)
    {
        levelManagerScript.levelLoaded = sceneLoaded;
        SceneManager.SetActiveScene(sceneLoaded);

        for (int i = 0; i < movables.Length; i++)
        {
            GameObject obj = movables[i];
            SceneManager.MoveGameObjectToScene(obj, sceneLoaded);
        }

        levelManagerScript.DefineVariables();
    } }