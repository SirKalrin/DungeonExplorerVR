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

    [SerializeField]
    private int _minDmg;
    [SerializeField]
    private int _maxDmg;
    private int _points;

    public float HealthRegenRate = 0.5f;
    public float EnergyRegenRate = 0.1f;

    private float NextHealthRegen;
    private float NextEnergyRegen;

    void Start()
    {
        Health = MaxHealth;
        NextHealthRegen = Time.time + 1;
        NextEnergyRegen = Time.time + 1;
    }

    private void Update()
    {
        RegenStats();
    }

    public void GainHealth(int health)
    {
        Health += health;
    }
    public int GetCalculatedDamage()
    {
        int damage = Random.Range(_minDmg, _maxDmg);
        _points += damage;
        return damage;
    }

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

    public void AddPoints(int points)
    {
        _points += points;
    }

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
    public void AddWeaponStats(Equipment eq)
    {
        _minDmg += eq.MinPhysicalDamage;
        _maxDmg += eq.MaxPhysicalDamage;
    }

    public void RemoveStats(Equipment eq)
    {
        _minDmg -= eq.MinPhysicalDamage;
        _maxDmg -= eq.MaxPhysicalDamage;
    }

    private void RegenStats()
    {
        if (Health < MaxHealth && Time.time >= NextHealthRegen)
        {
            Health += 1;
            NextHealthRegen = Time.time + HealthRegenRate;
        }

        if (Energy < MaxEnergy && Time.time >= NextEnergyRegen)
        {
            Energy += 1;
            NextEnergyRegen = Time.time + EnergyRegenRate;
        }
    }
}
