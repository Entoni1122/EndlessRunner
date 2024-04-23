using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableWeapon", menuName = "ScriptableObjects/Weapons", order = 1)]
public class ScriptableWeapon : ScriptableObject
{
    [field: SerializeField] string weaponName;
    [field: SerializeField] float fireRate { get; set; }
    [field: SerializeField] TrailRenderer trailRenderer;
    [field: SerializeField] float bulletDMG;


    [field: SerializeField] float Xspray;
    [field: SerializeField] float Yspray;
}
