using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    // Animation variable, rigidbody variable, movement speed, starting health and current health.

    Rigidbody2D rb;
    public float movespeed = 6f;
    private Animator animation;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider;
    private BoxCollider2D boxCollider;

    public AudioSource Lose;
    public int MaxHealth = 1000;
    public int currentHealth;
    public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;   //Gets the current health sets healthbar to the value.
            HealthBar.value = value;
        }
    }

    public bool HasPowerUp = false;
    public int Score = 0;
    public int WeaponDamage = 75;
    public bool IsInvincible;
    public bool IsAttacking;
    public bool InMelee;
    public bool dead = false;


    public Slider HealthBar; //HealthBar

    public bool Credits = false;

    //Assigns the variable rb to the rigidbody component.
    //Assigns current health to the value of health.
    //Assigns animation to the Animator compontent.
    //Sets the parameter Speed in the animator to 0.
    //Assigns the sprite renderer component to the variable.
    //Assigns the circlecollider2D to the variable.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CurrentHealth = MaxHealth;

        animation = GetComponent<Animator>();
        animation.SetFloat("Speed", 0);

        spriteRenderer = GetComponent<SpriteRenderer>();

        circleCollider = GetComponent<CircleCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        HealthBar.value = MaxHealth;

        DontDestroyOnLoad(this.gameObject);
        dead = false;
        InMelee = false;
        Credits = false;
    }


    // Movement
    void Update()
    {

        if (dead != true)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector2 position = rb.position;

            Vector2 moveAmount = new Vector2(horizontal, vertical).normalized;

            position.x = position.x + movespeed * moveAmount.x * Time.deltaTime;
            position.y = position.y + movespeed * moveAmount.y * Time.deltaTime;

            rb.MovePosition(position);



            //Animation

            if (horizontal != 0 || vertical != 0)
                animation.SetFloat("Speed", 1);
            else
                animation.SetFloat("Speed", 0);


            // If health is less than or equal to 0 play the death animation and destroy the gameobject.

            if (CurrentHealth <= 0 && dead != true)
            {
                animation.SetBool("Hasdied", true);
                dead = true;
                Destroy(GameObject.FindWithTag("PowerUp"));
                Destroy(GameObject.FindWithTag("EndGame"));
                StartCoroutine(Died());
                

            }



            //Rotate sprite depending on key pressed

            if (horizontal > 0)
            {
                spriteRenderer.flipX = false;
                circleCollider.offset = new Vector2(0.31f, -0.15f);
                boxCollider.offset = new Vector2(-0.15f, -0.22f);
            }

            else if (horizontal < 0)
            {
                spriteRenderer.flipX = true;
                circleCollider.offset = new Vector2(-0.31f, -0.15f);
                boxCollider.offset = new Vector2(0.15f, -0.22f);
            }

            //if animation with name "Attack" finished
            if ((animation.GetCurrentAnimatorStateInfo(0).IsName("Attack 0") && animation.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) || !animation.GetCurrentAnimatorStateInfo(0).IsName("Attack 0"))
            {
                IsAttacking = false;
            }

        }

        // Close if escape pressed.

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }



    }
    // Ends the game changes scene and waits then loads MM and credits
    IEnumerator Died()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("YouLose");
        Lose.Play();
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MainMenu");
      
		Credits = true;
        yield return new WaitForSeconds(0.01f);
        Destroy(this.gameObject);
    }



	// Health function
	public void ChangeHealth(int amount)
    {

        CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, MaxHealth);

        
    }

    
    

    // When touching enemy start the timer and set is melee to true.
    void OnTriggerStay2D(Collider2D collider)
    {

        StartCoroutine(InvincibilityTime(collider, 0.45f));


    }



    // When leaves collider stop attacking.
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            IsAttacking = false;
            InMelee = false;
        }
        

    }


    //All melee damage

    IEnumerator InvincibilityTime(Collider2D other, float seconds)
    {

        if (other.tag == "Enemy" && !IsAttacking)
        {


            Zombie_Controller Zombie = other.gameObject.GetComponent<Zombie_Controller>();
            Chort_Controller Chort = other.gameObject.GetComponent<Chort_Controller>();
            Knight_Controller Knight = other.GetComponent<Knight_Controller>();
            Wizard_Controller Wizard = other.GetComponent<Wizard_Controller>();
            BigDemon_Controller Demon = other.GetComponent<BigDemon_Controller>();

            ZombieSpawner_Controller Zspawner = other.GetComponent<ZombieSpawner_Controller>();
            ChortSpawner_Controller Cspawner = other.GetComponent<ChortSpawner_Controller>();
            KnightSpawner_Controller Kspawner = other.GetComponent<KnightSpawner_Controller>();
            WizardSpawner_Controller Wspawner = other.GetComponent<WizardSpawner_Controller>();
            InMelee = true;

            if (Zombie != null && !Zombie.IsInvincible && Zombie.ZombieCurrentHealth > 0)
            {
                Zombie.IsInvincible = true;
                IsAttacking = true;
                animation.SetTrigger("Attack 0");

                yield return new WaitForSeconds(seconds);
                Zombie.ChangeHealth(-WeaponDamage);

                Zombie.IsInvincible = false;

            }

            if (Chort != null && !Chort.IsInvincible && Chort.ChortCurrentHealth > 0)
            {
                Chort.IsInvincible = true;
                IsAttacking = true;
                animation.SetTrigger("Attack 0");

                yield return new WaitForSeconds(seconds);
                Chort.ChangeHealth(-WeaponDamage);

                Chort.IsInvincible = false;

            }

            if (Knight != null && !Knight.IsInvincible && Knight.KnightCurrentHealth > 0)
            {
                Knight.IsInvincible = true;
                IsAttacking = true;
                animation.SetTrigger("Attack 0");

                yield return new WaitForSeconds(seconds);
                Knight.ChangeHealth(-WeaponDamage);

                Knight.IsInvincible = false;

            }

            if (Wizard != null && !Wizard.IsInvincible && Wizard.WizardCurrentHealth > 0)
            {
                Wizard.IsInvincible = true;
                IsAttacking = true;
                animation.SetTrigger("Attack 0");

                yield return new WaitForSeconds(seconds);
                Wizard.ChangeHealth(-WeaponDamage);

                Wizard.IsInvincible = false;

            }

            if (Demon != null && !Demon.IsInvincible && Demon.DemonCurrentHealth > 0)
            {
                Demon.IsInvincible = true;
                IsAttacking = true;
                animation.SetTrigger("Attack 0");

                yield return new WaitForSeconds(seconds);
                Demon.ChangeHealth(-WeaponDamage);

                Demon.IsInvincible = false;

            }

            if (Zspawner != null && !Zspawner.IsInvincible && Zspawner.ZombieSpawnerCurrentHealth > 0)
            {
                Zspawner.IsInvincible = true;
                IsAttacking = true;
                animation.SetTrigger("Attack 0");

                yield return new WaitForSeconds(seconds);
                Zspawner.ChangeHealth(-WeaponDamage);

                Zspawner.IsInvincible = false;

            }

            if (Cspawner != null && !Cspawner.IsInvincible && Cspawner.ChortSpawnerCurrentHealth > 0)
            {
                Cspawner.IsInvincible = true;
                IsAttacking = true;
                animation.SetTrigger("Attack 0");

                yield return new WaitForSeconds(seconds);
                Cspawner.ChangeHealth(-WeaponDamage);

                Cspawner.IsInvincible = false;

            }

            if (Kspawner != null && !Kspawner.IsInvincible && Kspawner.KnightSpawnerCurrentHealth > 0)
            {
                Kspawner.IsInvincible = true;
                IsAttacking = true;
                animation.SetTrigger("Attack 0");

                yield return new WaitForSeconds(seconds);
                Kspawner.ChangeHealth(-WeaponDamage);

                Kspawner.IsInvincible = false;

            }

            if (Wspawner != null && !Wspawner.IsInvincible && Wspawner.WizardSpawnerCurrentHealth > 0)
            {
                Wspawner.IsInvincible = true;
                IsAttacking = true;
                animation.SetTrigger("Attack 0");

                yield return new WaitForSeconds(seconds);
                Wspawner.ChangeHealth(-WeaponDamage);

                Wspawner.IsInvincible = false;

            }

        }

    }

}

