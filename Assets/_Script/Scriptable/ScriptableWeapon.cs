using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableWeapon", menuName = "ScriptableObjects/Weapons", order = 1)]
public class ScriptableWeapon : ScriptableObject
{
    [field: SerializeField] string weaponName;

    [field: SerializeField] float fireRate { get; set; }
    public float FireRate
    {
        get { return fireRate; }
        set { fireRate = FireRate; }
    }

    [field: SerializeField]
    TrailRenderer trailRenderer;
    [field: SerializeField] float bulletDMG;
    public float BulletDMG
    {
        get { return bulletDMG; }
        set { bulletDMG = BulletDMG; }
    }


    [field: SerializeField] float Xspray;
    [field: SerializeField] float Yspray;
}
