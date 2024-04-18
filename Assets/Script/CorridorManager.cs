using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CorridorManager : MonoBehaviour
{
    [SerializeField] GameObject NodeToSpawn;
    Vector3 positioToGo;
    [SerializeField] List<GameObject> nodeList;
    public void CreateNewNode()
    {
        int randomPregav = Random.Range(0, nodeList.Count);

        positioToGo = transform.GetChild(transform.childCount - 1).transform.position;

        Instantiate(nodeList[randomPregav], positioToGo + Vector3.forward * 20,Quaternion.identity,transform);
    }
}
