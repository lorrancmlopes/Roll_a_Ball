using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public GameObject endPanel;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        endPanel.SetActive(false);
        playerController = FindObjectOfType<PlayerController>(); // Encontra o PlayerController na cena
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
        Application.Quit();
    }

    public void LoseGame()
    {
        endPanel.SetActive(true);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Game over...";

    }

    public void WinGame()
    {
        endPanel.SetActive(true);
        playerController.gameObject.SetActive(false);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You win!";
    }

    public void TimeFinished()
    {
        endPanel.SetActive(true);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Time's up!";
    }
}
