using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{


    //config parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject explosion_vfx;
    [SerializeField] Sprite[] hitSprites;



    //state variables
    [SerializeField] int timesHit; //   TODO only serialized for debug purposes



    level bolum;


    private void Start()
    {
        CountBreakableBlocks();
    }
    private void CountBreakableBlocks()
    {


        bolum = FindObjectOfType<level>();

        if (tag == "Breakable")
        {
            bolum.countBlocks();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();


        }


    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;

        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }

        else
        {

            ShowNextHitSprite();
        }

    }

    private void ShowNextHitSprite()
    {
        //timesHit cause this way the array will follow from 0.
        // 
        int spriteindex = timesHit - 1;

        if (hitSprites[spriteindex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteindex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        BlockDestSound();
        Destroy(gameObject);
        bolum.BlockDestroyed();
        

    }

    private void BlockDestSound()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        triggerVFX();

    }


    private void triggerVFX()
    {
        GameObject sparkles = Instantiate(explosion_vfx,transform.position, transform.rotation);
        Destroy(sparkles, 1f);

    }



}
