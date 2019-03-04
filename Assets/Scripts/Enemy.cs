using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    public int health = 100;

    public int worth = 50;

    public GameObject deathEffect;

    private Transform target;

    private int wavePointIndex = 0;
    private bool isDead = false;


    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);


        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {

            GetNextWaypoint();
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        //healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        PlayerStats.Money += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        //WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }


    private void GetNextWaypoint()
    {
        //print(wavePointIndex+", "+ (Waypoints.points.Length - 1));
        if(wavePointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        else
        {
            wavePointIndex++;
            target = Waypoints.points[wavePointIndex];
        }

    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
