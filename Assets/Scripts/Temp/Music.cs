using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
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

        if (url.Contains("?m=0") || url.Contains("&m=0"))
        {
            SetMusicState(false);
        }
        else if (url.Contains("?m=1") || url.Contains("&m=1"))
        {
            SetMusicState(true);
        }
        else
        {
            // Default state if no parameter is found
            SetMusicState(true);
        }
    }

    public void ButtonClicked()
    {
        isOn = !isOn;
        SetMusicState(isOn);
        UpdateURLParameter();
    }

    private void SetMusicState(bool state)
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
        Application.ExternalCall("updateURLParameter", "m", parameter);
    }
}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Music : MonoBehaviour
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

    }

    public void ButtonClicked()
    {
        if (isOn)
        {

            button.image.sprite = soundOffImage;
            isOn = false;
            audioSource.mute = true;
            on = isOn;
        }

        else
        {
            button.image.sprite = soundOnImage;
            isOn = true;
            audioSource.mute = false;
            on = isOn;
        }
        UpdateURLParameter();
    }

    private void UpdateURLParameter()
    {
        string parameter = isOn ? "1" : "0";
        Application.ExternalCall("updateURLParameter", "m", parameter);
    }
}
*/
