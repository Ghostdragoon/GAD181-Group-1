using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider brightnessSlider;
    public float defaultBrightness = 1f;

    private void Start()
    {
        // Set the brightness to the default
        SetBrightness(defaultBrightness);

        // Set the slider's value to the current brightness
        brightnessSlider.value = defaultBrightness;
    }

    public void SetBrightness(float brightness)
    {
        RenderSettings.ambientLight = new Color(brightness, brightness, brightness);
    }

    public void OnBrightnessSliderChanged(float value)
    {
        Debug.Log("Brightness value: " + value);
        // other codes
    }
}

