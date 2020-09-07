using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitObject : MonoBehaviour
{
    public int currentHealth = 100, maxHealth = 100, strength, dexterity, intelligence, attributePoints = 40;
    public GameObject targetedUnit;
    public GameObject playerRef;
    public SpellManager SpellContainerScript;
    public string chosenSpell = "Default";
    public bool alive = true;

    public AudioClip spawn, hurt, die;

    [SerializeField]
    private GameObject healthBarPrefab = default;
    private GameObject healthBar, healthBar_HealthRemaining, healthBar_DamageTaken;

    private void Start()
    {
        playerRef = GameObject.Find("Player");
        SpellContainerScript = GetComponent<SpellManager>();

        healthBar = Instantiate(healthBarPrefab, new Vector3(transform.position.x - 2.56f, transform.position.y + 4f, transform.position.z), transform.rotation);
        healthBar.transform.parent = transform;

        healthBar_HealthRemaining = healthBar.transform.GetChild(0).gameObject;
        healthBar_DamageTaken = healthBar.transform.GetChild(1).gameObject;

        UpdateHealthBar();
    }
    private void Update()
    {
        healthBar_DamageTaken.transform.localScale = new Vector3(Mathf.Lerp(healthBar_DamageTaken.transform.localScale.x, healthBar.transform.localScale.x, Time.time * 0.01f), healthBar_DamageTaken.transform.localScale.y, healthBar_DamageTaken.transform.localScale.z);
    }

    public void CheckHealthStatus()
    {
        if (alive)
            if (currentHealth <= 0)
            {
                GetComponent<AudioSource>().clip = die;
                GetComponent<AudioSource>().Play();

                alive = false;
                Manager.current.RemoveDeadUnit(gameObject);
                Invoke("Die", GetComponent<AudioSource>().clip.length);
            }
            else
            {
                GetComponent<AudioSource>().clip = hurt;
                GetComponent<AudioSource>().Play();
            }

        Manager.current.NextTurn();
    }

    public void UpdateHealthBar()
    {
        float x = 4f * currentHealth / maxHealth;
        healthBar_HealthRemaining.transform.localScale = new Vector3(x, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    public void ApplyDamage(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
        GetComponent<Animator>().SetTrigger("Damage");

        UpdateHealthBar();
        CheckHealthStatus();
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        UpdateHealthBar();
        CheckHealthStatus();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    //Will be split in Player.cs and Enemy.cs in future
    public void TakeTurn()
    {
        if (gameObject.name == "Player")
            Debug.Log("Player UI is being unlocked now. Waiting for spell to cast.");
        else
        {
            Invoke("AITesting", 1f);
        }
    }

    public void AITesting()
    {
        SpellContainerScript.CastSpell(playerRef, strength, dexterity, intelligence, chosenSpell);
    }

    //Will be split in Player.cs and Enemy.cs in future
    void OnMouseDown()
    {
        Debug.Log("OnMouseDown: " + gameObject.name);

        if (gameObject.name != "Player" && Manager.current.currentObjectsTurn == playerRef)
        {
            if (gameObject.name == "Player")
            {
                //We are casting on our own player here
                SpellContainerScript.CastSpell(gameObject, strength, dexterity, intelligence, chosenSpell);
                Debug.Log("Player UI is being unlocked now. Waiting for spell to cast.");
            }
            else
            {
                //We are casting on an enemy here
                playerRef.GetComponent<UnitObject>().SpellContainerScript.CastSpell(gameObject, strength, dexterity, intelligence, chosenSpell);
                Debug.Log("Player casts a spell on an enemy.");
            }
        }
    }
}