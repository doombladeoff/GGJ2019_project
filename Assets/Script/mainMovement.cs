using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class mainMovement : MonoBehaviour {

    public GameObject VSP, AVSP, TSSP, TXT, Player;
    public GameObject video;
    public float timeLeft = 1.0f;
    bool controler = false;

    public int points = 0;

    Rigidbody2D rb;

    public float maxspeed = 5f; 
    private bool isFacingRight = true;
    public float jumpForce = 200f;

    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public bool grounded = false;
    public LayerMask whatIsGround;

    public GameObject myPC;


    public AudioClip PC, Virus;
    AudioSource audioData;

    [SerializeField]
    SpriteRenderer spriteRenderer;
    public Sprite VirusFile;

    void Start()
    {
        Time.timeScale = 1.0f;
        audioData = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        VSP.SetActive(false);
        AVSP.SetActive(false);
        TSSP.SetActive(false);
        TXT.SetActive(false);
    }

    void FixedUpdate()
    {
        if (controler == true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveHorizontal * maxspeed, rb.velocity.y);

            if (moveHorizontal > 0 && !isFacingRight)
                Flip();
            else if (moveHorizontal < 0 && isFacingRight)
                Flip();


            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        }
    }

    void Update()
    {
        if (grounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            if (points == 20)
            {
                myPC.SetActive(true);
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            if (points == 50)
            {
                myPC.SetActive(true);
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
        {
            if (points == 25)
            {
                myPC.SetActive(true);
            }
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            VSP.SetActive(true);
            AVSP.SetActive(true);
            TSSP.SetActive(true);
            TXT.SetActive(true);
            controler = true;
        }

    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;             
        Vector3 theScale = transform.localScale;    
        theScale.x *= -1;                             
        transform.localScale = theScale;            
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "instagram")
        {
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.75f;
            maxspeed = 25f;
            Destroy(collision.gameObject);
            Invoke("timeScale", 5);
        }

        if (collision.gameObject.tag == "twitter")
        {
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.75f;
            maxspeed = 25f;
            Destroy(collision.gameObject);
            Invoke("timeScale", 5);
        }

        if (collision.gameObject.tag == "antivirus")
        {
            Destroy(collision.gameObject);
            points++;
            score.antivirusPoints = points;
        }

        if (collision.gameObject.tag == "youtube")
        {
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.75f;
            maxspeed = 25f;
            Destroy(collision.gameObject);
            Invoke("timeScale", 5);
        }

        if (collision.gameObject.tag == "myPC")
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
            {
                SceneManager.LoadScene(2);
                Debug.Log("FINALLY!!!");
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
            {
                SceneManager.LoadScene(3);
                Debug.Log("FINALLY!!!");
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
            {
                SceneManager.LoadScene(4);
                Debug.Log("FINALLY!!!");
            }
        }

    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "virus")
        {
            spriteRenderer.sprite = VirusFile;
            transform.localRotation = Quaternion.Euler(0, 0, 90);
            audioData.PlayOneShot(PC, 0.7f);

            //Invoke("RestartLevel", 0.7f);
        }
    }

    void timeScale()
    {
        Time.timeScale = 1.0f;
        maxspeed = 10f;
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
