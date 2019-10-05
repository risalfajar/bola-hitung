using UnityEngine;
using System.Collections;

public class GUITextScript : MonoBehaviour {

	private Transform parent;
	private Camera cameras;
	private GameObject myBall;

	// Use this for initialization
	void Awake () {
		myBall = transform.parent.gameObject;
		parent = myBall.GetComponent<Transform>();
		cameras = Camera.main;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = cameras.WorldToViewportPoint(parent.position);
	}
}
