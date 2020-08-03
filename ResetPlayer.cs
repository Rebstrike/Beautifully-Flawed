using UnityEngine;

public class ResetPlayer : MonoBehaviour {
    [HideInInspector] public bool collidedWithCheckpoint = false;
    [HideInInspector] public GameObject lastKnownCheckpoint;
    [HideInInspector] public Collider reseter;

    private Transform playerTrans;
    private Vector3 originalPlayerPos;

    private void OnEnable(){
        playerTrans = gameObject.GetComponent<Transform>();
        originalPlayerPos = playerTrans.transform.position;
        reseter = GameObject.FindGameObjectWithTag("Reset trigger").GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == reseter)
        {
            Reset();
        }
    }

    public void Reset()
    {
        if (collidedWithCheckpoint)
        {
            playerTrans.transform.position = lastKnownCheckpoint.transform.position;
        }
        else
        {
            playerTrans.transform.position = originalPlayerPos;
        }
    }
}
