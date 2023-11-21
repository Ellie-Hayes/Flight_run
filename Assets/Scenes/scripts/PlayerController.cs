using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    public TextMeshProUGUI timertext;
    public float time;
    public bool playerdead;
    public GameObject gameover;
    public TextMeshProUGUI gameovertext;

    private Renderer rend;
    private Color grey;
    private int coins;
    public TextMeshProUGUI coinText;
    public BackgroundScroller backgroundscroller;
    Animator anim;

    public bool HasHat;
    bool jetpack;
    int gameMode;
    public ParticleSystem jetpackParticles;


    // Start is called before the first frame update
    void Start()
    {
        backgroundscroller = GameObject.FindGameObjectWithTag("Background").GetComponent<BackgroundScroller>();
        anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
        gameover.SetActive(false);

        rend = GetComponent<Renderer>();
        grey = rend.material.color;

        gameMode = PlayerPrefs.GetInt("Gamemode");

        if (gameMode == 1)
        {
            jetpack = true;
        }
        jetpackParticles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (gameMode == 0) { Jump(); }
        else { jetpackMove(); }
        
        CheckIfGrounded();
        Displaytime();

        if (!playerdead)
        {
           time += Time.deltaTime;
        }


        anim.SetBool("Jetpack", jetpack);


    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    void jetpackMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            jetpackParticles.Play();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            jetpackParticles.Stop();
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W)&& isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            gameover.SetActive(true);
            playerdead = true;
            int minutes = Mathf.FloorToInt(time / 60.0f);
            int seconds = Mathf.FloorToInt(time - minutes * 60);
            gameovertext.text = ("Well done! Your time was: ") +string.Format("{0:00}:{1:00}", minutes, seconds);
            Time.timeScale = 0;
        }
        if (other.gameObject.CompareTag("InvulnerabilityPickup"))
        {
            StartCoroutine("Invincible");
            Destroy(other.gameObject);

            if (HasHat)
            {
                HatInvul hat = GetComponentInChildren<HatInvul>();
                hat.StartCoroutine("Invincible");

            }
        }
        if (other.gameObject.CompareTag("SpeedPickup"))
        {
            backgroundscroller.speed -= 2;
            backgroundscroller.difficultycountdown += 2;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("BlockSizePickup"))
        {
            Destroy(other.gameObject);
            backgroundscroller.makeBlocksSmall = true;
            backgroundscroller.StartCoroutine("blockPickup");
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins += 1;
            coinText.text = ("x") + coins.ToString();
            int prefcoins = PlayerPrefs.GetInt("PlayerCoins");
            prefcoins += 1;
            PlayerPrefs.SetInt("PlayerCoins", prefcoins);
            
        }
    }

    void Displaytime()
    {
        int minutes = Mathf.FloorToInt(time / 60.0f);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        
    }

    IEnumerator Invincible()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        rend.material.color = new Color32(85, 85, 85, 255);
        yield return new WaitForSeconds(7f);
        rend.material.color = new Color32(255, 255, 255, 255);

        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(0.5f);
            if (i % 2 == 0) { rend.material.color = new Color32(85, 85, 85, 255); }
            else { rend.material.color = new Color32(255, 255, 255, 255); }
        }

        Physics2D.IgnoreLayerCollision(7, 8, false);
        rend.material.color = new Color32(255, 255, 255, 255);

    }

}