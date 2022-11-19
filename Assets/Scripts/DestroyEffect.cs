using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public float dTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, dTime);
    }
      
}
