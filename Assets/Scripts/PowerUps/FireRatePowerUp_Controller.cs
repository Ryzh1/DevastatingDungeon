using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePowerUp_Controller : MonoBehaviour
{
    public Vector2 location;
    private SpriteRenderer spriteRenderer;

    float timer = 0f;
    float seconds = 5f;
    public GameObject Player;
    Player_Shooting playershooting;
    Rigidbody2D rb;
    public bool active;
    public AudioSource pickup;
    Player_Controller player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playershooting = Player.GetComponent<Player_Shooting>();
        player = Player.GetComponent<Player_Controller>();

        DontDestroyOnLoad(this.gameObject);

        active = false;

    }
    void Update()
    {

        if (timer < seconds && active == true)
        {
            timer += Time.deltaTime;
            playershooting.FireRate = 0.1f;


        }


        if (timer >= seconds)
        {
            PowerUpText_Controller.PUName = "";
            playershooting.FireRate = 0.5f;
            player.HasPowerUp = false;
            Destroy(gameObject);
        }

		if (player.currentHealth <= 0)
			Destroy(this.gameObject);


    }

    // If touches player increases the firerate.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (player.HasPowerUp == false)
        {
            if (other.tag == "Player")
            {
                pickup.Play();
                PowerUpText_Controller.PUName = "Firerate increased!";
                playershooting.FireRate = 0.1f;
                spriteRenderer.enabled = false;
                active = true;
                player.HasPowerUp = true;

            }
        }
    }



}
