using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speed;

    public GameObject effect;

    public void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if(player.CompareTag("Player"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            
            player.GetComponent<Player>().health -= damage;
            Debug.Log(player.GetComponent<Player>().health);
            Destroy(gameObject);
        }
    }
}
