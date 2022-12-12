using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour
{
    GameController game;
    [SerializeField] MeshRenderer[] meshRenderers;
    [SerializeField] List<Material[]> mat_arrays = new List<Material[]>();
    
    public bool Placing = true;
    PlaceableObject config;

    private void Awake()
    {
        game = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        game.InputReader.RightMouseEvent += OnCancel;
    }

    private void Update()
    {
        PlacingLogic();
    }

    public void Set(PlaceableObject config)
    {
        this.config = config;
        SaveOriginalMaterials();
        SetMaterialsPlacementValid();
    }

    public void SaveOriginalMaterials()
    {
        if (meshRenderers.Length == 0) meshRenderers = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            Material[] materials = meshRenderer.materials;
            mat_arrays.Add(materials);
        }
    }

    private void SetMaterials(Material newMaterial)
    {
        if (meshRenderers.Length == 0)
        {
            Debug.LogError(name + " missing meshRenderers array.");
            return;
        }

        if (newMaterial == null)
        {
            Debug.LogError(name + " missing new Material referance.");
            return;
        }

        for (int i = 0; i < meshRenderers.Length; i++)
        {
            int size = meshRenderers[i].materials.Length;

            List<Material> newMaterialList = new List<Material>();
            for (int j = 0; j < size; j++)
            {
                newMaterialList.Add(newMaterial);
            }

            meshRenderers[i].materials = newMaterialList.ToArray();
        }
    }

    public void SetMaterialsPlacementValid()
    {
        SetMaterials(game.placingMaterialValid);
    }

    public void SetMaterialsPlacementInvalid()
    {
        SetMaterials(game.placingMaterialInvalid);
    }

    public void SetMaterialsOriginal()
    {
        if (meshRenderers.Length == 0) return;

        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].materials = mat_arrays[i];
        }
    }

    private void PlacingLogic()
    {
        if (!Placing || config == null) return;

        if (game.PositionUnderMouse != Vector3.zero)
        {
            transform.position = new Vector3(config.xPos, game.PositionUnderMouse.y, game.PositionUnderMouse.z);
        }
        else
        {
            transform.position = new Vector3(0, 100f, 0);
        }

        
    }

    private void OnCancel()
    {
        Destroy(gameObject);
    }

}
