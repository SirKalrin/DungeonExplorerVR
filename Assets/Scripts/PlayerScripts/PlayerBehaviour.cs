using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Backpack _backpack;
    private Walk _movement;
    private Stats _playerStats;
    private float _atkCooldown;
    
    // Use this for initialization
    void Start()
    {
        _atkCooldown = 0;
        _backpack = transform.FindChild("Main Camera").FindChild("Canvas").GetComponentInChildren<Backpack>();
        _movement = GetComponent<Walk>();
        _playerStats = GetComponent<Stats>();
        _backpack.ToggleBackpack();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
            _backpack.ToggleBackpack();
        else
            _movement.MoveByInput();
        if (Input.GetButton("Fire1"))
        {
            Attack();
        }
    }

    private void Attack()
    {
        Weapon weapon = this.gameObject.GetComponentInChildren<Weapon>();
        weapon.Attack(_playerStats.AttackSpeed);

    }
}
