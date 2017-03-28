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
        if (attacker.tag != "Player")
        {
            AIStats attackerStats = attacker.GetComponent<AIStats>();
            PlayerStats targetStats = target.GetComponent<PlayerStats>();

            targetStats.Health -= attackerStats.Damage * (attackerStats.Level / targetStats.Level);

            Debug.Log("Player health: " + targetStats.Health);
        }
    }
}
