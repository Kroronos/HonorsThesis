using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// TODO:
///     - Implement Hold Down to Keep Shooting Bullets
///     - Reload Functionality
///     - Bullet goes in forward direction barrel + mouse
///     - Crosshairs
///     - Turning back is weird with camera movement and mouse movement
///     
/// </summary>

public class GunController : MonoBehaviour
{
    private Gun reference;
    private GameObject instantiatedGun, reticle;
    private Transform barrel;
    private bool nextShot = true;

    public void InstantiateGun(Transform player, Gun gun)
    {
        reference = gun;
        Vector3 gunPosition = new Vector3(.35f, .4f, 0f);
        Quaternion rotation = reference.gunPrefab.transform.rotation;
        rotation = Quaternion.RotateTowards(rotation, Quaternion.Euler(0f, 25f, 0f), 25f);
        instantiatedGun = Instantiate(reference.gunPrefab, player.transform.position + player.transform.forward + gunPosition, reference.gunPrefab.transform.rotation);
        instantiatedGun.transform.parent = player.transform.GetChild(0).transform; //Need to make a script on Gun to follow player

        barrel = instantiatedGun.transform.GetChild(0).transform;
        //Create Reticle Image
        reticle = new GameObject ();
        reticle.name = "Reticle";
        reticle.transform.parent = transform.GetChild(1);
        Image img = reticle.AddComponent<Image>();
        img.sprite = reference.reticle;
        reticle.transform.localScale /= 10f;
        reticle.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;  
    }

    public void Shoot()
    {
        if (!nextShot) return;
        GameObject tempBullet = Instantiate(reference.bullet, barrel.transform.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody>().AddForce(instantiatedGun.transform.forward * reference.shootSpeed, ForceMode.Impulse);
        StartCoroutine("CanShoot");
    }

    private IEnumerator CanShoot()
    {
        nextShot = false;
        yield return new WaitForSeconds(60f / reference.shootRate);
        nextShot = true;
    }

    public void Update()
    {
    }
}
