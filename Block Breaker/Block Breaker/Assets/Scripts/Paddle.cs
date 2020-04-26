using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Configuration paramaters


    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX=1f;
    [SerializeField] float maxX=15f;


    // cached reference
    GameStatus theGameSession;
    ball theBall;



    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<ball>();
    }

    // Update is called once per frame
    void Update()
    {
        //Game will show the mouse position on x axis during the scene.(Old code, not I created a method for it.
        //float MousePosInUnit=Input.mousePosition.x / Screen.width * screenWidthInUnits;

        // store x and y position only. and transforms the paddle's to the specified position.
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;

    }


    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())

        {

            return theBall.transform.position.x;
        }

        else
        {
            // Game will show the mouse position on x axis during the scene.
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }


    }
}
