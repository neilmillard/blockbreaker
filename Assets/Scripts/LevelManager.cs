using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel (string name)
	{
		Debug.Log("Level load requested for: "+name);
		SceneManager.LoadScene (name);
	}

	public void Quit ()
	{
		Debug.Log("Quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel(){
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene (scene.buildIndex + 1);
	}

	public void BrickDestroyed() {
		// check if last brick is destroyed
		if (BrickController.breakableCount<=0){
			LoadNextLevel();
		}
	}
}
