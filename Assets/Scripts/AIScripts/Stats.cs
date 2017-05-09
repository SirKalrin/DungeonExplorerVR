using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    [SerializeField]
    public int MaxHealth = 100;
    public int Health = 100;
    public int Damage = 20;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
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
            //SceneManager.LoadScene("Death");
        }
        else if (gameObject.tag == "EnemyAI")
        {
            gameObject.GetComponent<AIController>().Die();
        }
    }
}
