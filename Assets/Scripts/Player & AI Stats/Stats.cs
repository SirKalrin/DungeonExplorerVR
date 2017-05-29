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

    void Awake()
    {
        Points = GlobalPointSystem.Instance.points;
    }

    // Use this for initialization
    void Start()
    {
        _nextHealthRegen = Time.time + 1;
        _nextEnergyRegen = Time.time + 1;
        Health = MaxHealth;
    }


    private void Update()
    {
        RegenStats();
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

    public void SaveStats()
    {
        GlobalPointSystem.Instance.points = Points;
    }

}
