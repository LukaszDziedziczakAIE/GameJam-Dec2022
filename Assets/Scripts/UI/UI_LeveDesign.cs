using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LeveDesign : UI_Base
{
    [SerializeField] Button enviromentButton;
    [SerializeField] Button interactableButton;
    [SerializeField] Button characterButton;
    [SerializeField] RectTransform enviromentTab;
    [SerializeField] RectTransform interactableTab;
    [SerializeField] RectTransform characterTab;

    List<PlaceableObject> enviromentalObject;

    private void Start()
    {
        enviromentButton.onClick.AddListener(OnEnviromentButtonPress);
        interactableButton.onClick.AddListener(OnInteractableButtonPress);
        characterButton.onClick.AddListener(OnCharacterButtonPress);

        enviromentTab.gameObject.SetActive(false);
        interactableTab.gameObject.SetActive(false);
        characterTab.gameObject.SetActive(false);
    }

    public override void Show()
    {
        base.Show();
        OnEnviromentButtonPress();
    }

    private void OnEnviromentButtonPress()
    {
        enviromentTab.gameObject.SetActive(true);
        interactableTab.gameObject.SetActive(false);
        characterTab.gameObject.SetActive(false);
    }

    private void OnInteractableButtonPress()
    {
        enviromentTab.gameObject.SetActive(false);
        interactableTab.gameObject.SetActive(true);
        characterTab.gameObject.SetActive(false);
    }

    private void OnCharacterButtonPress()
    {
        enviromentTab.gameObject.SetActive(false);
        interactableTab.gameObject.SetActive(false);
        characterTab.gameObject.SetActive(true);
    }
}
