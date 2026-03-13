using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    [SerializeField] private TextMeshProUGUI _sliderText;

    void Start()
    {
        _slider.onValueChanged.AddListener((v) => { 
            _sliderText.text = $"x {v.ToString("0.00")}";
        });
    }
}
