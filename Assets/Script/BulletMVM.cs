using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMVM : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 direction;
    [SerializeField] GameObject _particleEffectOnExplosion;
    [SerializeField] GameObject _particleEffectOnhit;
    private void Start()
    {
        Destroy(gameObject, 5);
    }
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    public void Init(Vector3 dir)
    {
        direction = dir;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Instantiate(_particleEffectOnExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            return;
        }
        Instantiate(_particleEffectOnhit, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
