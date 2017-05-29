using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }


    private void Update()
    {

    }

    //Adds healt to the players Health stat. Ensures that Health never gets higher than MaxHealth.
    public void GainHealth(Stats targetStats, int health)
    {
        targetStats.Health += health;
        if (targetStats.Health > targetStats.MaxHealth)
            targetStats.Health = targetStats.MaxHealth;
    }

    //Returns a random number that is between _minDmg and _maxDmg
    public int GetCalculatedDamage(Stats attackerStats)
    {
        int damage = Random.Range(attackerStats.MinDmg, attackerStats.MaxDmg);
        attackerStats.Points += damage;
        return damage;
    }

    //Returns wether or not Die() has been called. subtracts the given damage from the Healts variable. If Health is less than, or equal to 0, Die() is called. 
    public bool TakeDamage(Stats targetStats, int damage)
    {
        Debug.Log("is taking damage: " + damage);
        targetStats.Health -= damage;

        if (targetStats.Health <= 0)
        {
            Die(targetStats);
            return true;
        }
        return false;
    }

    //Adds or subtracts the given points from the Points vaiable.
    public void AddPoints(Stats targetStats, int points)
    {
        targetStats.Points += points;
    }

    //Changes scene to the "Death" scene, if the gameobject implementing Stats has the tag "Player". 
    //If the gameobject implementing Stats has the tag "EnemyAI", the Die() method in the AIController is called.
    private void Die(Stats targetStats)
    {
        Debug.Log("method: die, gameobject.tag: " + targetStats.gameObject.tag);
        if (targetStats.gameObject.tag == "Player")
        {
            targetStats.SaveStats();
            Initiate.Fade("Death", Color.black, 1);
        }
        else if (targetStats.gameObject.tag == "EnemyAI")
        {
            targetStats.gameObject.GetComponent<AIController>().Die();
        }
    }

    //Adds the _minDmg and _maxDmg from the given equipment to the variables in Stats.
    public void AddStats(Stats targetStats, Equipment eq)
    {
        targetStats.MinDmg += eq.MinPhysicalDamage;
        targetStats.MaxDmg += eq.MaxPhysicalDamage;
        targetStats.AttackSpeed += eq.AttackSpeed;

    }

    //Removes the _minDmg and _maxDmg from the given equipment to the variables in Stats.
    public void RemoveStats(Stats targetStats, Equipment eq)
    {
        targetStats.MinDmg -= eq.MinPhysicalDamage;
        targetStats.MaxDmg -= eq.MaxPhysicalDamage;
        targetStats.AttackSpeed -= eq.AttackSpeed;

    }
}
