using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

    private Transform target;
    private int pathIndex;
    private int waypointIndex = 0;

    private Enemy enemy;

    void Start() {

        enemy = GetComponent<Enemy>();

        System.Random r = new System.Random();
        pathIndex = r.Next(0, Waypoints.paths.Count);
        target = Waypoints.paths[pathIndex][waypointIndex];
    }

    void LateUpdate() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f) {
            GetNextWaypoint();
        }

        //resets speed so if a slow applied on update [For this to work properly needs to be late update or delayed script execution]
        enemy.speed = enemy.baseSpeed;
    }

    void GetNextWaypoint() {

        if(waypointIndex >=  Waypoints.paths[pathIndex].Length-1) {
            Destroy(gameObject);
            return;
        }

        target = Waypoints.paths[pathIndex][++waypointIndex];
    }

}
