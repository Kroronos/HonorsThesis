using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
    public float range = 15f;

    public string enemyTag = "Enemy";
    public Transform rotatingPart;
    public float turnSpeed;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
    }


    void UpdateTarget() {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float distanceToValidEnemy = Mathf.Infinity;
        GameObject nearestEnemy = null;

        Vector3 left = Quaternion.Euler(0, 60, 0) * transform.TransformDirection(Vector3.back) * range; 
        Vector3 right = Quaternion.Euler(0, -60, 0) * transform.TransformDirection(Vector3.back) * range;

        Vector2 left2d = new Vector2(left.x, left.z);
        Vector2 right2d = new Vector2(right.x, right.z);


        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);


            Vector3 enemyV = enemy.transform.position - transform.position;
            Vector2 enemy2d = new Vector2(enemyV.x, enemyV.z);

            if (distanceToEnemy < distanceToValidEnemy) {
                if (Vector2.SignedAngle(left2d, enemy2d) > 0 &&
                    Vector2.SignedAngle(enemy2d, right2d) > 0) { //in cone

                    distanceToValidEnemy = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            
            }
        }

        if(nearestEnemy != null && distanceToValidEnemy <= range) {
            target = nearestEnemy.transform;
        }
        else { 
            target = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        Vector3 rotation = Quaternion.Lerp(rotatingPart.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;

        rotatingPart.rotation = Quaternion.Euler(rotatingPart.rotation.x, rotation.y, rotatingPart.rotation.z);
        

    }

    void OnDrawGizmosSelected() { //turret arc
        Gizmos.color = Color.red;

        Vector3 forward = transform.TransformDirection(Vector3.back); //whether actual vector3 is .back or .forward is dependent upon model used

        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 60, 0) * forward  * range); //left
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, -60, 0) * forward * range); // right
    }
}
