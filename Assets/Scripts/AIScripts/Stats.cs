using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public int MaxHealth = 100;
    public int Health;
    [SerializeField]
    private int _minDmg;
    [SerializeField]
    private int _maxDmg;
    private int _points;

    void Start()
    {
        Health = MaxHealth;
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
    public void AddWeaponStats(MeleeWeapon eq)
    {
        _minDmg += eq.MinPhysicalDamage;
        _maxDmg += eq.MaxPhysicalDamage;
    }

    public void RemoveStats(MeleeWeapon eq)
    {
        _minDmg -= eq.MinPhysicalDamage;
        _maxDmg -= eq.MaxPhysicalDamage;
    }
}
