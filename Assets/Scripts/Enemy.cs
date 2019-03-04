using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    protected float speed;

    public float startHealth = 100;
    protected float health;

    public int worth = 50;

    public GameObject deathEffect;

    protected Transform target;

    private int wavePointIndex = 0;
    protected bool isDead = false;

    [Header("Unity Stuff")]
    public Image healthBar;

    public float getHealth()
    {
        return this.health;
    }

    void Start()
    {
        target = Waypoints.points[0];
        health = startHealth;
        speed = startSpeed;

        Debug.Log("Enemy startHealth + " + health + " startSpeed " + speed);
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
        Debug.Log(this.name+ " TakeDamage before " + health + "speed "+ speed);
        health -= amount;
        Debug.Log("TakeDamage " + amount + "left " + health);
        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    protected void Die()
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
