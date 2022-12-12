using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Programing : UI_Base
{
    [SerializeField] Button enemyButton1;
    [SerializeField] Button enemyButton2;
    [SerializeField] Button enemyButton3;
    [SerializeField] Button enemyButton4;
    [SerializeField] RectTransform Content;
    [Header("Color Block")]
    [SerializeField] ColorBlock selectedColor;

    ColorBlock originalColor;

    public int currentlySelected { get; private set; }

    ProgrammingObjectConfig[] programmingObjectConfigs;

    [Header("Prefab")]
    [SerializeField] UI_ProgramingItem programingItemPrefab;
    List<UI_ProgramingItem> items = new List<UI_ProgramingItem>();

    private void Start()
    {
        programmingObjectConfigs = Resources.LoadAll<ProgrammingObjectConfig>("ProgrammingBlocks/");

        enemyButton1.onClick.AddListener(OnEnemyButton1Press);
        enemyButton2.onClick.AddListener(OnEnemyButton2Press);
        enemyButton3.onClick.AddListener(OnEnemyButton3Press);
        enemyButton4.onClick.AddListener(OnEnemyButton4Press);
    }

    public override void Show()
    {
        base.Show();
        enemyButton1.gameObject.gameObject.SetActive(Game.CharacterConfig[1].active);
        enemyButton2.gameObject.gameObject.SetActive(Game.CharacterConfig[2].active);
        enemyButton3.gameObject.gameObject.SetActive(Game.CharacterConfig[3].active);
        enemyButton4.gameObject.gameObject.SetActive(Game.CharacterConfig[4].active);
        BuildBlockList();
    }

    private void BuildBlockList()
    {
        if (programmingObjectConfigs.Length > 0 && programingItemPrefab != null && items.Count == 0)
        {
            foreach (ProgrammingObjectConfig config in programmingObjectConfigs)
            {
                UI_ProgramingItem item = Instantiate(programingItemPrefab, Content);
                item.Set(config);
                items.Add(item);
            }
        }
    }

    private void OnEnemyButton1Press()
    {
        currentlySelected = 1;
        originalColor = enemyButton1.colors;
        enemyButton1.colors = selectedColor;
        enemyButton2.colors = originalColor;
        enemyButton3.colors = originalColor;
        enemyButton4.colors = originalColor;
        Game.BlockDetector.RebuildBlocks();
    }

    private void OnEnemyButton2Press()
    {
        currentlySelected = 2;
        originalColor = enemyButton2.colors;
        enemyButton1.colors = originalColor;
        enemyButton2.colors = selectedColor;
        enemyButton3.colors = originalColor;
        enemyButton4.colors = originalColor;
        Game.BlockDetector.RebuildBlocks();
    }

    private void OnEnemyButton3Press()
    {
        currentlySelected = 3;
        originalColor = enemyButton3.colors;
        enemyButton1.colors = originalColor;
        enemyButton2.colors = originalColor;
        enemyButton3.colors = selectedColor;
        enemyButton4.colors = originalColor;
        Game.BlockDetector.RebuildBlocks();
    }

    private void OnEnemyButton4Press()
    {
        currentlySelected = 4;
        originalColor = enemyButton4.colors;
        enemyButton1.colors = originalColor;
        enemyButton2.colors = originalColor;
        enemyButton3.colors = originalColor;
        enemyButton4.colors = selectedColor;
        Game.BlockDetector.RebuildBlocks();
    }
}
