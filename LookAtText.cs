using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtText : MonoBehaviour
{
    public Collider player;
    public Transform camera;
    public Vector3 newOffset;
    public Transform text;
    [HideInInspector] public bool hittingTrigger = false;

    private Vector3 originalOffset;

    private void OnTriggerEnter(Collider collider){
        if (collider == player)
        {
            hittingTrigger = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider == player)
        {
            camera.transform.rotation = new Quaternion(0, 0.7071068f, 0, 0.7071068f);
            hittingTrigger = false;
        }
    }
}
