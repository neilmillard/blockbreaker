using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

	public static int breakableCount = 0;
	public Sprite[] hitSprites;
	public AudioClip crack;
	public GameObject smoke;

	private int timesHit;
	private LevelManager levelmanager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// increase the breakable Bricks on load
		if (isBreakable){
			breakableCount++;
		}

		timesHit = 0;
		levelmanager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionExit2D(Collision2D col){
		// Play the audio even if the brick is destroyed
		AudioSource.PlayClipAtPoint (crack, this.transform.position);
		if (isBreakable){
			HandleHits ();
		}

	}

	void HandleHits() {
		timesHit++;
		if(timesHit >= hitSprites.Length + 1 ){
			breakableCount--;
			levelmanager.BrickDestroyed ();
			GameObject smokePuff = Instantiate (smoke,gameObject.transform.position,Quaternion.identity) as GameObject;
			smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}
	}

	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}

	void SimulateWin(){
		levelmanager.LoadNextLevel ();
	}
}
