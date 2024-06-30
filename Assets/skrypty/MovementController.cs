using UnityEngine;

public class MovementController : MonoBehaviour
{
    public static MovementController Instance { get; private set; }
    private bool movementEnabled = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool IsMovementEnabled()
    {
        return movementEnabled;
    }

    public void SetMovementEnabled(bool enabled)
    {
        movementEnabled = enabled;
    }
}
