using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI countDownText;
    //create a variable to store the remaining time
    private float remainingTime;
    public MenuController menuController;
    private PlayerController playerController;
    void Start()
    {
        //start the countdown with 30 seconds
        remainingTime = 30;
        playerController = FindObjectOfType<PlayerController>(); // Encontra o PlayerController na cena
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime <= 0)
        {
            //if the remaining time is less than or equal to 0, stop the countdown
            remainingTime = 0;
            //GameOver();
            menuController.TimeFinished();
            playerController.gameObject.SetActive(false);

        }
        else if (playerController.gameObject.activeSelf)
        {
            //decrease the remaining time by 1 second
            remainingTime -= Time.deltaTime;
            // if time remaining is less than 6, set the color to red
            if (remainingTime < 6)
            {
                countDownText.color = Color.red;
            }
            int minutes = (int)remainingTime / 60;
            int seconds = (int)remainingTime % 60;
            countDownText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }   
    }
}
