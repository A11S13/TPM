using UnityEngine;

public class EnemyExplode : MonoBehaviour
{
    public float minForce;
    public float maxForce;
    public float radius;
    
    void Start()
    {
        Explode();
        Destroy(gameObject, 5); //Destroy fragments after 5s
    }
    public void Explode()
    {
        foreach (Transform t in transform)
        {
            var rb = t.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(Random.Range(minForce, maxForce), transform.position, radius);
            }
        }
    }
}
