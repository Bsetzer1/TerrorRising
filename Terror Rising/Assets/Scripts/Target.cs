using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public EnemyManager Killed;

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Killed.KillCount++;
        Destroy(gameObject);
    }
}
