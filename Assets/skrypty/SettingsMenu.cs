using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
public class SettingsMenu : MonoBehaviour
{
    private bool active = false;

    public void ChangeLocale(int localeID)
    {
        if (active)
        {
            return;
        }
        StartCoroutine(SetLocale(localeID));
    }
    IEnumerator SetLocale(int _localeID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        PlayerPrefs.SetInt("LocaleKey", _localeID);
        active = false;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    private void Start()
    {
        int ID = PlayerPrefs.GetInt("LocalKey", 0);
        ChangeLocale(ID);
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
