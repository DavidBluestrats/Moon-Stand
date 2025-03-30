using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private IEnumerator currentPowerup;
    [SerializeField] ParticleSystem explosionOnCrash;
    bool hasDied = false;
    // Update is called once per frame

    void OnTriggerEnter(Collider collision)
    {
        if (hasDied) return;
        //Debug.Log(gameObject.name + "has triggered " + collision.gameObject.name);
        if (collision.gameObject.name == "Powerup")
        {
            if (currentPowerup == null)
            {
                currentPowerup = ricoshotPowerup();
                StartCoroutine(currentPowerup);
            }
        }
        else
        {
            onDeath();
        }
        //Todo: Get reference to lasers ParticleSystem and modify them on trigger at power up
        // so that bullets bounce during the powerup duration. Could be done with corroutines.
        /*
        var particlesBounce = GetComponent<ParticleSystem>().collision;
        particlesBounce.maxKillSpeed = 1000;
        */
    }

    void onDeath()
    {
        hasDied = true;
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<WeaponsSystem>().enabled = false;
        explosionOnCrash.Play();
        GetComponent<MeshRenderer>().enabled = false;
        Invoke("restartCurrentScene", 1f);
    }

    void restartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator ricoshotPowerup()
    {
        Debug.Log("Power up has started.");
        yield return new WaitForSeconds(5);
        Debug.Log("Power up has expired");
        currentPowerup = null;
    }
}
