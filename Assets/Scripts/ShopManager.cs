using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ShopButton : MonoBehaviour
{
    public string sceneName;

    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        //Quits actual build version of the game
        Application.Quit();

        //Quits the unity editor 
        UnityEditor.EditorApplication.isPlaying = false;
    }

 
}
