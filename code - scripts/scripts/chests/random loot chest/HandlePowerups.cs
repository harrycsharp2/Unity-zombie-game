using UnityEngine;

public class HandlePowerups : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void healthincrease()
    {
        HandlePlayer.health = HandlePlayer.health + 50f;
        return;
    }
}
