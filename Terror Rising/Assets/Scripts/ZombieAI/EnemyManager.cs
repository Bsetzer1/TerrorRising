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
    public int xPos, zPos;
    public GameController Round;

    // Start is called before the first frame update

    public void Update()
    {
        if(count < MaxZombieSpawn)
        {
            SpawnNewEnemy();
        }
        if (KillCount == MaxZombieSpawn)
        {
            Round.round += 1;
            KillCount = 0;
            count = 0;
            MaxZombieSpawn = MaxZombieSpawn + 5;
        }
    }

    void SpawnNewEnemy()
    {
        xPos = Random.Range(-25, 20);
        zPos = Random.Range(12, 50);
        Instantiate(m_EnemyPrefab, new Vector3(xPos,0,zPos), Quaternion.identity);
        //m_SpawnPoints[0].transform.position
        count++;
    }
}
