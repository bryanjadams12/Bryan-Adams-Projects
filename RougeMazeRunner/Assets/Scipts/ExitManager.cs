using UnityEngine;

public class ExitManager : MonoBehaviour
{
    public GameObject ExitVisual;
    public Collider2D exitCollider;

    public void SetExitActive(bool isActive)
    {
        if (ExitVisual != null)
            ExitVisual.SetActive(isActive);

        if (exitCollider != null)
            exitCollider.enabled = isActive;
    }
}