using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    public Canvas MainMenuCanvas;
    public Canvas OptionsCanvas;

    public Dropdown carSizeDropdown;
    public Dropdown frogSizeDropdown;
    public Slider initialCarSpawnSpeedSlider;
    public Slider initialCarSpeedSlider;
    public Toggle musicToggle;

    public void StartGame()
    {
        Score.UpdateWins(0, true);
        Score.UpdateFails(0, true);
        Score.UpdateHops(0, true);
        SceneManager.LoadScene("HighScores");
    }

    public void ShowMainMenu()
    {
        SaveOptions();
        OptionsCanvas.gameObject.SetActive(false);
        MainMenuCanvas.gameObject.SetActive(true);
    }

    public void ShowOptions()
    {
        LoadOptions();
        MainMenuCanvas.gameObject.SetActive(false);
        OptionsCanvas.gameObject.SetActive(true);
    }

    private void LoadOptions()
    {
        GameDataManager.LoadGameOptions();

        carSizeDropdown.value = GameDataManager.carSize - 1;
        frogSizeDropdown.value = GameDataManager.frogSize - 1;
        initialCarSpawnSpeedSlider.value = GameDataManager.initialCarSpawnSpeed;
        initialCarSpeedSlider.value = GameDataManager.initialCarSpeed;
        musicToggle.isOn = GameDataManager.musicEnabled;
    }

    private void SaveOptions()
    {
        GameDataManager.carSize = (int)carSizeDropdown.value + 1;
        GameDataManager.frogSize = (int)frogSizeDropdown.value + 1;
        GameDataManager.initialCarSpawnSpeed = (int)initialCarSpawnSpeedSlider.value;
        GameDataManager.initialCarSpeed = (int)initialCarSpeedSlider.value;
        GameDataManager.musicEnabled = musicToggle.isOn;

        GameDataManager.SaveGameOptions();
    }
}
