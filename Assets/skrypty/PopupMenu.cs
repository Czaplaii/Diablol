using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PopupMenu : MonoBehaviour
{
    [SerializeField] GameObject pauza, settings_panel;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauza.SetActive(true);
                
            }
            else
            {
                ResumeGame();
                pauza.SetActive(false);
            }
        }
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauza.SetActive(false);
    }

    public void OpenSettings()
    {
        settings_panel.SetActive(true);
    }
    public void CloseSettings()
    {
        settings_panel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
