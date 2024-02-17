using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public SpriteRenderer sR;
    public Rigidbody2D rb;
    [SerializeField] public float jumpHeight;
    public string currentColor;
    public float score;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        RandomColor(3);
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

    public void RandomColor(int nValue)
    {
        int i = Random.Range(0, nValue);
        switch (i)
        {
            case 0:
                currentColor = "Red";
                sR.color = new Color(255, 0, 0);
                break;
            case 1:
                currentColor = "Green";
                sR.color = new Color(0, 255, 0);
                break;
            case 2:
                currentColor = "Blue";
                sR.color = new Color(0, 0, 255);
                break;
            case 3:
                currentColor = "Yellow";
                sR.color = new Color(255, 255, 0);
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        if (other.gameObject.tag == "changeColor")
        {
            changeColor changeColorScript = other.gameObject.GetComponent<changeColor>();
            int nValue = changeColorScript.getN();
            RandomColor(nValue);
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
