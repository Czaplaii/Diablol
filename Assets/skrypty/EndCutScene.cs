using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCutScene : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(Delay), 58f);
    }
    void Delay()
    {
        SceneManager.LoadScene("Level by XebiSon");
    }
}
