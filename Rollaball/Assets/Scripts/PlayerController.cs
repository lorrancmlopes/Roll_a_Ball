using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    //public GameObject winTextObject;
    public Transform respawnPoint;
    public MenuController menuController;
    private AudioSource pop;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        pop = GetComponent<AudioSource>();
        
        SetCountText();
        //winTextObject.SetActive(false);
    }

    //reference: 
    private void Update()
    {
        if (transform.position.y < -10)
        {
            Respawn();
        }
    }

    void OnMove(InputValue movementValue)
    {
       Vector2 movementVector = movementValue.Get<Vector2>();

       movementX = movementVector.x;
       movementY = movementVector.y;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            pop.Play();
            other.gameObject.SetActive(false);
            count = count + 1;
            
            SetCountText();
            
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            //winTextObject.SetActive(true);
            pop.Play();
            menuController.WinGame();
        }
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        
        rb.AddForce(movement * speed);

    }

    


    //reference: 
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            //Eespawn();
            EndGame();
        }
    }

    void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        transform.position = respawnPoint.position;
    }

    void EndGame()
    {
        menuController.LoseGame();
        gameObject.SetActive(false);
    }


    // end of reference
}
