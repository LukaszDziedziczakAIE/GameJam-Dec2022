using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointSystem : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Slider slider;

    public int points = 200;

    void Start()
    {
        
    }

    public void TakePoints(int remove)
    {
        points -= remove;
        text.text = "Points: " + points;

        int sliderValue = points / 200;
        slider.value = sliderValue;
    }

    public void AddPoints(int add)
    {
        points += add;
        text.text = "Points: " + points;

        int sliderValue = points / 200;
        slider.value = sliderValue;
    }
}
