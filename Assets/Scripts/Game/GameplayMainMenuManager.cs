using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayMainMenuManager : MonoBehaviour
{
    

    [SerializeField]
    private Sprite _activeSoundSprite, _inactiveSoundSprite;

    private void Start()
    {
        bool sound = (PlayerPrefs.HasKey(Constants.DATA.SETTINGS_SOUND) ?
           PlayerPrefs.GetInt(Constants.DATA.SETTINGS_SOUND) : 1) == 1;
        //_soundImage.sprite = sound ? _activeSoundSprite : _inactiveSoundSprite;

        AudioManager.Instance.AddButtonSound();
    }

    public void ClickedPlay()
    {
        SceneManager.LoadScene(Constants.DATA.GAMEPLAY_SCENE);
    }

    public void ClickedQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void ToggleSound()
    {
        bool sound = (PlayerPrefs.HasKey(Constants.DATA.SETTINGS_SOUND) ? PlayerPrefs.GetInt(Constants.DATA.SETTINGS_SOUND)
             : 1) == 1;
        sound = !sound;
        PlayerPrefs.SetInt(Constants.DATA.SETTINGS_SOUND, sound ? 1 : 0);
       // _soundImage.sprite = sound ? _activeSoundSprite : _inactiveSoundSprite;
        AudioManager.Instance.ToggleSound();
    }
}
