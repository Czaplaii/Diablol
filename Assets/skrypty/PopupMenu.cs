using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PopupMenu : MonoBehaviour
{
    public GameObject popupmenu;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                popupmenu.SetActive(true);
                
            }
            else
            {
                ResumeGame();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        popupmenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
