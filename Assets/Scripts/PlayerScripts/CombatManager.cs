using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private StatsManager _statsManager;

    void Start()
    {
        _statsManager = GetComponent<StatsManager>();
    }

    //public void AttackTarget(GameObject attacker, GameObject target)
    //{
    //    if (attacker.tag == "EnemyAI" && target.tag == "Player" || attacker.tag == "Player" && target.tag == "EnemyAI")
    //    {
    //        target.GetComponent<Stats>().TakeDamage(attacker.GetComponent<Stats>().GetCalculatedDamage());
    //    }
    //}

    //public void ProjectileHit(GameObject target, MeleeWeapon projectile, bool headshot)
    //{
    //    int damage = Random.Range(projectile.MinPhysicalDamage, projectile.MaxPhysicalDamage);
    //    if (headshot)
    //        damage *= 10;
    //    target.GetComponentInParent<Stats>().TakeDamage(damage); //TODO - Make ranged kills give the attacker points. Maybe refactor projectile to have a refference to the sender.
    //    Debug.Log("Health: " + target.GetComponentInParent<Stats>().Health);
    //}

    public void Hit(Stats attackerStats, Stats targetStats, bool headshot)
    {
        if (attackerStats != targetStats)
        {
            int damage = _statsManager.GetCalculatedDamage(attackerStats);
            if (headshot)
                damage *= 10;
            if (_statsManager.TakeDamage(targetStats, damage))
                _statsManager.AddPoints(attackerStats, targetStats.MaxHealth);
            Debug.Log("Health: " + targetStats.Health);
        }
    }
}