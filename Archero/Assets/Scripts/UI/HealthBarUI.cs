using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : BaseMonoBehaviour
{
    [SerializeField] protected Slider sliderUI;
    [SerializeField] protected Image fillSliderUI;
    protected Color m_FullHealthColor = Color.green;
    protected Color m_ZeroHealthColor = Color.red;
    protected Quaternion startingRotation;

    public override void Awake()
    {
        base.Awake();
        startingRotation = transform.rotation;
    }

    public override void UpdateNormal()
    {
        transform.rotation = startingRotation;
    }

    public void SetHealthUI(float healthPercent)
    {
        // Set the slider's value appropriately.
        sliderUI.value = healthPercent;
        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        //NOTE
        fillSliderUI.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, healthPercent);
    }
}
