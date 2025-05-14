using UnityEngine;
using UnityEngine.UI;

public class AudioToggle : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource; // The main menu music AudioSource
    [SerializeField] private GameObject volumeOnButton; // UI button shown when sound is on
    [SerializeField] private GameObject volumeOffButton; // UI button shown when sound is off

    private bool isMuted = false;

    private void Start()
    {
        UpdateUI();
    }

    public void ToggleAudio()
    {
        isMuted = !isMuted;

        musicSource.mute = isMuted;
        UpdateUI();
    }

    private void UpdateUI()
    {
        volumeOnButton.SetActive(!isMuted);
        volumeOffButton.SetActive(isMuted);
    }
}