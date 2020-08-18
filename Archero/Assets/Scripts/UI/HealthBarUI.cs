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
    [SerializeField] protected Transform parent;
    [SerializeField] protected Vector3 offset = new Vector3(0, 1, -1);

    public override void Awake()
    {
        base.Awake();
        startingRotation = transform.rotation;
    }

    public override void UpdateLate()
    {
        transform.position = parent.position + offset;
        transform.rotation = startingRotation;
    }

    public void SetHealthUI(float healthPercent)
    {
        // Set the slider's value appropriately.
        sliderUI.value = healthPercent*100;

        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        //NOTE
        fillSliderUI.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, healthPercent);
    }
}
