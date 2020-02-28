using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

    private Transform[] path;
    private Transform target;

    private int pathIndex = 0;

    private Enemy enemy;

    void Start() {

        enemy = GetComponent<Enemy>();

        path = Waypoints.waypoints.GetPathFromSource(enemy.source);

        target = path[pathIndex];
    }

    void LateUpdate() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.1f) {
            GetNextWaypoint();
        }

        //resets speed so if a slow applied on update [For this to work properly needs to be late update or delayed script execution]
        enemy.speed = enemy.baseSpeed;
    }

    void GetNextWaypoint() {
        if (++pathIndex >= path.Length) {
            Destroy(enemy.gameObject);
        }

        else {
            target = path[pathIndex];
        }
    }

}
