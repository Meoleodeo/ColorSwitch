using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public SpriteRenderer sR;
    private Rigidbody2D rb;
    [SerializeField] public float jumpHeight;
    public string currentColor;
    public float score;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        RandomColor();
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
            scoreText.text = "" + score;
        }
    }

    private void RandomColor()
    {
        int i = Random.Range(0, 3);
        switch (i)
        {
            case 0:
                currentColor = "Red";
                sR.color = new Color(255, 0, 0);
                break;
            case 1:
                currentColor = "Yellow";
                sR.color = new Color(255, 255, 0);
                break;
            case 2:
                currentColor = "Blue";
                sR.color = new Color(0, 0, 255);
                break;
            case 3:
                currentColor = "Green";
                sR.color = new Color(0, 255, 0);
                break;
        }
    }

    private void jump()
    {
        rb.velocity = Vector2.up * jumpHeight;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            jump();
        }

        if (other.gameObject.tag == "changeColor")
        {
            RandomColor();
        }
        if (other.gameObject.tag == "StarPoint")
        {
            score += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != currentColor)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
