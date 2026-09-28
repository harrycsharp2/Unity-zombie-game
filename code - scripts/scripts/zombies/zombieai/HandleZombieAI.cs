using UnityEngine;

public class HandleZombieAI : MonoBehaviour
{
    public Transform player;
    public UnityEngine.AI.NavMeshAgent agent;
    private bool istouching;



    void Start()
    {

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("player");

            if (playerObject != null)
                player = playerObject.transform;
        }

        if (player != null && agent.isOnNavMesh && istouching == false)
        {
            agent.SetDestination(player.position);
        }
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "player")
        {
            istouching = true;
            agent.isStopped = true;

        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "player")
        {
            istouching = false;
            agent.isStopped = false;
        }
    }
}
