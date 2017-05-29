using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject Enemy;
    private GameObject RealEnemy;
    private int spawnPointCount;
    private List<GameObject> enemies;
    private float nextSpawnTime;
    public float coolDown = 2;
    public int wave = 0;
    private float nextWaveTime;
    private float waveCoolDown = 10f;

    // Use this for initialization
    void Start()
    {
        enemies = new List<GameObject>();
        NextWave(++wave);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextWaveTime)
        {
            NextWave(++wave);
        }
    }


    void NextWave(int wave)
    {
        spawnPointCount = this.transform.childCount;
        StartCoroutine(SpawnCoroutine(wave));

        waveCoolDown += 5f;
        nextWaveTime = Time.time + waveCoolDown;
    }

    private IEnumerator SpawnCoroutine(int wave)
    {
        yield return new WaitForSeconds(coolDown);
        for (var i = 0; i < wave; i++)
        {
            if (i >= spawnPointCount)
            {
                yield return SpawnCoroutine(wave - spawnPointCount);
            }
            else
            {
                var enemy = Instantiate(Enemy, 
                    this.gameObject.transform.GetChild(i).position,
                    Quaternion.identity);
                enemy.SetActive(true);
            }
        }
    }
}
