using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Controller : MonoBehaviour
{

    public float Speed = 4.0f;
    public Transform player;
    public int ZombieMaxHealth = 100;
    public bool IsInvincible;
    public bool CanMove = true;
    public AudioClip DeathSound;

    public int ZombieCurrentHealth;
    private SpriteRenderer spriterenderer;
    private Rigidbody2D rb;
    private Vector2 movement;



    //Assigns the variable rb to the rigidbody component.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();

        ZombieCurrentHealth = ZombieMaxHealth;

    }


    void Update()
    {
        //Moves to the player.
        GameObject player = GameObject.Find("Player");
        Transform transformPlayer = player.GetComponentInParent<Transform>();
        
        Vector2 direction = transformPlayer.position - transform.position;
        direction.Normalize();
        movement = direction;

        // Flips the sprite depending on the directon.
        if (direction.x > 0)
            spriterenderer.flipX = false;
        else
            spriterenderer.flipX = true;

        // Kills the zombie if equal to or less than 0 health. Plays sound,adds score.
        if (ZombieCurrentHealth <= 0)
        {

            AudioSource.PlayClipAtPoint(DeathSound, transform.position);
            StopAllCoroutines();
            player.GetComponent<Player_Controller>().IsInvincible = false;
            ScoreScript.ScoreValue += 1;
            Destroy(gameObject);    
            
        }

    }



    private void FixedUpdate()
    {
        if(CanMove)
            moveCharacter(movement);
    }


    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * Speed * Time.deltaTime));
    }


    // Sets the player to invincble for 1 second so the player doesn't die immediately.
    // Damages the player for 50 damage.
    IEnumerator InvincibilityTime(Collision2D other,float seconds)
    {
        Player_Controller player = other.gameObject.GetComponent<Player_Controller>();
        if (player != null && !player.IsInvincible)
        {
            player.ChangeHealth(-30);
            player.IsInvincible = true;
            yield return new WaitForSeconds(seconds);
            player.IsInvincible = false;
        }

    }

    //When touching start the timer

    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag =="Enemy")
        {
            CanMove = false;
        }
        
        StartCoroutine(InvincibilityTime(other,1));

    }


    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            CanMove = true;
        }
    }
    

    //Health
    public void ChangeHealth(int amount)
    {

        ZombieCurrentHealth = Mathf.Clamp(ZombieCurrentHealth + amount, 0, ZombieMaxHealth);

        Debug.Log(ZombieCurrentHealth + "/" + ZombieMaxHealth);

    }


}