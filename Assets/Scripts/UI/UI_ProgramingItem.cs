using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ProgramingItem : UI_Base
{
    ProgrammingObjectConfig config;

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Button button;
    [SerializeField] RawImage icon;

    private void Start()
    {
        button.onClick.AddListener(OnButtonPress);
    }

    public void Set(ProgrammingObjectConfig config)
    {
        this.config = config;
        text.text = config.ObjectName;
        if (config.Icon != null) icon.texture = config.Icon;
    }

    private void OnButtonPress()
    {
        if (Game.HUD.Programing.CurrentlySelected == 0) return;

        CodeBlock codeBlock = Instantiate(Game.CodeBlockPrefab);
        codeBlock.Set(config);
        codeBlock.Placeable.SaveOriginalMaterials();
        codeBlock.Placeable.SetMaterialsPlacementValid();
    }
}
