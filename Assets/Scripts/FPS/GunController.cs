using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 
/// TODO:
///
///     - Add Reload Animation
///     - Bullet goes in forward direction barrel + mouse
///     - Crosshairs Implementation with Shooting
///     
/// </summary>

public class GunController : MonoBehaviour
{
    public TextMeshProUGUI ammoText;

    private Gun reference;
    private GameObject instantiatedGun, reticle;
    private Camera camera;

    private Transform barrel; 
    private bool nextShot = true, holding = false;
    private Quaternion gunRot;
    private Vector3 bulletDirection;

    private void Awake()
    {
        camera = transform.GetChild(0).GetComponent<Camera>();
    }

    public void InstantiateGun(Transform player, Gun gun)
    {
        reference = gun;
        reference.currentClipCapacity = reference.totalClipCapacity;

        ammoText.text = reference.currentClipCapacity.ToString() + "/" + reference.totalAmmoCapacity.ToString();
        Vector3 gunPosition = new Vector3(.25f, -.03f, 0f);
        Quaternion rotation = reference.gunPrefab.transform.rotation;
        rotation = Quaternion.RotateTowards(rotation, Quaternion.Euler(0f, 25f, 0f), 25f);
        instantiatedGun = Instantiate(reference.gunPrefab, player.transform.position + player.transform.forward + gunPosition, reference.gunPrefab.transform.rotation);
        instantiatedGun.transform.parent = player.transform.GetChild(0).transform; //Need to make a script on Gun to follow player
        gunRot = instantiatedGun.transform.rotation;

        barrel = instantiatedGun.transform.GetChild(0).transform;
        //Create Reticle Image
        reticle = new GameObject ();
        reticle.name = "Reticle";
        reticle.transform.parent = player.transform.GetChild(0).transform.GetChild(0).transform;
        Image img = reticle.AddComponent<Image>();
        img.sprite = reference.reticle;
        reticle.transform.localScale /= 10f;
        reticle.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        Vector3 bulletDirection = camera.ScreenToWorldPoint(new Vector3(0f, 0f, camera.farClipPlane));
    }

    public void Reload ()
    {
        if (reference.currentClipCapacity != reference.totalClipCapacity && reference.totalAmmoCapacity != 0)
        {
            int ammoToAdd = reference.totalClipCapacity - reference.currentClipCapacity;
            reference.currentClipCapacity += ammoToAdd;
            reference.totalAmmoCapacity -= ammoToAdd;
            ammoText.text = reference.currentClipCapacity.ToString() + "/" + reference.totalAmmoCapacity.ToString();
        }
    }

    public void Shoot(bool onPressDown)
    {
        holding = onPressDown;
        if (!nextShot) return;
        if (holding && reference.currentClipCapacity > 0)
        {
            BulletTrajectory();

            reference.currentClipCapacity--;
            ammoText.text = (reference.currentClipCapacity).ToString() + "/" + reference.totalAmmoCapacity.ToString();
            StartCoroutine("CanShoot");
        }
    }

    private void BulletTrajectory()
    {
        GameObject tempBullet = Instantiate(reference.bullet, barrel.transform.position, Quaternion.identity);
        tempBullet.GetComponent<BulletController>().InstantializeDamage(reference.damageGiven);
        //tempBullet.GetComponent<Rigidbody>().AddForce(instantiatedGun.transform.forward * reference.shootSpeed, ForceMode.Impulse);
        tempBullet.GetComponent<Rigidbody>().AddForce(
            (bulletDirection + instantiatedGun.transform.forward)
            * reference.shootSpeed, ForceMode.Impulse);
    }

    private IEnumerator CanShoot()
    {
        nextShot = false;
        yield return new WaitForSeconds(60f / reference.shootRate);
        nextShot = true;
        if (holding) Shoot(holding);
    }
}
