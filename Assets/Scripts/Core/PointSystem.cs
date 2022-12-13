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

    //public int points;
    public int programmingPoints;
    public int artPoints;
    public int designPoints;

    [HideInInspector] public float originalPoints;


    private void Start()
    {
        originalPoints = points;
    }

    public float points
    {
        get
        {
            return programmingPoints + artPoints + designPoints;
        }
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

    public void AddProgrammingPoints(int add)
    {
        programmingPoints += add;
        UpdateScoreText();
    }

    public void RemoveProgrammingPoints(int remove)
    {
        programmingPoints -= remove;
        UpdateScoreText();
    }

    public void AddArtPoints(int add)
    {
        artPoints += add;
        UpdateScoreText();
    }

    public void RemoveArtPoints(int remove)
    {
        artPoints -= remove;
        UpdateScoreText();
    }

    public void AddDesignPoints(int add)
    {
        designPoints += add;
        UpdateScoreText();
    }

    public void RemoveDesignPoints(int remove)
    {
        designPoints -= remove;
        UpdateScoreText();
    }

    public bool CanBuy(int price)
    {
        return points - price >= 0;
    }

    public void UpdateScoreText()
    {
        text.text = "Points: " + points;

        float sliderValue = (float)points / originalPoints;
        slider.value = sliderValue;
    }
}
