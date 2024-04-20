using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [SerializeField] GameObject playerRef;
    void Update()
    {
        if (playerRef.transform.position.z > 30)
        {
            playerRef.transform.position = transform.position;
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).transform.position = new Vector3(0, 0, transform.position.z + (20 * i));
            }
        }
    }
}
