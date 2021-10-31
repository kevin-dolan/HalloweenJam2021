using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ChangeLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
