using UnityEngine;

public class HandleChest : MonoBehaviour
{
    public Transform player;
    public float distance = 0f;

    private string chostenitem;

    private string[] listofpowerups = {"healthincrease"};
    private string[] listofgunperks = {"pistolmagincrease", "pistoldamageboost" };
    private bool raygun = false;

    private bool beenopened = false;
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
        if (distance <= 5 && !beenopened)
        {
            beenopened = true;
            int randomnumber = Random.Range(1, 6);
            if (randomnumber == 1 || randomnumber == 2)
            {
                //powerups
                int rand = Random.Range(0, listofpowerups.Length);
                chostenitem = listofpowerups[rand];
                if (chostenitem == "healthincrease")
                {
                    HandlePowerups.healthincrease();
                }
            }
            else if (randomnumber == 3 || randomnumber == 4)
            {
                //gunperks
                int rand = Random.Range(0, listofgunperks.Length);
                chostenitem = listofgunperks[rand];
                if (chostenitem == "pistolmagincrease")
                {
                    HandleGunPerks.HandlePistolPerk(chostenitem);
                }
                else if (chostenitem == "pistoldamageboost")
                {
                    HandleGunPerks.HandlePistolPerk(chostenitem);
                }
            }
            else if (randomnumber == 5)
            {
                //raygun
            }
        }
    }
}
