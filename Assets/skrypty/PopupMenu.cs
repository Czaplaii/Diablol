using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PopupMenu : MonoBehaviour
{
    [SerializeField] GameObject popupmenu, settings_panel;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                popupmenu.SetActive(true);
                
            }
            else
            {
                ResumeGame();
                popupmenu.SetActive(false);
            }
        }
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        popupmenu.SetActive(false);
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
