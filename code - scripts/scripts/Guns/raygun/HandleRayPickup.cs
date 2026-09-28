using UnityEngine;

public class HandleRayPickup : MonoBehaviour
{
    public Transform player;

    private float distance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
    }
    void OnMouseDown()
    {
        if (distance <= 5)
        {
            HandleHotbar.HandlePickup("raygun");
        }
    }
}
