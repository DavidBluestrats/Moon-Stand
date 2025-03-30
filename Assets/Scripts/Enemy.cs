using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float enemyHealth = 100f;
    public GameObject enemyExplosionFX;
    //GameObject parent;
    [SerializeField] float scoreRewarded = 15f;
    // Update is called once per frame
    void Update()
    {
        if(enemyHealth <= 0)
        {
            GameObject explosionEffect = Instantiate(enemyExplosionFX,transform.position,Quaternion.identity);
            explosionEffect.transform.parent = GameObject.FindGameObjectWithTag("VFSDestroyer").transform;
            FindObjectOfType<ScoreHandler>().addScore(scoreRewarded);
            Destroy(gameObject);
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        enemyHealth -= 10f;
    }
}
