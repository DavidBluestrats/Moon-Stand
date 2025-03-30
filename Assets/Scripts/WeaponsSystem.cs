using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsSystem : MonoBehaviour
{
    [SerializeField] ParticleSystem[] lasers;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        shootLasers();
    }

    void shootLasers()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            setLasersActive(true);
        }
        else
        {
            setLasersActive(false);
        }
    }

    
    void setLasersActive(bool isActive)
    {
        foreach (ParticleSystem laser in lasers)
        {
            var emissionModule = laser.emission;
            emissionModule.enabled = isActive;
        }
    }
}
