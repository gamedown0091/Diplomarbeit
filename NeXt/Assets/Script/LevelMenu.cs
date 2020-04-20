using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour {

    public void Level00()
    {
        SceneManager.LoadScene(2);
    }

    public void Level01()
    {
        SceneManager.LoadScene(3);
    }

    public void Level02()
    {
        SceneManager.LoadScene(4);
    }

    public void Level03()
    {
        SceneManager.LoadScene(5);
    }
    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }

}
