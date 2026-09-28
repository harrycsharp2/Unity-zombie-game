using UnityEngine;
using TMPro;
public class HandlePackapunch : MonoBehaviour
{
    public TMP_Text costtext;
    

    public Transform player;

    private bool isopened = false;

    private float distance;
    public static float money;

    static string iteminhand;
    static int slotinhand;
    void Start()
    {
        costtext.text = "$3000"; 
    }
    void Update()
    {
        money = HandlePlayer.money;
        distance = Vector3.Distance(transform.position, player.position);
        slotinhand = HandleHotbar.activeSlot;
        if (slotinhand == 0)
        {
            iteminhand = null;
        }
        else if (slotinhand == 1)
        {
            iteminhand = HandleHotbar.slot1;
        }
        else if (slotinhand == 2)
        {
            iteminhand = HandleHotbar.slot2;
        }
    }
    void OnMouseDown()
    {
        if (!isopened && distance <=5 && money >= 3000f)
        {
            if (slotinhand != 0)
            {
                if (iteminhand != null)
                {
                    HandlePlayer.money = HandlePlayer.money - 3000f;
                    isopened = true;
                    if (iteminhand == "pistol")
                    {
                        HandlePistol.magsize = HandlePistol.magsize * 2;
                        HandlePistol.pistoldamage = HandlePistol.pistoldamage * 2;
                        Debug.Log("pack a punched !!!");
                    }
                    else if (iteminhand == "raygun")
                    {
                        HandleRaygun.magsize = HandleRaygun.magsize * 2;
                        HandleRaygun.damage = HandleRaygun.damage * 2;
                        Debug.Log("pack a punched !!!");
                    }
                    Debug.Log("hand is empty");
                }    
            }
            else
            {
                Debug.Log("hand is empty");
            }
        }
        else if (isopened == true)
        {
            Debug.Log("already opened");
        }
        else if (distance >= 6)
        {
            Debug.Log("too far away");
        }
        else if (money <= 2999)
        {
            Debug.Log("Not enough money");
        }
        else
        {
            Debug.Log("error in packanpunch OnMouseDown");
        }
    }
}
