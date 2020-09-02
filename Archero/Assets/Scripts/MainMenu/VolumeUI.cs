using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeUI : BaseMonoBehaviour
{
    [SerializeField]
    private Slider SliderVolume;
    private void OnEnable()
    {
        SliderVolume.value = AudioListener.volume;
    }
    public override void UpdateNormal()
    {
        AudioListener.volume = SliderVolume.value;
    }
}