using UnityEngine;

public class ResetTrigger : MonoBehaviour {

    private GameObject player;
    private Collider playerCollider;
    private ResetPlayer resetPlayerScript;

    private void OnEnable(){
        player = GameObject.FindGameObjectWithTag("Player");
        playerCollider = player.GetComponent<Collider>();
        resetPlayerScript = player.GetComponent<ResetPlayer>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider = playerCollider)
        {
            resetPlayerScript.Reset();
        }
    }
}