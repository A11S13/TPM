using UnityEngine;
using UnityEngine.AI;

public class RandomWalk : MonoBehaviour
{
    public float timer;
    public int newTargetTime =2;
    public float speed =1;
    public float randomDistance =50;
    public NavMeshAgent nav;
    public Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
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
        float myX = gameObject.transform.position.x;
        float myZ = gameObject.transform.position.z;

        float xPos = myX + Random.Range(- randomDistance,  randomDistance);
        float zPos = myZ + Random.Range( - randomDistance,  randomDistance);

        target = new Vector3(xPos, gameObject.transform.position.y, zPos);
        nav.SetDestination(target);
    }
}
