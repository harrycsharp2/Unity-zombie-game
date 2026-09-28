using UnityEngine;

public class HandlePistolPickup : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        if (HandlePlayer.money >= 250)
        {
            HandlePlayer.money = HandlePlayer.money - 250;
            HandleHotbar.HandlePickup("pistol");
            
        }
    }
}
