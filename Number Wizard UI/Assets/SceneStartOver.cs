using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneStartOver : MonoBehaviour
{
    public void LoadFirstScene()
    {


        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);


    }

    public void Quit()
    {
      
            Application.Quit();
       
    }
}
