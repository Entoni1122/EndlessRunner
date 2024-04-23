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

    [field: SerializeField] public float Xspray;
    [field: SerializeField] public float Yspray;


    public Vector3 SprayShootPoint()
    {
        float x = Random.Range(-Xspray, Xspray);
        float y = Random.Range(-Yspray, Yspray);

        return new Vector3(x, y, 0);
    }
}
