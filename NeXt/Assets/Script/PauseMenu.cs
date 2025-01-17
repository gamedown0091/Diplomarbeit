﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool isPaused = false;
    public GameObject PauseMenuUI;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

   public void Resume ()
    {
        PauseMenuUI.SetActive(false);
        Debug.Log("Weiter");
        Time.timeScale = 1f;
        isPaused = false;
    }

   private void Pause()
    {
        PauseMenuUI.SetActive(true);
        Debug.Log("Pause");
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void MainMenu ()
    {
        Resume();
        SceneManager.LoadScene(0);
    }
}
