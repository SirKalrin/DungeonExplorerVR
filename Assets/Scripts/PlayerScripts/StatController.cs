using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatController : Stats {

    
    public float StrengthMultiplier = 2f;
    public float IntellectMultiplier = 0.5f;
    public float DexterityMultiplier = 1f;
    public float VitalityMultiplier = 2f;

    private int StatMultiplier = 10;

    public float HealthRegenRate = 0.5f;
    public float EnergyRegenRate = 0.1f;

    private float NextHealthRegen;
    private float NextEnergyRegen;

    // Use this for initialization
    void Start () {
        NextHealthRegen = Time.time + 1;
        NextEnergyRegen = Time.time + 1;
    }
	
	// Update is called once per frame
	void Update () {
        UpdateStats();
        
        RegenStats();
	}

    /**
     * Updates the players stats after level and its class multipliers 
     **/
    public void UpdateStats()
    {
        Strength = CalculateStatByLevel(StrengthMultiplier);
        Intellect = CalculateStatByLevel(IntellectMultiplier);
        Dexterity = CalculateStatByLevel(DexterityMultiplier);
        Vitality = CalculateStatByLevel(VitalityMultiplier);

        MaxHealth = Vitality * StatMultiplier;
        MaxEnergy = 100;
        Health = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        NextHealthRegen = Time.time + 5f;
    }

    public void AddWeaponStats(MeleeWeapon eq)
    {
        MinDmg += eq.MinPhysicalDamage;
        MaxDmg += eq.MaxPhysicalDamage;
        MinElementalDamage += eq.MinElementalDamage;
        MaxElementalDamage += eq.MaxElementalDamage;
    }

    public void RemoveStats(MeleeWeapon eq)
    {
        MinDmg -= eq.MinPhysicalDamage;
        MaxDmg -= eq.MaxPhysicalDamage;
        MinElementalDamage -= eq.MinElementalDamage;
        MaxElementalDamage -= eq.MaxElementalDamage;
    }

    private int CalculateStatByLevel(float multiplier)
    {
        return Mathf.RoundToInt((multiplier * StatMultiplier) * (1 + Level * LevelMultiplier));
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
