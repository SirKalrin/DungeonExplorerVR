﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AttackTarget(GameObject attacker, GameObject target)
    {
        if (attacker.tag == "EnemyAI" && target.tag == "Player" || attacker.tag == "Player" && target.tag == "EnemyAI")
        {
            AIStats attackerStats = attacker.GetComponent<AIStats>();
            StatController targetStatController = target.GetComponent<StatController>();

            targetStatController.TakeDamage(attackerStats.Damage * (attackerStats.Level / targetStatController.Level));
        }
    }

    public void ProjectileHit(GameObject target, Arrow projectile, bool headshot)
    {
        float damage = Random.Range(projectile.MinPhysicalDamage, projectile.MaxPhysicalDamage);
        if (headshot)
            damage *= 10;
        target.GetComponentInParent<AIStats>().Health -= (int)damage;
        Debug.Log(target.GetComponentInParent<AIStats>().Health);
    }

    public void MeleeHit(GameObject attacker, GameObject target, bool headshot)
    {
        Stats attackerStats = attacker.GetComponent<Stats>();
        Stats targetStats = target.GetComponent<Stats>();
        int damage = Random.Range(attackerStats.MinDmg, attackerStats.MaxDmg);
        if (headshot)
            damage *= 10;
        damage = damage * attackerStats.Level / targetStats.Level;
        StatController targetStatController = target.GetComponent<StatController>();
        targetStatController.TakeDamage(damage);
    }
}
