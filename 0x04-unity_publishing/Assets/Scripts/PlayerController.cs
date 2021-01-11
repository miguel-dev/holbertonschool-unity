using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rigidBody;
    private int score;
    public int health;
    public Text scoreText;
    public Text healthText;
    public Text winLoseText;
    public Image winLoseBG;

    // Start is called before the first frame update
    void Start()
    {
        speed = 700f;
        score = 0;
        health = 5;
    }

    void Update()
    {
        if (health == 0)
        {
            winLoseBG.gameObject.SetActive(true);
            winLoseText.text = "Game Over!";
            winLoseText.color = Color.white;
            winLoseBG.color = Color.red;
            StartCoroutine(LoadScene(3));
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rigidBody.AddForce(speed * Time.deltaTime, 0 , 0);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rigidBody.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey("w") || Input.GetKey("up"))
        {
            rigidBody.AddForce(0, 0, speed * Time.deltaTime);
        }
        else if (Input.GetKey("s") || Input.GetKey("down"))
        {
            rigidBody.AddForce(0, 0, -speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            score++;
            SetScoreText();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Trap")
        {
            health--;
            SetHealthText();
        }
        else if (other.gameObject.tag == "Goal")
        {
            winLoseBG.gameObject.SetActive(true);
            winLoseText.text = "You Win!";
            winLoseText.color = Color.black;
            winLoseBG.color = Color.green;
            StartCoroutine(LoadScene(3));
        }
    }

    void SetScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

    void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}