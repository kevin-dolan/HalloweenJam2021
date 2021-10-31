using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    private Canvas canvas;
    

    void Start()
    {
        canvas = FindObjectOfType<Canvas>(); //get reference to canvas    
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ChangeLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

}
