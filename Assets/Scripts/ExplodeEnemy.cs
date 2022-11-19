using UnityEngine;

public class ExplodeEnemy : MonoBehaviour
{
    public float minForce;
    public float maxForce;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        Explode();
        Destroy(gameObject, 5);
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
