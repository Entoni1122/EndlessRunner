using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CorridorManager : MonoBehaviour
{
    Vector3 positioToGo;
    [SerializeField] List<GameObject> nodeList;
    [SerializeField] public List<GameObject> spawnedList;

    private void Update()
    {
        for (int i = 0; i < spawnedList.Count; i++)
        {
            spawnedList[i].transform.Translate(Time.deltaTime * GlobalVariables.nodeSpeed * Vector3.forward);
        }
    }
    public void CreateNewNode()
    {
        int randomPregav = Random.Range(0, nodeList.Count);

        positioToGo = transform.GetChild(transform.childCount - 1).transform.position;

        GameObject t = Instantiate(nodeList[randomPregav], positioToGo + Vector3.forward * 20, Quaternion.identity, transform);
        spawnedList.Add(t);
    }

    public void ResetCoordinateToZero()
    {
        for (int i = 0; i < nodeList.Count; i++)
        {
            spawnedList[i].transform.position = new Vector3(0, 0, 20 * i);
        }
    }


}
