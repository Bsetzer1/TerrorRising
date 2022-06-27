using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject m_EnemyPrefab;
    public int count;
    public int KillCount;
    public int MaxZombieSpawn = 10;

    // Start is called before the first frame update

    public void Update()
    {
        if(count < MaxZombieSpawn)
        {
            SpawnNewEnemy();
        }
        if (KillCount == MaxZombieSpawn)
        {
            KillCount = 0;
            count = 0;
            MaxZombieSpawn = MaxZombieSpawn + 5;
        }
    }

    void SpawnNewEnemy()
    {
        Instantiate(m_EnemyPrefab, m_SpawnPoints[0].transform.position, Quaternion.identity);
        count++;
    }
}
