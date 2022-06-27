using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{

    public GameObject Bullet;
    public float FireRate = 0.3f;
    public bool IsShooting;
    Player_Controller Player;


    void Update()
    {
        Player = GetComponent<Player_Controller>();
        if (Input.GetMouseButton(0)&& IsShooting == false && Player.InMelee == false && Player.dead != true) // if mouse button pressed and player isnt shooting or in melee start coroutine
        {

            StartCoroutine("Delay", FireRate);
        }
    }


    IEnumerator Delay(float delay)
    {

        // If mouse button is pressed instantiate the bullet where the player is.
        // Gets the mouse position and move towards the mouse when it is clicked.

            IsShooting = true;
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            
            GameObject bullet = Instantiate(Bullet, transform.position,transform.rotation);

            bullet.GetComponent<Projectile>().location = (pos - transform.position);
            bullet.GetComponent<Projectile>().location.Normalize();
            yield return new WaitForSeconds(delay);
            IsShooting = false;
        
    }
}
