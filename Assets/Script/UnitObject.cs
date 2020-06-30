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
    private GameObject healthBar;

    void Start()
    {
        SpellContainerScript = GetComponent<SpellManager>();

        playerRef = GameObject.Find("Player");
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
    }

    public void UpdateHealthBar()
    {
        float x = 4f * currentHealth / maxHealth;
        //healthBar.transform.localScale = new Vector3(x, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
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
        Manager.current.NextTurn();
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
            }

            Manager.current.NextTurn();
        }
    }
}