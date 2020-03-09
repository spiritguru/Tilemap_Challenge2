using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerScript : MonoBehaviour

{

    public float speed;                //Floating point variable to store the player's movement speed.
    public Text countText;            //Store a reference to the UI Text component which will display the number of pickups collected.
    public Text winText;            //Store a reference to the UI Text component which will display the 'You win' message.
    public Text livesText;

    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private int count;                //Integer to store the number of pickups collected so far.
    private int lives;



    public AudioSource musicsource;
    public AudioClip win;

    Animator anim;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        lives = 3;
        SetCountText();

        anim = GetComponent<Animator>();
    }
   

        void FixedUpdate()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb2d.AddForce(movement * speed);


            if (Input.GetKeyDown(KeyCode.A))
            {
                anim.SetInteger("State", 1);

            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                anim.SetInteger("State", 0);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                anim.SetInteger("State", 1);

            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                anim.SetInteger("State", 0);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                anim.SetInteger("State", 1);

            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetInteger("State", 0);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                anim.SetInteger("State", 1);

            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                anim.SetInteger("State", 0);
            }
        }




        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Coin"))
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                SetCountText();
            }
            else if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.SetActive(false);
                lives = lives - 1;
                SetCountText();
            }

           

        }




    void SetCountText()
    {

        countText.text = "Score: " + count.ToString();
        if (count == 4)
        {
            transform.position = new Vector2(50.0f, 50.0f);
            lives = 3;
        }

        {
            if (count >= 8)

            {
                winText.text = "You win game!" + "\n" + "Game created by Ramon Vega!";

                musicsource.Stop();
                musicsource.clip = win;
                musicsource.Play();

            }
        }


        {
            livesText.text = "Lives: " + lives.ToString();
            if (lives <= 0)


            {

                winText.text = "You lost game!" + "\n" + "Game created by Ramon Vega!";
            }

        
            
        } }
}