using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardSpawner_Controller : MonoBehaviour
{

    public int WizardSpawnerMaxHealth = 900;
    public bool IsInvincible;


    public int WizardSpawnerCurrentHealth;
    private SpriteRenderer spriterenderer;
    private Rigidbody2D rb;

    public float SpawnRate = 5f;
    public GameObject Wizard;

    public bool IsSpawning;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();

        WizardSpawnerCurrentHealth = WizardSpawnerMaxHealth;



    }

    // Update is called once per frame
    void Update()
    {

        if (WizardSpawnerCurrentHealth <= 0)
        {
            ScoreScript.ScoreValue += 5;
            Destroy(gameObject);

        }


        if (IsSpawning == false)
        {
            StartCoroutine("Delay", SpawnRate);
        }

    }

    //Health
    public void ChangeHealth(int amount)
    {

        WizardSpawnerCurrentHealth = Mathf.Clamp(WizardSpawnerCurrentHealth + amount, 0, WizardSpawnerMaxHealth);



    }


    // SPawner
    IEnumerator Delay(float delay)
    {

        // Spawn wizard every few seconds.
        IsSpawning = true;

        Instantiate(Wizard, transform.position, transform.rotation);
        yield return new WaitForSeconds(delay);

        IsSpawning = false;



    }
}
