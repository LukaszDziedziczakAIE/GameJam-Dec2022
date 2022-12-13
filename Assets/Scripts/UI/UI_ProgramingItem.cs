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
        int current = Game.HUD.Programing.CurrentlySelected;
        if (current == 0) return;

        Game.CharacterConfig[current].AddCodeBlock(config);
    }
}
