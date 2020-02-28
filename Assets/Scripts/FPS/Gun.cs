using UnityEngine;

[CreateAssetMenu(fileName = "NewGun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    public string gunName;
    public GameObject gunPrefab;
    public GameObject bullet;
    public float shootRate; // bullets/second
    public float shootSpeed;
    public Sprite reticle;
    public int totalClipCapacity, currentClipCapacity, totalAmmoCapacity;
    public int damageGiven;
}
