using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUp_Controller : MonoBehaviour
{
    public Vector2 location;
    public GameObject Player;
    private SpriteRenderer spriteRenderer;

    float timer = 0f;
    float seconds = 5f;
    public AudioSource pickup;
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
            player.WeaponDamage = 100;
            

        }


        if (timer >= seconds)
        {
            PowerUpText_Controller.PUName = "";
            player.WeaponDamage = 75;
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
                PowerUpText_Controller.PUName = "Melee Damage increased!";
                player.WeaponDamage = 100;
                spriteRenderer.enabled = false;
                active = true;
                player.HasPowerUp = true;

            }
        }
    }



}
