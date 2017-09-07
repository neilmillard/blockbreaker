using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	private PaddleController paddle;
	private Rigidbody2D rb;

	private Vector3 paddleToBallVector;
	private bool gameStarted;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		paddle = GameObject.FindObjectOfType<PaddleController>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(gameStarted == false){
			this.transform.position = paddle.transform.position + paddleToBallVector;

			if (Input.GetMouseButtonDown (0)) {
				print ("mouse button click");
				gameStarted = true;
				rb.velocity = new Vector2(2f,10f);
			}

		}

	}
}
