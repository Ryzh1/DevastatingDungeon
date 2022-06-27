using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDemonShooting_Controller : MonoBehaviour
{

    public GameObject Fireball;
    public float FireRate = 0.8f;
    public bool IsShooting;

    private BigDemon_Controller controller;

    void Start()
    {
        controller = GetComponent<BigDemon_Controller>();
    }

    void Update()
    {
        if (IsShooting == false && controller.DemonCurrentHealth < 500)
        {

            StartCoroutine("Delay", FireRate);
            controller.Speed = 1;
        }
    }


    IEnumerator Delay(float delay)
    {


        GameObject player = GameObject.Find("Player");
        IsShooting = true;
        Vector3 pos = player.transform.position;

        GameObject fireball = Instantiate(Fireball, transform.position, transform.rotation);

        fireball.GetComponent<BossProjectile>().location = (pos - transform.position);
        fireball.GetComponent<BossProjectile>().location.Normalize();
        yield return new WaitForSeconds(delay);
        IsShooting = false;

    }
}
