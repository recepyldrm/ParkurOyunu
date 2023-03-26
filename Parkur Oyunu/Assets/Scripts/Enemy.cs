using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float damage = 10f;
    public bool playercollider=false;
    public float speed;
    public int faceRight = -1;
    SpriteRenderer sr;


    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.Translate(new Vector3(deger * hiz * Time.deltaTime, 0, 0));
        gameObject.transform.Translate(faceRight * speed * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player"&&!playercollider)
        {
            playercollider = true;  
            collision.GetComponent<PlayerManager>().getDamage(damage);

        }
        if (collision.gameObject.tag == "contact")
        {
            if (faceRight == -1)
            {
                sr.flipX = true;
                faceRight = 1;
            }
            else if (faceRight == 1)
            {
                sr.flipX = false;
                faceRight = -1;
            }
        }


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            playercollider=false;
        }
        
        
    }
        
   
    
        
    
}
