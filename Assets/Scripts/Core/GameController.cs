using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [field: SerializeField] public UI_HUD HUD { get; private set; }
    [field: SerializeField] public CameraController Camera { get; private set; }
    [field: SerializeField] public PlayerCharacter PlayerCharacter { get; private set; }
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public CharacterConfig[] CharacterConfig { get; private set; }
    [SerializeField] private int numberOfCharacter = 5;
    [SerializeField] float raycastDistance = 10f;
    [field: SerializeField, Header("Materials")] public Material placingMaterialValid { get; private set; }
    [field: SerializeField] public Material placingMaterialInvalid { get; private set; }
    
    [field: SerializeField, Header("Layers")] public LayerMask BackgroundLayer;
    [field: SerializeField] public LayerMask GroundLayer;
    [field: SerializeField] public LayerMask EnviromentLayer;
    [field: SerializeField] public LayerMask InteractableLayer;
    [field: SerializeField] public LayerMask CharacterLayer;

    public bool TestingMode = false;

    public Vector3 PositionUnderMouse
    {
        get
        {
            Ray ray = Camera.Camera.ScreenPointToRay(InputReader.MousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, raycastDistance, BackgroundLayer)) return hit.point;
            else return Vector3.zero;
        }
    }

    private void Start()
    {
        CreateListCharacterConfigs();
    }

    private void Update()
    {
        //print(PositionUnderMouse);
    }

    private void CreateListCharacterConfigs()
    {
        List<CharacterConfig> characterConfigList = new List<CharacterConfig>();

        for (int i = 0; i < numberOfCharacter; i++)
        {
            CharacterConfig config = new CharacterConfig();
            characterConfigList.Add(config);
        }

        CharacterConfig = characterConfigList.ToArray();
    }
}
