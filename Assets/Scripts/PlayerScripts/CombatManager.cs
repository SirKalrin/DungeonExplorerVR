using System.Collections;
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
        if (attacker.tag == "EnemyAI" && target.tag == "Player")
        {
            AIStats attackerStats = attacker.GetComponent<AIStats>();
            StatController targetStatController = target.GetComponent<StatController>();

            targetStatController.TakeDamage(attackerStats.Damage * (attackerStats.Level / targetStatController.Level));
        }
    }
}
