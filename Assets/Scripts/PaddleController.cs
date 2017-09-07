using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		mousePosInBlocks = Mathf.Clamp (mousePosInBlocks, 0.5f, 15.5f);
		Vector3 paddlePos = new Vector3(mousePosInBlocks, 0.5f, 0);
		this.transform.position = paddlePos;
	}
}
