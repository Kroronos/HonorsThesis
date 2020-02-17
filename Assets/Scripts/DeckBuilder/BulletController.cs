using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    private int damage;

    public void InstantializeDamage(int dam)
    {
        damage = dam;
    }

    void Start()
    {
        StartCoroutine(DestroyAfterSeconds(2f));
    }

    private IEnumerator DestroyAfterSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy") collision.gameObject.GetComponent<EnemyController>().Damage(damage);
        Destroy(gameObject);
    }
}
