using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour {
	public Transform player;
	public Vector3 pivot;
	private new GameObject camera;
	private Transform cameraTrans;
	
	// Use this for initialization
	void Start () {
		camera = this.gameObject;
		cameraTrans = this.gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		camera.transform.LookAt(player);
		
		if (player.transform.hasChanged){
			cameraTrans.transform.Translate(player.position - pivot);
		}
	}
}
