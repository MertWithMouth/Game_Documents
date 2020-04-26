using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{

    [SerializeField] Paddle paddle1;
    [SerializeField] float velx;
    [SerializeField] float vely;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomfactor = 0.2f;




    bool hasStarted = false;
    bool click = false;
    //state
    Vector2 paddleToBallVector;

    //cached component reference
    AudioSource myAudioSource;
    Rigidbody2D myrigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;

        myAudioSource = GetComponent<AudioSource>();
        myrigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (hasStarted == false)
        {
            LockBalltoPaddle();
        }
        if (click == false)
        {
            LaunchingBall();
        }

    }

    public void LockBalltoPaddle()
    {

        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;


    }
    public void LaunchingBall()
    {

    if(Input.GetMouseButtonDown(0))
        {

            GetComponent<Rigidbody2D>().velocity = new Vector2(velx,vely);

            hasStarted = true;
            click = true;
        }



    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2 (Random.Range(0f, randomfactor), Random.Range(0f, randomfactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myrigidbody2D.velocity += velocityTweak;
        }
    }
    
}
