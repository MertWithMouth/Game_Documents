using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour
{

    [SerializeField] int BreakableBlocks;

    //cached reference
    SceneLoader sceneloader;


    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
     
    }

    public void countBlocks()
    {

        BreakableBlocks++;


    }

    public void BlockDestroyed()
    {


        BreakableBlocks--;

        if(BreakableBlocks==0)
        {
            sceneloader.LoadNextScene();
            
        }
    }

}
