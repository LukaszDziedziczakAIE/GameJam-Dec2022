using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointSystem : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Slider slider;
    public Image sliderFill;

    public Color[] colors;

    public int points;

    private float originalPoints;


    private void Start()
    {
        originalPoints = points;
    }

    private void Update()
    {
        if(colors != null)
        {
            if(colors.Length >= 3)
            {
                if (slider.value >= 0.75) sliderFill.color = colors[0];
                else if (slider.value >= 0.5 && slider.value < 0.75) sliderFill.color = colors[1];
                else if (slider.value >= 0.25 && slider.value < 0.50) sliderFill.color = colors[2];
                else if (slider.value < 0.25) sliderFill.color = colors[3];
            }
        }
    }

    public void TakePoints(int remove)
    {
        points -= remove;
        text.text = "Points: " + points;

        float sliderValue = (float)points / originalPoints;
        slider.value = sliderValue;
    }

    public void AddPoints(int add)
    {
        points += add;
        text.text = "Points: " + points;

        float sliderValue = (float)points / originalPoints;
        slider.value = sliderValue;
    }

    public bool CanBuy(int price)
    {
        return points - price >= 0;
    }
}
