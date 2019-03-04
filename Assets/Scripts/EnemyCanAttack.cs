using UnityEngine;
using UnityEngine.UI;

public class EnemyCanAttack : Enemy
{

    //protected new float health;

    //void Start()
    //{
    //    target = Waypoints.points[0];
    //    health = startHealth;
    //    speed = startSpeed;

    //    Debug.Log("EnemyCanAttack startHealth + " + health + " startSpeed " + speed);
    //}

    public new void TakeDamage(int amount)
    {
        Debug.Log("EnemyCanAttack TakeDamage " + amount + "left " + getHealth());
        health -= amount;
        Debug.Log("EnemyCanAttack TakeDamage " + amount + "left " + health);
        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !base.isDead)
        {
            Die();
        }
    }
}
