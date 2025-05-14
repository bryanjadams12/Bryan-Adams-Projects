using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void PlayGame()
    {
        // Load the game scene
        SceneManager.LoadSceneAsync(1);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void QuitGame()
    {
        Debug.Log("Quitting Game"); // This shows in Console during testing
        Application.Quit();             // This only works in a built game
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
