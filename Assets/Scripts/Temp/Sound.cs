using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    private Sprite soundOnImage;
    public Sprite soundOffImage;
    private bool isOn = true;
    public Button button;
    public bool on;


    public AudioSource audioSource;

    private void Start()
    {
        soundOnImage = button.image.sprite;
        // Check the URL parameter and set the initial state
        string url = Application.absoluteURL;
        Debug.Log("Current URL: " + url);

        if (url.Contains("?s=0") || url.Contains("&s=0"))
        {
            SetSoundState(false);
        }
        else if (url.Contains("?s=1") || url.Contains("&s=1"))
        {
            SetSoundState(true);
        }
        else
        {
            // Default state if no parameter is found
            SetSoundState(true);
        }
    }

    public void ButtonClicked()
    {
        isOn = !isOn;
        SetSoundState(isOn);
        UpdateURLParameter();
    }

    private void SetSoundState(bool state)
    {
        Debug.Log("Setting music state to: " + state);

        if (state)
        {
            button.image.sprite = soundOnImage;
            audioSource.mute = false;
        }
        else
        {
            button.image.sprite = soundOffImage;
            audioSource.mute = true;
        }
        on = state;
    }

    private void UpdateURLParameter()
    {
        string parameter = isOn ? "1" : "0";
        Debug.Log("Updating URL parameter to: " + parameter);
        Application.ExternalCall("updateURLParameter", "s", parameter);
    }
}
