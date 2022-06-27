using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPowerUp : MonoBehaviour
{
    public Vector2 location;
    
    private SpriteRenderer spriteRenderer;

    float timer = 0f;
    float seconds = 7f;

    Player_Controller player;
    Rigidbody2D rb;
    public AudioSource pickup;
    public bool active;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        GameObject Player = GameObject.Find("Player");
        player = Player.GetComponent<Player_Controller>();

        DontDestroyOnLoad(this.gameObject);

        active = false;

    }
    void Update()
    {

        if (timer < seconds && active == true)
        {
            timer += Time.deltaTime;
            player.WeaponDamage = 200;


        }


        if (timer >= seconds)
        {
            PowerUpText_Controller.PUName = "";
            player.WeaponDamage = 75;
            player.HasPowerUp = false;
            Destroy(gameObject);
        }



    }

    // If touches player increases the melee.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (player.HasPowerUp == false)
        {
            if (other.tag == "Player")
            {
                pickup.Play();
                PowerUpText_Controller.PUName = "Super Melee Damage!";
                player.WeaponDamage = 200;
                transform.Rotate(0, 0, 180);
                active = true;
                player.HasPowerUp = true;
                rb.AddForce(transform.up * 10, ForceMode2D.Impulse);

            }
        }
    }



}
