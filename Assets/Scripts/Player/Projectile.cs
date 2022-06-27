using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector2 location;
    public int Force = 100;
	private int weaponDamage = 15;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void Update()
    {
        rb.AddForce(location * Force);

    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }


        if (other.tag == "Enemy")
        {
            Zombie_Controller Zombie = other.GetComponent<Zombie_Controller>();
            Chort_Controller Chort = other.GetComponent<Chort_Controller>();
            Knight_Controller Knight = other.GetComponent<Knight_Controller>();
            Wizard_Controller Wizard = other.GetComponent<Wizard_Controller>();
            BigDemon_Controller Demon = other.GetComponent<BigDemon_Controller>();

            ZombieSpawner_Controller Zspawner = other.GetComponent<ZombieSpawner_Controller>();
            ChortSpawner_Controller Cspawner = other.GetComponent<ChortSpawner_Controller>();
            KnightSpawner_Controller Kspawner = other.GetComponent<KnightSpawner_Controller>();
            WizardSpawner_Controller Wspawner = other.GetComponent<WizardSpawner_Controller>();

            if (Zombie != null && Zombie.ZombieCurrentHealth > 0)
            {
                Zombie.ChangeHealth(-weaponDamage);
                Destroy(gameObject);

            }

            if (Chort != null && Chort.ChortCurrentHealth > 0)
            {
                Chort.ChangeHealth(-weaponDamage);
                Destroy(gameObject);

            }

            if (Knight != null && Knight.KnightCurrentHealth > 0)
            {
                Knight.ChangeHealth(-weaponDamage);
                Destroy(gameObject);

            }

            if (Wizard != null && Wizard.WizardCurrentHealth > 0)
            {
                Wizard.ChangeHealth(-weaponDamage);
                Destroy(gameObject);

            }

            if (Demon != null && Demon.DemonCurrentHealth > 0)
            {
                Demon.ChangeHealth(-weaponDamage);
                Destroy(gameObject);

            }

            if (Zspawner != null && Zspawner.ZombieSpawnerCurrentHealth > 0)
            {
                Zspawner.ChangeHealth(-weaponDamage);
                Destroy(gameObject);

            }

            if (Cspawner != null && Cspawner.ChortSpawnerCurrentHealth > 0)
            {
                Cspawner.ChangeHealth(-weaponDamage);
                Destroy(gameObject);

            }

            if (Kspawner != null && Kspawner.KnightSpawnerCurrentHealth > 0)
            {
                Kspawner.ChangeHealth(-weaponDamage);
                Destroy(gameObject);

            }

            if (Wspawner != null && Wspawner.WizardSpawnerCurrentHealth > 0)
            {
                Wspawner.ChangeHealth(-weaponDamage);
                Destroy(gameObject);

            }
        }
    }
}
