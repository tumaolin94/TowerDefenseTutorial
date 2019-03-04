using System;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;

    private Transform attackTarget;

    private int wavePointIndex = 0;

    public string enemyTag = "Turret";
    public float range = 30f;

    void Start()
    {
        target = Waypoints.points[0];
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        if (attackTarget != null)
        {
            Debug.Log("see turret");
            dir = Vector3.zero;
        }


        transform.Translate(dir.normalized * speed * Time.deltaTime);


        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {

            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        //print(wavePointIndex+", "+ (Waypoints.points.Length - 1));
        if(wavePointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            wavePointIndex++;
            target = Waypoints.points[wavePointIndex];
        }

    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        Debug.Log("shortestDistance  " + shortestDistance);
        if (nearestEnemy != null && shortestDistance < range)
        {
            Debug.Log("change attachTarget  " + shortestDistance);
            attackTarget = nearestEnemy.transform;
            //targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            attackTarget = null;
        }
    }
}
