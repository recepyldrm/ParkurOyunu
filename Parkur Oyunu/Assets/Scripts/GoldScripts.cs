using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldScripts : MonoBehaviour
{
    public AudioClip goldsound;
    public Text goldtext;
    public static int gold_int = 0;
    public GameObject panel;
    public GameObject player;
    public AudioClip finishsound;
    
    
    private void Update()
    {

        goldtext.text = gold_int.ToString();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            AudioSource.PlayClipAtPoint(goldsound, transform.position);
            gold_int += 1;
            Destroy(this.gameObject);
            


        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player" && gold_int >= 16)
        {
            panel.SetActive(true);
            player.SetActive(false);
            AudioSource.PlayClipAtPoint(finishsound, transform.position);
        }
    }
}
