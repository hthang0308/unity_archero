using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : BaseMonoBehaviour
{
    [SerializeField] protected Slider sliderUI;
    [SerializeField] protected Image fillSliderUI;
    [SerializeField] protected TextMeshProUGUI hpText;
    protected Color m_FullHealthColor = Color.green;
    protected Color m_ZeroHealthColor = Color.red;
    protected Quaternion startingRotation;
    [SerializeField] protected Transform parent;
    [SerializeField] protected Vector3 offset = new Vector3(0, 1, -1);

    float timeCount = 0;

    public override void Awake()
    {
        base.Awake();
        startingRotation = transform.rotation;
        hpText.text = "";
    }

    public override void UpdateLate()
    {
        transform.SetPositionAndRotation(parent.position + offset, startingRotation);
    }
    public override void UpdateNormal()
    {
        if (timeCount<0.5)
        {
            timeCount += Time.deltaTime;
            if (timeCount > 0.25)
                hpText.text = "";
        }
    }
    public void SetHealthUI(float healthPercent, float damageTaken)
    {
        // Set the slider's value appropriately.
        sliderUI.value = healthPercent*100;

        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        //NOTE
        fillSliderUI.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, healthPercent);
        if (damageTaken>=5)
        {
            hpText.text = Math.Round(damageTaken).ToString();
            timeCount = 0;
        }
            
    }
}
