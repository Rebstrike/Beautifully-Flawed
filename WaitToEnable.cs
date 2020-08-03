using UnityEngine;
public class WaitToEnable : MonoBehaviour
{
    public float timeToWait;
    [HideInInspector] public bool timesUp;
    
    void Update()
    {
        if(Time.time >= timeToWait)
        {
            timesUp = true;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<CapsuleCollider>().enabled = true;
            foreach(MonoBehaviour script in gameObject.GetComponents<MonoBehaviour>()) 
            {
                script.enabled = true;
            }
         }
    }
}