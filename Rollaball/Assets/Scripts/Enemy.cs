using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// reference: 
public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0;
    public List<Transform> wayPoints;
    private int wayPointIndex;
    private float range;
    void Start()
    {
        wayPointIndex = 0;
        range = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.LookAt(wayPoints[wayPointIndex].position); 
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, wayPoints[wayPointIndex].position) <= range)
        {
            wayPointIndex++;
            if (wayPointIndex >= wayPoints.Count)
            {
                wayPointIndex = 0;
            }
        }
    }
}
