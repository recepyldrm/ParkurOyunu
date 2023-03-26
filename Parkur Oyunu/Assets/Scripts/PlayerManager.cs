using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class PlayerManager : MonoBehaviour
{

   
    public AudioClip damageSound, deadSound;
    public float health=100f;
    public bool dead=false;
    public Image healthImage;
    public static float healthvalue= 100f;
    public GameObject player;
    private AudioSource aSource;
    public float horizontal;
    public int speed;
    public int jumpSpeed = 250;
    public int doublejump;
    public bool touch = true;
    public bool faceRight = true;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        doublejump = 2;
        aSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed,/** 100 * Time.deltaTime,*/ rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && (touch == true || doublejump > 0))
        {
            rb.AddForce(Vector2.up * jumpSpeed);

            touch = false;

            doublejump -= 1;
        }
        if (horizontal > 0 && faceRight == false)
        {
            turn();
        }
        if (horizontal < 0 && faceRight == true)
        {
            turn();
        }
    }

    public void getDamage(float damage)
    {
        if (health-damage>=0)
        {
            health-=damage;
            healthvalue -= damage;
            aSource.PlayOneShot(damageSound, 0.5f);
            float x = healthvalue / 100f;
            healthImage.fillAmount = x;
            healthImage.color = Color.Lerp(Color.red, Color.green,x);
        }
        else
        {
            health=0;
            
        }
        playerdead();

    }
   
    public void playerdead()
    {
        if (health==0)
        {
            dead = true;
            player.SetActive(false);
            AudioSource.PlayClipAtPoint(deadSound, transform.position);



        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            touch = true;
            doublejump = 2;
        }

    }
    void turn()
    {
        faceRight = !faceRight;
        Vector2 yeniscale = transform.localScale;
        yeniscale.x *= -1;
        transform.localScale = yeniscale;
    }

}
