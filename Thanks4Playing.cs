using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Thanks4Playing : MonoBehaviour
{
    public Collider thanks4PlayingTrigger;
    public Animator visualTrick;
    public GameObject thanks4playingCanvas;
    public AnimationClip FadeInClip;

    private void OnEnable()
    {
        thanks4PlayingTrigger = GameObject.Find("Thanks4PlayingTrigger").GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other){
        if (other == thanks4PlayingTrigger)
        {
            thanks4playingCanvas.SetActive(true);
            StartCoroutine(DoAnimation());
        }
    }

    IEnumerator DoAnimation()
    {
        visualTrick.Play("Fade_In");
        yield return new WaitForSeconds(FadeInClip.length);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene("Main Menu");
    }
}
