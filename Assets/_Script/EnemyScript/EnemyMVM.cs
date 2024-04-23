using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;

public class EnemyMVM : MonoBehaviour
{
    [SerializeField] GameObject _onDeadParticle;
    public float maxHP;
    float currentHP;

    Rigidbody _rb;
    MeshRenderer _meshRenderer;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        currentHP = maxHP;
    }
    private void OnEnable()
    {
        currentHP = maxHP;
    }
    void Update()
    {
        transform.Translate(new Vector3(0, 0, GlobalVariables.enemySpeed) * Time.deltaTime);
    }

    public void OnDMGTaken(float dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0)
        {
            OnDEAD();
        }
    }

    private void OnDEAD()
    {
        _rb.useGravity = true;
        _meshRenderer.material = OnDeadMaterial;
        StartCoroutine(Died());
    }
    [SerializeField] private Material OnDeadMaterial;
    IEnumerator Died()
    {
        float time = 0;

        while (time < 1)
        {
            time += Time.deltaTime / 1;
            yield return null;
        }

        Instantiate(_onDeadParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
