
using UnityEngine;

public class ParentDestroyVFXs : MonoBehaviour
{
    float timeTillDestroy = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeTillDestroy);
    }

  
}
