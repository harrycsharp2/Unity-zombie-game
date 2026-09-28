using UnityEngine;
using TMPro;
public class HandleZombie : MonoBehaviour
{
    public TMP_Text zombiehealthtext;

    public float damage = 20;
    public float health = 100;
    void Start()
    {
        HandleLevel.zombiecount++;
        damage = damage + HandleLevel.level;
        health = health + HandleLevel.level;
    }

    // Update is called once per frame
    void Update()
    {
        zombiehealthtext.text = $"{health}";
        if (health <= 0)
        {
            HandlePlayer.money = HandlePlayer.money + 100f;
            HandleLevel.zombiecount--;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            HandlePlayer.health = HandlePlayer.health - damage;
        }
        if (collision.gameObject.CompareTag("pistolbullet"))
        {
            health = health - HandlePistol.pistoldamage;
            Destroy(collision.gameObject);
        }
    }
}
