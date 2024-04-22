using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShootingInput : MonoBehaviour
{
    [SerializeField] Transform _muzzle;

    [SerializeField] GameObject aimTarget;
    [SerializeField] GameObject _particleEffectOnhit;
    [SerializeField] TrailRenderer _trail;

    public float bulletDMG;

    public float fireRate;
    float timer;
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
            timer -= Time.deltaTime;
            aimTarget.transform.position = raycastHit.point;
            if (timer <= 0)
            {
                if (raycastHit.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    return;
                }
                //Vector3 dir = (raycastHit.point - _muzzle.position).normalized;
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    if (raycastHit.transform.gameObject.GetComponent<EnemyMVM>())
                    {
                        raycastHit.transform.gameObject.GetComponent<EnemyMVM>().OnDMGTaken(bulletDMG);
                    }
                    TrailRenderer trail = Instantiate(_trail, _muzzle.position, Quaternion.identity);
                    StartCoroutine(SpawnTrail(trail, raycastHit));
                    timer = fireRate;
                }
            }
        }
    }

    IEnumerator SpawnTrail(TrailRenderer trail, RaycastHit hit)
    {
        float time = 0;
        Vector3 startpos = trail.transform.position;

        while (time < 1)
        {
            trail.transform.position = Vector3.Lerp(startpos, hit.point, time);

            time += Time.deltaTime / trail.time;
            yield return null;
        }

        trail.transform.position = hit.point;
        Instantiate(_particleEffectOnhit, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(trail.gameObject, trail.time);
    }

}
