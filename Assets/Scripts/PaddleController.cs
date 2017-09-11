using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

	public bool autoPlay = false;
	private BallController ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<BallController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (autoPlay == false) {
			MoveWithMouse ();
		} else {
			AutoPlay ();
		}	
	}

	void MoveWithMouse(){
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		mousePosInBlocks = Mathf.Clamp (mousePosInBlocks, 0.5f, 15.5f);
		Vector3 paddlePos = new Vector3(mousePosInBlocks, 0.5f, 0);
		this.transform.position = paddlePos;
	}

	void AutoPlay(){
		float ballPos = ball.transform.position.x;
		Vector3 paddlePos = new Vector3(ballPos, 0.5f, 0);
		this.transform.position = paddlePos;
	}
}
