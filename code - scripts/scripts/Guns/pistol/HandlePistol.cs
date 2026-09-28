using UnityEngine;
using TMPro;
public class HandlePistol : MonoBehaviour
{
    public TMP_Text ammotext;

    public GameObject pistol;
    public GameObject bulletprefab;
   
    public Transform bulletspawnpoint;

    public static bool isactive;



    private float ammo = 12f;
    public static float magsize = 12f;
    public static float pistoldamage = 25f;
    void Start()
    {
        isactive = false;
    }
    void Update()
    {
        pistol.SetActive(isactive);
        if (isactive)
        {
            ammotext.text = $"{ammo}";
        }
        if (Input.GetKey(KeyCode.R))
        {
            ammo = magsize;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && isactive && ammo >= 1f)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(
      bulletprefab,
      bulletspawnpoint.position,
      bulletspawnpoint.rotation
       );
        bullet.transform.position = bulletspawnpoint.position;
        HandleBullet bulletscript = bullet.GetComponent<HandleBullet>();
        bulletscript.SetDirection(bulletspawnpoint.forward);
        bullet.SetActive(true);
        ammo--;
        return;
    }
}
