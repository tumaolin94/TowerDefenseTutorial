using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;

    private int wavePointIndex = 0;

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
}
