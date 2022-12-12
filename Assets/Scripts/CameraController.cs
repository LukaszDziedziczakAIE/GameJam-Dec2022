using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera Camera;

    private void Awake()
    {
        Camera = GetComponent<Camera>();
    }

    public void FaceLevel()
    {
        transform.eulerAngles = new Vector3(0, 90, 0);
    }

    public void FaceCharacterCreator()
    {
        transform.eulerAngles = new Vector3(0, -90, 0);
    }
}
