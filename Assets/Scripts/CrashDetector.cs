using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

    [SerializeField] float reloadTime = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool isAlive = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground" && isAlive)
        {
            isAlive=false;
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            FindObjectOfType<PlayerController>().DisableControls();
            Invoke("ReloadScene", reloadTime);
        }
    }

    void ReloadScene()
        {
            SceneManager.LoadScene(0);
        }
    
}
