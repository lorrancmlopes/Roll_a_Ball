using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public GameObject endPanel;
    private PlayerController playerController;
    private AudioSource winSound;
    private AudioSource diedSound;
    private AudioSource clickSound;

    // Start is called before the first frame update
    void Start()
    {
        endPanel.SetActive(false);
        playerController = FindObjectOfType<PlayerController>(); // Encontra o PlayerController na cena
        // get the win and died sounds 
        AudioSource[] audios = GetComponents<AudioSource>();
        winSound = audios[0];
        diedSound = audios[1];
        // get the audio from the click sound from Canvas/endPanel
        clickSound = endPanel.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TransitionScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        clickSound.Play();
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    

    public void LoseGame()
    {
        endPanel.SetActive(true);
        playerController.gameObject.SetActive(false);
        diedSound.Play();
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Game over...";

    }

    public void WinGame()
    {
        endPanel.SetActive(true);
        playerController.gameObject.SetActive(false);
        winSound.Play();
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You win!";
    }

    public void TimeFinished()
    {
        endPanel.SetActive(true);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Time's up!";
    }
}
