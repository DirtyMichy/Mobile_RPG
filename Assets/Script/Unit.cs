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

    //Only used by Player, will be moved in Player.cs in future
    void OnMouseDown()
    {
        Debug.Log("OnMouseDown: " + gameObject.name);

        if(gameObject.name == "Player")
            SpellContainerScript.CastSpell(gameObject, strength, dexterity, intelligence, chosenSpell);
        else
            playerRef.GetComponent<UnitObject>().SpellContainerScript.CastSpell(gameObject, strength, dexterity, intelligence, chosenSpell);
    }
}