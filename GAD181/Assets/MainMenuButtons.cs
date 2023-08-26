using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;  // TextMesh Pro namespace

public class MainMenuButtons : MonoBehaviour
{
    public TextMeshProUGUI startTutorialButton;  // Button to go to tutorial
    public Slider volumeSlider;  // Slider to adjust volume
    public string tutorialSceneName;  // Name of the tutorial scene set in the inspector

    private void Start()
    {
        // Add an onClick listener to the button
        startTutorialButton.GetComponent<Button>().onClick.AddListener(GoToTutorial);

        // Set the initial volume based on slider's value
        AudioListener.volume = volumeSlider.value;

        // Add listener to the slider for volume changes
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    void GoToTutorial()
    {
        if (!string.IsNullOrEmpty(tutorialSceneName))
        {
            SceneManager.LoadScene(tutorialSceneName);
        }
        else
        {
            Debug.LogWarning("Tutorial scene name not set in the inspector!");
        }
    }

    void ChangeVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
