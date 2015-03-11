using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

	public float speed = 20.0f;
	public float speedResistanceRatio = 0.95f;

	private SmoothSpeedFactor smoothSpeed;

	// Use this for initialization
	void Start () {
		smoothSpeed = new SmoothSpeedFactor( speed, speedResistanceRatio);
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetMouseButton(0))
			StartToRotate( Input.GetAxis("Mouse X"));
		UpdateMove();
	}

	void StartToRotate( float delta) {
		smoothSpeed.StartToMove( delta);
	}

	void UpdateMove() {
		smoothSpeed.updateSpeed();
		if( smoothSpeed.GetCurrentSpeed() == 0)
			return ;
		transform.Rotate(Vector3.up * smoothSpeed.GetCurrentSpeed());
	}
}
