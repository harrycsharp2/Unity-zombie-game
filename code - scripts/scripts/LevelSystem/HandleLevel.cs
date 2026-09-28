using UnityEngine;
using TMPro;
public class HandleLevel : MonoBehaviour
{
    public TMP_Text leveltext;
    public TMP_Text presstext;
    public TMP_Text zombiecounttext;

    public GameObject zombieprefab;

    public Transform spawnp1;
    public Transform spawnp2;
    public Transform spawnp3;
    public Transform spawnp4;
    private Transform spawnlocation;

    private bool inlevel;

    public static int level;
    public static int zombiecount;
    public static int zombiespawnamount = 3;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        zombiespawnamount = 3 * level;
        leveltext.text = $"level: {level}";
        zombiecounttext.text = $"zombies: {zombiecount}";
        if (zombiecount >= 1)
        {
            inlevel = true;
        }
        else if (zombiecount <= 0)
        {
            inlevel = false;
        }
        if (!inlevel)
        {
            presstext.text = "press enter for next level";
        }
        else if (inlevel)
        {
            presstext.text = "";
        }
        else
        {
            presstext.text = "";
        }
        if (Input.GetKey(KeyCode.Return) && !inlevel)
        {
            HandleSpawning();
            level++;
        }
    }
    void HandleSpawning()
    {
        if (!inlevel && zombiecount == 0)
        {
           
            for (int i = 0; i < zombiespawnamount; i++)
            {
                spawnlocation = HandleSpawnpoint();
                UnityEngine.AI.NavMeshHit hit;

                if (UnityEngine.AI.NavMesh.SamplePosition(
                   spawnlocation.position,
                   out hit,
                   10f,
                   UnityEngine.AI.NavMesh.AllAreas))
                {
                    GameObject zombie = Instantiate(
                        zombieprefab,
                        hit.position,
                        spawnlocation.rotation
                    );

                    zombie.SetActive(true);
                }
            }
            return;
        }
    }
    public Transform HandleSpawnpoint()
    {
        int rand = Random.Range(1, 5);
        if (rand == 1)
        {
            return spawnp1;
        }
        else if (rand == 2)
        {
            return spawnp2;
        }
        else if (rand == 3)
        {
            return spawnp3;
        }        
        else if (rand == 4)
        {
            return spawnp4;
        }
        else
        {
            return null;
        }
    }
}
