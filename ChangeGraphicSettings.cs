using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeGraphicSettings : MonoBehaviour {

    private string preset;
    public Text presetText;
    public GameObject lowerPresetButton;
    public GameObject higherPresetButton;
    public Dropdown resolutionDropdown;

    // Use this for initialization
    private void OnEnable() {
        preset = QualitySettings.names[QualitySettings.GetQualityLevel()];
        print(preset);
        print(presetText);
        presetText.text = preset;

        if (preset == "Very Low")
        {
            lowerPresetButton.SetActive(false);
        }

        resolutionDropdown.options.Clear();

        for (int x = 0; x < Screen.resolutions.Length; x += 1){
            print(x);
            resolutionDropdown.options.Add(new Dropdown.OptionData(text: Screen.resolutions[x].ToString()));
        }
        resolutionDropdown.value = 9;
        print(resolutionDropdown.value);
	}

    public void LowerPreset()
    {
        QualitySettings.DecreaseLevel();
        preset = QualitySettings.names[QualitySettings.GetQualityLevel()];
        presetText.text = preset;
        if (preset == "Very Low")
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(higherPresetButton);
            lowerPresetButton.SetActive(false);
        }
        else
        {
            lowerPresetButton.SetActive(true);
        }
        higherPresetButton.SetActive(true);
    }

    public void HigherPreset()
    {
        QualitySettings.IncreaseLevel();
        preset = QualitySettings.names[QualitySettings.GetQualityLevel()];
        presetText.text = preset;
        if(preset == "Ultra")
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(lowerPresetButton);
            higherPresetButton.SetActive(false);
        }
        lowerPresetButton.SetActive(true);
    }

    public void ChangeResolution(int option)
    {
        print(option);
        Screen.SetResolution(Screen.resolutions[option].width, Screen.resolutions[option].height, true);
    }
}
