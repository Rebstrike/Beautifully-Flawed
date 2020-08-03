using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnEnableandMainMenu : MonoBehaviour
{

    private GameObject visualTrick;
    private IEnumerator fadeCanvas;

    private void OnEnable()
    {
        visualTrick = this.gameObject;
        fadeCanvas = FadeCanvas();
        StartCoroutine(fadeCanvas);
    }

    IEnumerator FadeCanvas()
    {
        float timer = 0;
        float duration = 2f;
        GameObject myCanvas = visualTrick;
        Color canvasColor = myCanvas.GetComponent<Image>().color;
        Color newColor = new Color(canvasColor.r, canvasColor.g, canvasColor.b, 0f);
        while (duration < timer)
        {
            myCanvas.GetComponent<Image>().color = Color.Lerp(myCanvas.GetComponent<Image>().color, newColor, timer / duration);
            timer += Time.unscaledDeltaTime;
            yield return null;
            Debug.Log("Timer: " + timer.ToString());
        }
    }
}
