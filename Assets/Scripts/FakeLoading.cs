using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FakeLoading : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loadingText;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject startButton;
    [SerializeField] private float sliderSpeed = 0.2f;

    float sliderValue;

    LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

        sliderValue = 0;
    }

    private void Update()
    {
        sliderValue += sliderSpeed * Time.deltaTime;

        slider.value = sliderValue;

        if (sliderValue >= 1f)
        {
            loadingText.gameObject.SetActive(false);
            slider.gameObject.SetActive(false);
            startButton.SetActive(true);
        }
    }
}
