using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxKey(int key)
    {
        slider.maxValue = key;
        slider.value = key;
    }
    public void Setkey(int key)
    {
        slider.value = key;
    }
}
