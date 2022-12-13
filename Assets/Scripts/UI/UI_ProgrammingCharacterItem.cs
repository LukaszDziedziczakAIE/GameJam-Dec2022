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

    public void Set(ProgrammingObjectConfig config)
    {
        this.config = config;
        text.text = config.ObjectName;
        if (config.Icon != null) icon.texture = config.Icon;
    }
}
