using UnityEngine;

public class Die : MonoBehaviour
{
    public bool died = false;

    private ResetPlayer resetPlayerScript;

    private void Start()
    {
        resetPlayerScript = GetComponent<ResetPlayer>();
    }

    private void OnTriggerEnter(Collider triggerCollidedWith)
    {
        if(triggerCollidedWith.gameObject.tag == "Death Trigger")
        {
            died = true;
            resetPlayerScript.Reset();
        }
    }
}
