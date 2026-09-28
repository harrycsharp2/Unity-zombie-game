using UnityEngine;
using TMPro;
public class HandleRaygun : MonoBehaviour
{
    public TMP_Text ammotext;

    public GameObject raygun;
    public GameObject bulletprefab;

    public Transform bulletspawnpoint;

    public bool isactive = false;

    public static float magsize = 5f;
    private static float ammo = magsize;
    public static float damage = 105f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        raygun.SetActive(isactive);
        if (isactive)
        {
            ammotext.text = $"{ammo}";
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ammo = magsize;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && isactive && ammo >= 1)
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
        
        HandleRayBullet bulletscript = bullet.GetComponent<HandleRayBullet>();
        bulletscript.SetDirection(bulletspawnpoint.forward);
        
        bullet.SetActive(true);
        ammo--;
        return;
    }
}
