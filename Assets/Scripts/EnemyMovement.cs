using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int pathIndex;
    private int waypointIndex = 0;

    void Start() {
        System.Random r = new System.Random();
        pathIndex = r.Next(0, Waypoints.paths.Count);
        target = Waypoints.paths[pathIndex][waypointIndex];
    }

    void Update() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f) {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint() {

        if(waypointIndex >=  Waypoints.paths[pathIndex].Length-1) {
            Destroy(gameObject);
            return;
        }

        target = Waypoints.paths[pathIndex][++waypointIndex];
    }

}
