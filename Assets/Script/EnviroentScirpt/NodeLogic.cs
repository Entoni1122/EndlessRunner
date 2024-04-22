using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class NodeLogic : MonoBehaviour
{
    [SerializeField] float magnitudeTollerance;
    private Transform parent;
    float speed = GlobalVariables.nodeSpeed;
    private void Start()
    {
        parent = transform.parent;
    }
    void Update()
    {
        if (Camera.main.transform.position.z > transform.position.z + magnitudeTollerance)
        {
            parent.GetComponent<CorridorManager>().CreateNewNode();
            Destroy(gameObject);
        }
    }
}
