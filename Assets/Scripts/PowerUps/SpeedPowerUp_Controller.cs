using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp_Controller : MonoBehaviour
{
    // Two variables one for location one for the rigidbody
    public Vector2 location;
    private SpriteRenderer spriteRenderer;

    public AudioSource pickup;
    float timer = 0f;
    float seconds = 5f;
    public GameObject Player;
    Player_Controller player;
    Rigidbody2D rb;
    public bool active;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = Player.GetComponent<Player_Controller>();

        DontDestroyOnLoad(this.gameObject);
        
        active = false;

    }
    void Update()
    {
        
        if (timer < seconds && active == true)
        {
            timer += Time.deltaTime;
            player.movespeed = 8f;
            Debug.Log(timer);

        }


        if (timer >= seconds)
        {
            PowerUpText_Controller.PUName = "";
            player.movespeed = 7f;
            player.HasPowerUp = false;
            Destroy(gameObject);
        }

		if (player.currentHealth <= 0)
			Destroy(this.gameObject);

	}

    // If touches player increases the movespeed
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (player.HasPowerUp == false)
        {
            if (other.tag == "Player")
            {
                pickup.Play();
                PowerUpText_Controller.PUName = "Speed increased!";
                player.movespeed = 8f;
                spriteRenderer.enabled = false;
                active = true;
                player.HasPowerUp = true;

            }
        }

        
    }



}
