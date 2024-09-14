using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class ToggleSetting : MonoBehaviour
{
    [SerializeField]
    private TMP_Text dispText;

    [SerializeField]
    private Slider slider;

    void Start()
    {
//        slider.value = float.Parse(dispText.text);
    }

    public void ChangeValue()
    {
        if (slider.value == 0)
        {
            dispText.text = "OFF";
        }
        else
        {
            dispText.text = "ON";
        }
    }

    public void tapButton()
    {
        if (slider.value == 0)
        {
            slider.value = 1;
        }
        else
        {
            slider.value = 0;
        }
        
    }
}
