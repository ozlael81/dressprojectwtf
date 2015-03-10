using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

	public float speed = 20.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetMouseButton(0))
			transform.Rotate(Vector3.up * speed * Time.deltaTime * Input.GetAxis("Mouse X"));
	}
}
