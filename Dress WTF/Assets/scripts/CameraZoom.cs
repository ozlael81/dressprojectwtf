using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	public float maxDist = 20;
	public float speed = 1;
	float moved = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.mouseScrollDelta.y != 0) {
			//Debug.Log ( "mid : " + Input.mouseScrollDelta.x + " " + Input.mouseScrollDelta.y);
			Move ( Input.mouseScrollDelta.y);
		}
	}

	void Move( float delta) {
		Transform trans = gameObject.GetComponent<Transform>();
		float len = delta * speed;
		if( len < 0 && moved <= 0)
			return;
		if( len > 0 && moved >= maxDist)
			return;
		moved += len;
		trans.position += trans.forward * len;
	}
}
