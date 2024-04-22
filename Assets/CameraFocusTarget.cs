using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocusTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.transform.GetComponent<PlayerCameraFollow>()._target = transform;
    }
}
