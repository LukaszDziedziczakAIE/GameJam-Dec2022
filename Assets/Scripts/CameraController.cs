using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera Camera { get; private set; }

    [SerializeField] Vector3 startingPos;
    [SerializeField] Vector3 programmingPos;
    [SerializeField] Vector3 programmingAngles;
    [SerializeField] Vector3 levelScreenAngles;
    [SerializeField] Vector3 characterScreenAngles;

    private void Awake()
    {
        Camera = GetComponent<Camera>();
    }

    private void Start()
    {
        //startingPos = transform.position;
        //levelScreenAngles = transform.eulerAngles;
    }

    public void FaceLevel()
    {
        transform.position = startingPos;
        transform.eulerAngles = levelScreenAngles;
    }

    public void FaceCharacterCreator()
    {
        transform.position = startingPos;
        transform.eulerAngles = characterScreenAngles;
    }

    public void FaceProgramming()
    {
        transform.position = programmingPos;
        transform.eulerAngles = programmingAngles;
    }
}
