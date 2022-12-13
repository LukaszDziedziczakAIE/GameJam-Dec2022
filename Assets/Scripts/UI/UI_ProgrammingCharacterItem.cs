using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ProgrammingCharacterItem : UI_Base
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Button button;
    [SerializeField] RawImage icon;

    ProgrammingObjectConfig config;

    protected override void Awake()
    {
        base.Awake();
    }

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
        Game.CharacterConfig[Game.HUD.Programing.CurrentlySelected].RemoveCodeBlock(config);
        Game.HUD.Programing.BuildCharacterBlocks();
    }
}
