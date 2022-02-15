using UnityEngine;
using UnityEngine.SceneManagement;
public class moveCharacter : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityForce;
    private Animator playerAnim;
    public ParticleSystem explosion;
    public ParticleSystem dirt;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public bool gameOver = false;
    public bool isOnGround = true;
    private int jumpCount;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityForce;
        this.jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver || Input.GetKeyDown(KeyCode.Space) && this.jumpCount < 2 && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirt.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            this.jumpCount++;
        }
        else if (Input.GetKey(KeyCode.F) && isOnGround && !gameOver)
        {
            playerAnim.speed = 2;
        }
        else if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            GameObject.Find("player").transform.position = new Vector3(10f, 0f, 2.88f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirt.Play();
            this.jumpCount = 0;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            this.jumpCount = 0;
            playerAudio.PlayOneShot(crashSound, 1.0f);
            Debug.Log("Game Over!");
            playerAnim.SetTrigger("Death_b");
            playerAnim.SetInteger("DeathType_int", 1);
            explosion.Play();
            dirt.Stop();
        }
    }
}
