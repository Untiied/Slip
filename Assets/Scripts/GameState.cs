using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    public bool LevelFinished;
    bool showad = true;

    // Use this for initialization
    void Start () {
		
	}
	
	void Update () {

        if (Input.GetKey(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }

        if (LevelFinished == true)
        {
            if (showad && GameHandler.AdMode == 1)
            {
                Advertisments.ShowInterstitial();
                showad = false;
            }
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }

	}
}
