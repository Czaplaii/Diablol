using UnityEngine;

public class hp : MonoBehaviour
{
    [SerializeField] CharacterStats staty;
    [SerializeField] GameObject gameover, player;
    [SerializeField] Animator animator;

    int xp = 0;

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
    
    void LvlUp()
    {
        staty.skillpointy(1);
    }
    public void Exp()
    {
        xp += 50;
        if (xp == 100)
        {
            LvlUp();
            xp = 0;
        }
    }
}
