using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vibrate : MonoBehaviour
{
    private Sprite soundOnImage;
    public Sprite soundOffImage;
    private bool isOn = true;
    public Button button;
    public bool on;


    //public AudioSource audioSource;

    private void Start()
    {
        soundOnImage = button.image.sprite;
        // Check the URL parameter and set the initial state
        string url = Application.absoluteURL;
        Debug.Log("Current URL: " + url);

        if (url.Contains("?v=0") || url.Contains("&v=0"))
        {
            SetVibrateState(false);
        }
        else if (url.Contains("?v=1") || url.Contains("&v=1"))
        {
            SetVibrateState(true);
        }
        else
        {
            // Default state if no parameter is found
            SetVibrateState(true);
        }
    }

    public void ButtonClicked()
    {
        isOn = !isOn;
        SetVibrateState(isOn);
        UpdateURLParameter();
    }

    private void SetVibrateState(bool state)
    {
        Debug.Log("Setting music state to: " + state);

        if (state)
        {
            button.image.sprite = soundOnImage;
            //audioSource.mute = false;
        }
        else
        {
            button.image.sprite = soundOffImage;
           // audioSource.mute = true;
        }
        on = state;
    }

    private void UpdateURLParameter()
    {
        string parameter = isOn ? "1" : "0";
        Debug.Log("Updating URL parameter to: " + parameter);
        Application.ExternalCall("updateURLParameter", "v", parameter);
    }
}
