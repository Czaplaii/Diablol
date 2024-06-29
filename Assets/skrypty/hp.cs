using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hp : MonoBehaviour
{
    [SerializeField] CharacterStats staty;
    [SerializeField] GameObject gameover, player;
    [SerializeField] Animator animator;

    void Start()
    {
        staty.hp = staty.maxhp;

        gameover.SetActive(false);
        animator.enabled = false;
    }

    void Update()
    {
        if (staty.hp < 1)
        {
            player.SetActive(false); //Trun off Player when dead
            gameover.SetActive(true);
            animator.enabled = true;
            Invoke(nameof(ResetPoziomu),3);
        }
    }

    void ResetPoziomu()
    {
        //SceneManager.LoadScene(PlayerPrefs.GetInt("obecna"));
    }
}
