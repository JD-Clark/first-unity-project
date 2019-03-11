using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{

    private Vector2 targetPos;
    public float yIncrement = 4;

    public float speed;

    public float maxHeight;
    public float minHeight;

    public int health = 3;
    public Text shipStatus;

    public GameObject effect;
    public GameObject gameOver;


    private void Update()
    {
        
        if (health <= 0)
        {
            gameOver.SetActive(true);
            Destroy(gameObject);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + yIncrement);
            transform.position = targetPos;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - yIncrement);
            transform.position = targetPos;
        }

        if (health == 3)
        {
            shipStatus.text = "Status: Normal";
        }
        else if (health == 2)
        {
            shipStatus.text = "Status: Damaged";
        }
        else
            shipStatus.text = "Status: Critical!";
    }

  
    void OnTriggerEnter2D(Collider2D obstacle)
    {
       if (obstacle.CompareTag("Asteroid"))
        {
         Instantiate(effect, transform.position, Quaternion.identity);
        }
    }

}
