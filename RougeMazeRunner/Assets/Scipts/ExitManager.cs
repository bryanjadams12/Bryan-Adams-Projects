using UnityEngine;

public class ExitManager : MonoBehaviour
{
    public GameObject exitVisual; // Assign this in the Inspector

    public void SetExitActive(bool active)
    {
        exitVisual.SetActive(active);
    }
}