using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [field: SerializeField] public UI_HUD HUD { get; private set; }
    [field: SerializeField] public CodeBlockDetector BlockDetector { get; private set; }
    [field: SerializeField] public CameraController Camera { get; private set; }
    [field: SerializeField] public PlayerCharacter PlayerCharacter { get; private set; }
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [SerializeField] float raycastDistance = 10f;
    [field: SerializeField] public float GridSnapInterval { get; private set; }

    [field: SerializeField, Header("Characters")] public CharacterConfig[] CharacterConfig { get; private set; }
    [SerializeField] private int numberOfCharacter = 5;
    [field: SerializeField] public float MapZCenter = 0;
    [field: SerializeField] public float GroundRaycastLength = 1f;
    [field: SerializeField] public EnemyCharacter EnemyCharacterPrefab { get; private set; }
    [field: SerializeField] public Material[] ArmourColors { get; private set; }
    [field: SerializeField] public GameObject[] HelmentPrefabs { get; private set; }
    [field: SerializeField] public Material[] Helmet1Colors { get; private set; }
    [field: SerializeField] public Material[] Helmet2Colors { get; private set; }
    [field: SerializeField] public Material[] Helmet3Colors { get; private set; }
    [field: SerializeField] public WeaponConfig[] WeaponConfigs { get; private set; }

    [field: SerializeField, Header("Materials")] public Material placingMaterialValid { get; private set; }
    [field: SerializeField] public Material placingMaterialInvalid { get; private set; }
    
    [field: SerializeField, Header("Layers")] public LayerMask BackgroundLayer;
    [field: SerializeField] public LayerMask GroundLayer;
    [field: SerializeField] public LayerMask EnviromentLayer;
    [field: SerializeField] public LayerMask InteractableLayer;
    [field: SerializeField] public LayerMask CharacterLayer;

    [field: SerializeField, Header("Screen PlayerCharacter Positions")] public Vector3 LevelStartPos;
    [field: SerializeField] public Vector3 LevelStartRot;
    [field: SerializeField] public Vector3 CharacterDesignPos;
    [field: SerializeField] public Vector3 CharacterDesignRot;

    [field: SerializeField, Header("Code Blocks")] public CodeBlock CodeBlockPrefab;

    public bool TestingMode = false;
    public bool isPlacing;

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
            CharacterConfig config = (CharacterConfig)ScriptableObject.CreateInstance("CharacterConfig");
            if (i == 0) config.active = true;
            characterConfigList.Add(config);
        }

        CharacterConfig = characterConfigList.ToArray();
        PlayerCharacter.UpdateCharacter();
    }
}
