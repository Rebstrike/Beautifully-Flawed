using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using RS = UnityEngine.RemoteSettings;

public class CheckForUpdates : MonoBehaviour
{
    public int current_build;
    public GameObject updateCanvas;
    public Text updateText;
    public Animator VisualTrick;

    private int Latest_Build;

    private void OnEnable()
    {
        RS.Completed += AfterChecked;
    }

    private void AfterChecked(bool wasUpdatedFromServer, bool settingsChanged, int serverResponse){
        Latest_Build = RS.GetInt("Latest_Build");
        if(Latest_Build > current_build){
            updateCanvas.SetActive(true);
            StartCoroutine(AnimateVisualTrick());
            gameObject.SetActive(false);
        }
    }

    IEnumerator AnimateVisualTrick(){
        VisualTrick.Play("Fade_In");
        yield return null;
    }
}
