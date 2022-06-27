using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardProjectile : MonoBehaviour
{
    public Vector2 location;
    public int Force = 50;

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


        if (other.tag == "Player")
        {
            Player_Controller Player = other.GetComponent<Player_Controller>();

            if (Player != null && Player.CurrentHealth > 0)
            {
                Player.ChangeHealth(-40);
                Destroy(gameObject);

            }
        }
    }
}
