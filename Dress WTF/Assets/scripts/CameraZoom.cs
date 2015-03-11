using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	public float maxDist = 20;
	public float speed = 1;
	public float speedResistanceRatio = 0.95f;
	private float moved = 0;

	private SmoothSpeedFactor smoothSpeed;

	// Use this for initialization
	void Start () {
		smoothSpeed = new SmoothSpeedFactor( speed, speedResistanceRatio);
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.mouseScrollDelta.y != 0) {
			//Debug.Log ( "mid : " + Input.mouseScrollDelta.x + " " + Input.mouseScrollDelta.y);
			StartToMove( Input.mouseScrollDelta.y);
		}
		UpdateMove ();
	}

	void StartToMove( float delta) {
		smoothSpeed.StartToMove( delta);
	}

	void UpdateMove() {
		smoothSpeed.updateSpeed();
		if( smoothSpeed.GetCurrentSpeed() == 0)
			return ;
		Debug.Log( "currSpeed = " + smoothSpeed.GetCurrentSpeed());
		Transform trans = gameObject.GetComponent<Transform>();
		float len = smoothSpeed.GetCurrentSpeed();
		if( len < 0 && moved <= 0)
			return;
		if( len > 0 && moved >= maxDist)
			return;
		moved += len;
		trans.position += trans.forward * len;
	}
	
}
