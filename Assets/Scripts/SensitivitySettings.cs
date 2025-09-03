using UnityEngine;
using UnityEngine.UI;

public class SensitivitySettings : MonoBehaviour
{
    [SerializeField] private CameraLook cameraLook; // CameraLook script ka reference
    [SerializeField] private Slider sensitivitySlider; // UI slider
    [SerializeField] private Text sensitivityText; // Optional: text to show value

    private void Start()
    {
        // Saved sensitivity load karo, default 40 rakho
        float savedSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 40f);

        // CameraLook me apply karo
        cameraLook.Sensitivity = savedSensitivity;

        // Slider aur text update karo
        if (sensitivitySlider != null)
        {
            sensitivitySlider.value = savedSensitivity;
            sensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);
        }

        if (sensitivityText != null)
        {
            sensitivityText.text = savedSensitivity.ToString("F1");
        }
    }

    private void OnSensitivityChanged(float newValue)
    {
        // CameraLook script me new sensitivity apply karo
        cameraLook.Sensitivity = newValue;

        if (sensitivityText != null)
        {
            sensitivityText.text = newValue.ToString("F1");
        }

        // Save kar do taa ke agle launch pe bhi same ho
        PlayerPrefs.SetFloat("MouseSensitivity", newValue);
    }
}
