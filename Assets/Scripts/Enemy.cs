using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyFragments;
    
    public GameObject player;

    private float distance;

    public float timer;
    public int newTargetTime =2;
    public float speed =1;
    public float randomDistance =50;
    public NavMeshAgent nav;
    public Vector3 target;
    public float visionDistance = 30;


    void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= newTargetTime)
        {
            newTarget();
            timer = 0;
        }
    }

    void newTarget()
    {
        distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (distance <= visionDistance)
        {
            target = new Vector3(player.transform.position.x, gameObject.transform.position.y, player.transform.position.z);
            nav.SetDestination(target);
        }
        else
        {
        float myX = gameObject.transform.position.x;
        float myZ = gameObject.transform.position.z;

        float xPos = myX + Random.Range(- randomDistance,  randomDistance);
        float zPos = myZ + Random.Range( - randomDistance,  randomDistance);

        target = new Vector3(xPos, gameObject.transform.position.y, zPos);
        nav.SetDestination(target);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(enemyFragments, other.transform.position, Quaternion.identity);

        }

    }
}
