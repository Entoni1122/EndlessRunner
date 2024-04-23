using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class NodeLogic : MonoBehaviour
{
    [SerializeField] float magnitudeTollerance;
    private Transform parent;
    private CorridorManager corridorRef;
    float speed = GlobalVariables.nodeSpeed;
    private void Start()
    {
        parent = transform.parent;
        corridorRef = transform.parent.GetComponent<CorridorManager>();
    }
    void Update()
    {
        if (Camera.main.transform.position.z > transform.position.z + magnitudeTollerance)
        {
            corridorRef.CreateNewNode();
            corridorRef.spawnedList.Remove(this.gameObject);
            Destroy(gameObject);
        }
    }
}
