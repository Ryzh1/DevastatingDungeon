using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp_Controller : MonoBehaviour
{
    // Two variables one for location one for the rigidbody
    public Vector2 location;

    Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    float timer = 0f;
    float seconds = 1f;
    public bool active;
    public AudioSource pickup;
    public int AddHealth = 100;

    Player_Controller player;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        rb = GetComponent<Rigidbody2D>();
        active = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject Player = GameObject.Find("Player");
        player = Player.GetComponent<Player_Controller>();
    }

    void Update()
    {
        if (timer < seconds && active == true)
        {
            timer += Time.deltaTime;
            PowerUpText_Controller.PUName = "Health increased!";


        }


        if (timer >= seconds)
        {
            PowerUpText_Controller.PUName = "";
            player.HasPowerUp = false;
            Destroy(gameObject);
        }

		if (player.currentHealth <= 0)
			Destroy(this.gameObject);
	}

    // If touches player adds 200 health
    void OnTriggerEnter2D(Collider2D other)
    {
        if (player.HasPowerUp == false)
        {
            if (other.tag == "Player")
            {

                if (player.CurrentHealth != 0)
                {
                    pickup.Play();
                    active = true;
                    spriteRenderer.enabled = false;
                    player.HasPowerUp = true;
                    player.ChangeHealth(AddHealth);
                    PowerUpText_Controller.PUName = "Health increased!";
                }
            }
        }
    }
}
