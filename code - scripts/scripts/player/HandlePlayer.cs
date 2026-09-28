using UnityEngine;
using TMPro;

public class HandlePlayer : MonoBehaviour
{
    public TMP_Text moneytext;
    public TMP_Text healthtext;

    public static float money = 250f;
    public static float health = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneytext.text = $"{money}";
        healthtext.text = $"{health}";

    }
}
