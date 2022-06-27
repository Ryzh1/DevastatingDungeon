using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chort_Controller : MonoBehaviour
{
    public float speed = 6f;
    public int ChortMaxHealth = 200;
    public bool IsInvincible;
    public bool CanMove = true;
    public AudioClip DeathSound;




    public int ChortCurrentHealth;
    private SpriteRenderer spriterenderer;
    private Rigidbody2D rb;
    private Vector2 movement;


    //Assigns the variable rb to the rigidbody component.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        ChortCurrentHealth = ChortMaxHealth;

    }


    void Update()
    {
        //Moves to the player.
        GameObject player = GameObject.Find("Player");
        Transform transformPlayer = player.GetComponentInParent<Transform>();
        //Moves to the player.
        Vector2 direction = transformPlayer.position - transform.position;
        direction.Normalize();
        movement = direction;


        //Flips sprite
        if (direction.x > 0)
            spriterenderer.flipX = false;
        else
            spriterenderer.flipX = true;


        //If 0 health play sound add score and destroy.
        if (ChortCurrentHealth <= 0)
        {
            AudioSource.PlayClipAtPoint(DeathSound, transform.position);
            StopAllCoroutines();
            player.GetComponent<Player_Controller>().IsInvincible = false;
            ScoreScript.ScoreValue += 5;
            Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {
        if (CanMove)
            moveCharacter(movement);
    }



    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    //When touching the player do 50 damage

    IEnumerator InvincibilityTime(Collision2D other, float seconds)
    {
        Player_Controller player = other.gameObject.GetComponent<Player_Controller>();
        if (player != null && !player.IsInvincible)
        {
            player.ChangeHealth(-40);
            player.IsInvincible = true;
            yield return new WaitForSeconds(seconds);
            player.IsInvincible = false;
        }

    }

    

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            CanMove = false;
        }

        StartCoroutine(InvincibilityTime(other, 1));

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

        ChortCurrentHealth = Mathf.Clamp(ChortCurrentHealth + amount, 0, ChortMaxHealth);

        Debug.Log(ChortCurrentHealth + "/" + ChortMaxHealth);

    }
}
