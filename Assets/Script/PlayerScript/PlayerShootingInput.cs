using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingInput : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _muzzle;

    [SerializeField] GameObject aimTarget;
    // Update is called once per frame
    void Update()
    {
        ShootInput();
    }

    void ShootInput()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        if (Physics.Raycast(camRay, out raycastHit, 300))
        {
            Vector3 dir = (raycastHit.point - _muzzle.position).normalized;
            aimTarget.transform.position = raycastHit.point;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot(dir);
            }
        }
    }
    void Shoot(Vector3 dir)
    {
        GameObject bulletRef = Instantiate(_bullet, _muzzle.position, Quaternion.identity);
        bulletRef.GetComponent<BulletMVM>().Init(dir);
    }
}
