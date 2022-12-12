using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBlock : MonoBehaviour
{
    public Placeable Placeable;
    public string CodeName;
    public Material material;
    public ProgrammingObjectConfig config;

    private void Awake()
    {
        Placeable = GetComponent<Placeable>();
        material = GetComponent<MeshRenderer>().material;
    }

    private void Start()
    {
        
    }

    public void Set(ProgrammingObjectConfig config)
    {
        this.config = config;
        CodeName = config.name;
        material.color = config.BlockColor;
        Placeable.Placing = true;
    }


}
