using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] SoundManagement sound;
    public void PlayGame()
    {
        Screen.SetResolution(1920, 1080, true);
        SoundManagement.SliderVolume = sound.slider.value;
        sound.audioMixer.GetFloat("volume", out SoundManagement.MainVolume);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CREDITS()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
