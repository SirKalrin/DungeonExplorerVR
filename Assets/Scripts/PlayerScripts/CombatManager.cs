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

    public void ProjectileHit(GameObject target, Arrow projectile, bool headshot)
    {
        int damage = Random.Range(projectile.MinPhysicalDamage, projectile.MaxPhysicalDamage);
        if (headshot)
            damage *= 10;
        target.GetComponentInParent<Stats>().TakeDamage(damage);
        Debug.Log("Health: " + target.GetComponentInParent<Stats>().Health);
    }

    public void MeleeHit(GameObject attacker, GameObject target, bool headshot)
    {
        int damage = attacker.GetComponent<Stats>().GetCalculatedDamage();
        if (headshot)
            damage *= 10;
        target.GetComponent<Stats>().TakeDamage(damage);
        Debug.Log("Health: " + target.GetComponentInParent<Stats>().Health);
    }
}
