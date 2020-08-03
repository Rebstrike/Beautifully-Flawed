using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraPos : MonoBehaviour
{
    public GameObject player;
    public GameObject camera;
    public Vector3 newOffest;
    
    private FollowTarget followTargetScript;
    private Vector3 oldOffset;

    public void OnEnable(){
        player = GameObject.FindWithTag("Player");
        camera = GameObject.Find("Main Camera");
        followTargetScript = camera.GetComponent<FollowTarget>();
        oldOffset = followTargetScript.offset;
    }

    public void OnTriggerEnter(Collider thingThatEntered){
        Debug.Log(thingThatEntered);
        if(thingThatEntered.gameObject == player){
            followTargetScript.offset = newOffest;
        }
    }

    public void OnTriggerExit(Collider thingThatExited){
        Debug.Log(thingThatExited);
        if(thingThatExited.gameObject == player){
            followTargetScript.offset = oldOffset;
        }
    }
}
