using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    [SerializeField]
    public int MaxHealth = 100;
    public int Health = 100;
    public int MinDmg;
    public int MaxDmg;
    public int Points;

    public int GetCalculatedDamage()
    {
        int damage = Random.Range(MinDmg, MaxDmg);
        Points += damage;
        return damage;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("is taking damage: " + damage);
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
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
        MinDmg += eq.MinPhysicalDamage;
        MaxDmg += eq.MaxPhysicalDamage;
    }

    public void RemoveStats(MeleeWeapon eq)
    {
        MinDmg -= eq.MinPhysicalDamage;
        MaxDmg -= eq.MaxPhysicalDamage;
    }
}
