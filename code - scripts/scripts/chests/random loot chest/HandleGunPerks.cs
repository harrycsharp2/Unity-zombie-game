using UnityEngine;

public class HandleGunPerks : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void HandlePistolPerk(string perkName)
    {
        if (perkName == "pistolmagincrease")
        {
            HandlePistol.magsize = HandlePistol.magsize + 5f;
            return;
        }
        else if (perkName == "pistoldamageboost")
        {
            HandlePistol.pistoldamage = HandlePistol.pistoldamage + 7f;
            return;
        }
    }
}
