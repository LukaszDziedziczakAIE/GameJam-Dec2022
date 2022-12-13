using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour
{
    GameController game;
    [SerializeField] MeshRenderer[] meshRenderers;
    [SerializeField] List<Material[]> mat_arrays = new List<Material[]>();
    public bool Placing;
    PlaceableObject config;
    [SerializeField] List<Collider> colliders = new List<Collider>();
    Character character;

    private void Awake()
    {
        game = FindObjectOfType<GameController>();
        character = GetComponent<Character>();
    }

    private void Start()
    {
        game.InputReader.RightMouseEvent += OnCancel;
        game.InputReader.LeftMouseEvent += OnPlace;
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
        if (character != null) character.Controller.enabled = false;
        game.isPlacing = true;
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
            //Debug.LogError(name + " missing meshRenderers array.");
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

        if (validPlacement) SetMaterialsPlacementValid();
        else SetMaterialsPlacementInvalid();

        float x;
        float y;
        float z;

        float remainderY;
        float remainderZ;

        if (game.PositionUnderMouse != Vector3.zero)
        {
            
            if (config != null) x = config.xPos;
            else x = 0;

            y = game.PositionUnderMouse.y;
            remainderY = y % game.GridSnapInterval;
            if (remainderY > (game.GridSnapInterval * 10 / 2)) y += ((game.GridSnapInterval * 10) - remainderY);
            else y -= remainderY;

            z = game.PositionUnderMouse.z;
            remainderZ = z % game.GridSnapInterval;
            if (remainderZ > (game.GridSnapInterval * 10 / 2)) z += ((game.GridSnapInterval * 10) - remainderZ);
            else z -= remainderZ;

            transform.position = new Vector3(x, y, z);
        }
        else
        {
            transform.position = new Vector3(0, 100f, 0);
        }
    }

    private bool validPlacement
    {
        get
        {
            if (colliders.Count > 0)
            {
                //print("EnviromentLayer = " + game.EnviromentLayer.value);
                //print("CharacterLayer = " + game.CharacterLayer.value);
                foreach (Collider collider in colliders)
                {
                    if (((1 << collider.gameObject.layer) & game.CharacterLayer) != 0) return false;
                    if (((1 << collider.gameObject.layer) & game.EnviromentLayer) != 0) return false;
                    if (((1 << collider.gameObject.layer) & game.InteractableLayer) != 0) return false;
                    if (((1 << collider.gameObject.layer) & game.GroundLayer) != 0) return false;
                }
                
            }

            return true;
        }
    }


    private void OnCancel()
    {
        game.InputReader.RightMouseEvent -= OnCancel;
        game.InputReader.LeftMouseEvent -= OnPlace;
        Destroy(gameObject);
        game.isPlacing = false;
    }


    private void OnPlace()
    {
        if (!validPlacement || !game.isPlacing || config == null || game == null || game.PointSystem == null) return;

        Placing = false;
        game.isPlacing = false;
        game.InputReader.RightMouseEvent -= OnCancel;
        game.InputReader.LeftMouseEvent -= OnPlace;
        SetMaterialsOriginal();

        if(gameObject.TryGetComponent<EnemyCharacter>(out EnemyCharacter enemy))
        {
            enemy.inLevel = true;
        }

        if (character != null) character.Controller.enabled = true;

        if (config.isArt) game.PointSystem?.AddArtPoints(config.Cost);
        else if (config.isDesign) game.PointSystem?.AddDesignPoints(config.Cost);
    }


    private void OnTriggerEnter(Collider other)
    {
        //print("Add " + other.gameObject.name);
        colliders.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        //print("Removed " + other.gameObject.name);
        colliders.Remove(other);
    }

    public void RestartPlacement()
    {
        if (config != null)
        {
            if (config.isArt) game.PointSystem?.RemoveArtPoints(config.Cost);
            else if (config.isDesign) game.PointSystem?.RemoveDesignPoints(config.Cost);
        }
        else Debug.LogError(name + " is missing config!");
        
        Placing = true;
        game.isPlacing = true;
        game.InputReader.RightMouseEvent += OnCancel;
        game.InputReader.LeftMouseEvent += OnPlace;
    }

    private bool isGrounded
    {
        get
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            //print(position);
            Vector3 down = transform.up * -1;
            Ray ray = new Ray(position, down);
            //Debug.DrawLine(ray.origin, ray.origin + transform.up * -1f * Game.GroundRaycastLength, Color.red);
            if (Physics.Raycast(ray, game.PlaceableGroundRaycastDistance, game.GroundLayer) ||
                Physics.Raycast(ray, game.PlaceableGroundRaycastDistance, game.InteractableLayer)) return true;
            return false;
        }
    }
}
