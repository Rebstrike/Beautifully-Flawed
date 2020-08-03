using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public GameObject player;

    public ResetPlayer resetPlayerScript;
    public Collider playerCollider;

    private void OnEnable(){
        player = GameObject.FindGameObjectWithTag("Player");
        playerCollider = player.GetComponent<Collider>();
        resetPlayerScript = player.GetComponent<ResetPlayer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other = playerCollider)
        {
            resetPlayerScript.collidedWithCheckpoint = true;
            resetPlayerScript.lastKnownCheckpoint = gameObject;
        }
    }
}
