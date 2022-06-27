using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_Controller : MonoBehaviour
{

    public float Speed = 2.0f;
    public Transform player;
    public int WizardMaxHealth = 500;
    public bool IsInvincible;
    public bool CanMove = true;
    public bool IsAttacking = false;
	public int WizardCurrentHealth;
    public AudioClip DeathSound;

    private SpriteRenderer spriterenderer;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float distance;
    private Wizard_Shooting shooting;



    //Assigns variables to components.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        WizardCurrentHealth = WizardMaxHealth;
        shooting = GetComponent<Wizard_Shooting>();

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

        // Flips the sprite depending on the directon.
        if (direction.x > 0)
            spriterenderer.flipX = false;
        else
            spriterenderer.flipX = true;

        // Kills the zombie if equal to or less than 0 health.
        if (WizardCurrentHealth <= 0)
        {
            AudioSource.PlayClipAtPoint(DeathSound, transform.position);
            StopAllCoroutines();
            player.GetComponent<Player_Controller>().IsInvincible = false;
            ScoreScript.ScoreValue += 10;
            Destroy(gameObject);

        }
		// Gets the distance between the player and the wizard
        distance = Vector3.Distance(transformPlayer.position, transform.position);


    }


    private void FixedUpdate()
    {
        if (CanMove)
            moveCharacter(movement);
    }


    void moveCharacter(Vector2 direction)
    {
        GameObject player = GameObject.Find("Player");
        Transform transformPlayer = player.GetComponentInParent<Transform>();

		// If the distance to player us less than 5 stop moving.
		// Else move towards player.
        if(distance <= 5)
        {
            
        }

        else
        {
            rb.MovePosition((Vector2)transform.position + (direction * Speed * Time.deltaTime));
            shooting.InCombat = false;
        }

        if (distance < 1)
        {
            shooting.InCombat = true;

        }
        else
        {
            shooting.InCombat = false;
        }



    }


    // Sets the player to invincble for 1 second so the player doesn't die immediately.
    // Damages the player for 50 damage.
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



    //When touching start the timer

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            CanMove = false;
        }
        if (other.gameObject.tag == "Enemy")
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
            shooting.InCombat = false;
        }
    }


    //Health
    public void ChangeHealth(int amount)
    {

        WizardCurrentHealth = Mathf.Clamp(WizardCurrentHealth + amount, 0, WizardMaxHealth);

        Debug.Log(WizardCurrentHealth + "/" + WizardMaxHealth);

    }

}
