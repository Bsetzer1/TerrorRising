using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject Player;
    public float Distance;
    public float damage;
    public float attackTimer = 5f;
    public float attackTime = 0;
    public float AgroDistance = 5;

    public bool isAngered;

    public NavMeshAgent agent;

    PlayerHealth playerdamage;
    // Start is called before the first frame update
    void Start()
    {
        playerdamage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(Player.transform.position, this.transform.position);
        attackTime += Time.deltaTime;

        if (Distance <= AgroDistance)
        {
            isAngered = true;
        }
        else
        {
            isAngered = false;
        }

        if (isAngered)
        {
            agent.SetDestination(Player.transform.position);
        }
        if(Distance < 2 && attackTime >= attackTimer)
        {
            attackTime = 0;
            playerdamage.TakeDamage(25);

            
        }
    }
}
