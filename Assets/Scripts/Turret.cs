using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Buildable
{
    public Enemy target;
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 1f;
    public float damage = 1f;

    public string enemyTag = "Enemy";
    public Transform rotatingPart;
    public int firingAngle;
    public float turnSpeed;
    public Quaternion defaultRotation;

    void Start()
    {
        defaultRotation = rotatingPart.rotation; //@TODO default not valid after placement rotation
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
            target = nearestEnemy.GetComponent<Enemy>();
        }
        else { 
            target = null;
        }
    }


    // Update is called once per frame
    void Update() {
        if(!BuildingManager.buildingManager.InProgress()) { //@TODO correct for now, want to make it so check is done if specific turret is being managed
            Rotate();
            Shoot();
        }

    }

    void Rotate() {
       
        Quaternion lookRotation;

        if (target == null) {
            lookRotation = defaultRotation;
        }
        else {
            Vector3 dir = target.transform.position - transform.position;
            lookRotation = Quaternion.LookRotation(-1 * dir); ;
        }

        Vector3 rotation = Quaternion.Lerp(rotatingPart.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotatingPart.rotation = Quaternion.Euler(rotatingPart.rotation.x, rotation.y, rotatingPart.rotation.z);

    }

    public void PlacementRotate(float rotationSpeed) {
        
        transform.Rotate(Vector3.up, rotationSpeed);
        defaultRotation = rotatingPart.rotation; //maybe this


    }

    void Shoot() {
        fireCountdown -= Time.deltaTime;

        if (fireCountdown <= 0f && target != null) {
            target.TakeDamage(damage);
            fireCountdown = 1f / fireRate;
        }
    }

    void OnDrawGizmosSelected() { //turret arc
        Gizmos.color = Color.red;

        Vector3 forward = transform.TransformDirection(Vector3.back); //whether actual vector3 is .back or .forward is dependent upon model used

        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, firingAngle/2, 0) * forward  * range); //left
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, -firingAngle/2, 0) * forward * range); // right
    }
}
