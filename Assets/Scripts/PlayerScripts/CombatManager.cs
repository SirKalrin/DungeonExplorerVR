using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public void AttackTarget(GameObject attacker, GameObject target)
    {
        if (attacker.tag == "EnemyAI" && target.tag == "Player" || attacker.tag == "Player" && target.tag == "EnemyAI")
        {
            target.GetComponent<Stats>().TakeDamage(attacker.GetComponent<Stats>().GetCalculatedDamage());
        }
    }

    public void ProjectileHit(GameObject target, MeleeWeapon projectile, bool headshot)
    {
        int damage = Random.Range(projectile.MinPhysicalDamage, projectile.MaxPhysicalDamage);
        if (headshot)
            damage *= 10;
        target.GetComponentInParent<Stats>().TakeDamage(damage); //TODO - Make ranged kills give the attacker points. Maybe refactor projectile to have a refference to the sender.
        Debug.Log("Health: " + target.GetComponentInParent<Stats>().Health);
    }

    public void MeleeHit(Stats attackerStats, Stats targetStats, bool headshot)
    {
        int damage = attackerStats.GetCalculatedDamage();
        if (headshot)
            damage *= 10;
        if(targetStats.TakeDamage(damage))
            attackerStats.AddPoints(targetStats.MaxHealth);
        Debug.Log("Health: " + targetStats.Health);
    }
}