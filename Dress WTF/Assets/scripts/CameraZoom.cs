using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	public float maxDist = 20;
	public float speed = 1;
	public float speedResistanceRatio = 0.95f;
	private float speedResistance;
	private float currSpeed = 0;
	private float moved = 0;
	private float currDirection = 0;

	// Use this for initialization
	void Start () {
		speedResistance = speed * speedResistanceRatio;
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.mouseScrollDelta.y != 0) {
			//Debug.Log ( "mid : " + Input.mouseScrollDelta.x + " " + Input.mouseScrollDelta.y);
			StartToMove( Input.mouseScrollDelta.y);
		}
		UpdateResistance();
		UpdateMove ();
	}

	void StartToMove( float delta) {
		if( delta == 0)
			return;
		else if( delta < 0 )
			currDirection = -1;
		else if( delta > 0)
			currDirection = 1;
		currSpeed = Mathf.Abs(delta) * speed;
	}

	void UpdateResistance() {
		currSpeed -= speedResistance * Time.deltaTime;;
		if( currSpeed < 0)
			currSpeed = 0;
	}

	void UpdateMove() {
		if( currSpeed == 0)
			return ;
		//Debug.Log( "currSpeed = " + currSpeed + " dir : " + currDirection);
		Transform trans = gameObject.GetComponent<Transform>();
		float len = currSpeed * currDirection;
		if( len < 0 && moved <= 0)
			return;
		if( len > 0 && moved >= maxDist)
			return;
		moved += len;
		trans.position += trans.forward * len;
	}
	
}
