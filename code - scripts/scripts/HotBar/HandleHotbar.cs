using UnityEngine;
using TMPro;

public class HandleHotbar : MonoBehaviour
{
    public static string slot1 = null;
    public static string slot2 = null;

    public static int activeSlot = 0; // 0 = nothing, 1 = slot 1, 2 = slot 2

    public TMP_Text slot2text;
    public TMP_Text slot1text;

    void Update()
    {
        slot2text.text = $"2. {slot2}";
        slot1text.text = $"1. {slot1}";

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchSlot(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchSlot(2);
        }
    }
    void SwitchSlot(int newSlot)
    {
        if (activeSlot == newSlot)
        {
            DeactivateSlot(newSlot);
            activeSlot = 0;
            return;
        }
        if (activeSlot != 0)
        {
            DeactivateSlot(activeSlot);
        }
        activeSlot = newSlot;
        ActivateSlot(newSlot);
    }

    void ActivateSlot(int slot)
    {
        string item = slot == 1 ? slot1 : slot2;

        if (item == null)
            return;

        if (item == "pistol")
        {
            HandlePistol.isactive = true;
        }
    }

    void DeactivateSlot(int slot)
    {
        string item = slot == 1 ? slot1 : slot2;

        if (item == null)
            return;

        if (item == "pistol")
        {
            HandlePistol.isactive = false;
        }
    }

    public static void HandlePickup(string item)
    {
        if (slot1 == null)
        {
            slot1 = item;
        }
        else if (slot2 == null)
        {
            slot2 = item;
        }
        else
        {
            Debug.Log("hotbar full");
        }
    }

    public static void HandleDrop(string item)
    {
        if (slot1 == item)
        {
            slot1 = null;

            if (activeSlot == 1)
            {
                activeSlot = 0;
                HandlePistol.isactive = false;
            }
        }
        else if (slot2 == item)
        {
            slot2 = null;

            if (activeSlot == 2)
            {
                activeSlot = 0;
                HandlePistol.isactive = false;
            }
        }
    }
}