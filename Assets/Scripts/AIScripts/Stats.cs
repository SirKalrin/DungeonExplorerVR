using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public int MaxHealth = 100;
    public int Health;
    public int Energy;
    public int MaxEnergy;

    public int MinDmg;
    public int MaxDmg;
    public float AttackSpeed;
    public int Points;

    public float HealthRegenRate = 0.5f;
    public float EnergyRegenRate = 0.1f;

    private float _nextHealthRegen;
    private float _nextEnergyRegen;

    void Start()
    {
        Health = MaxHealth;
        _nextHealthRegen = Time.time + 1;
        _nextEnergyRegen = Time.time + 1;
    }

    private void Update()
    {
        RegenStats();
    }

    //Adds healt to the players Health stat. Ensures that Health never gets higher than MaxHealth.
    public void GainHealth(int health)
    {
        Health += health;
        if (Health > MaxHealth)
            Health = MaxHealth;
    }

    //Returns a random number that is between _minDmg and _maxDmg
    public int GetCalculatedDamage()
    {
        int damage = Random.Range(MinDmg, MaxDmg);
        Points += damage;
        return damage;
    }

    //Returns wether or not Die() has been called. subtracts the given damage from the Healts variable. If Health is less than, or equal to 0, Die() is called. 
    public bool TakeDamage(int damage)
    {
        Debug.Log("is taking damage: " + damage);
        Health -= damage;
        if (Health <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    //Adds or subtracts the given points from the Points vaiable.
    public void AddPoints(int points)
    {
        Points += points;
    }

    //Changes scene to the "Death" scene, if the gameobject implementing Stats has the tag "Player". 
    //If the gameobject implementing Stats has the tag "EnemyAI", the Die() method in the AIController is called.
    private void Die()
    {
        Debug.Log("method: die, gameobject.tag: " + gameObject.tag);
        if (gameObject.tag == "Player")
        {
            Initiate.Fade("Death", Color.black, 1);
        }
        else if (gameObject.tag == "EnemyAI")
        {
            gameObject.GetComponent<AIController>().Die();
        }
    }

    //Adds the _minDmg and _maxDmg from the given equipment to the variables in Stats.
    public void AddWeaponStats(Equipment eq)
    {
        MinDmg += eq.MinPhysicalDamage;
        MaxDmg += eq.MaxPhysicalDamage;
        AttackSpeed += eq.AttackSpeed;
        
    }

    //Removes the _minDmg and _maxDmg from the given equipment to the variables in Stats.
    public void RemoveStats(Equipment eq)
    {
        MinDmg -= eq.MinPhysicalDamage;
        MaxDmg -= eq.MaxPhysicalDamage;
        AttackSpeed -= eq.AttackSpeed;

    }

    private void RegenStats()
    {
        if (Health < MaxHealth && Time.time >= _nextHealthRegen)
        {
            Health += 1;
            _nextHealthRegen = Time.time + HealthRegenRate;
        }

        if (Energy < MaxEnergy && Time.time >= _nextEnergyRegen)
        {
            Energy += 1;
            _nextEnergyRegen = Time.time + EnergyRegenRate;
        }
    }
}
