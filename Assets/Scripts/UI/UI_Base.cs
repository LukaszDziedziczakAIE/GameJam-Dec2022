using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Base : MonoBehaviour
{
    [SerializeField] protected GameController Game;

    protected virtual void Awake()
    {
        if (Game == null) Game = FindObjectOfType<GameController>();
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
