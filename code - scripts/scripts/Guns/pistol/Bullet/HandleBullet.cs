using UnityEngine;

public class HandleBullet : MonoBehaviour
{
    public float speed = 100f;

    private Vector3 direction;
    private float timer = 5f;
    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
       
        
    }
}