using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem myParticleSystem;
    public GameObject graficItem;
    public float timeToHide = 0f;

    [Header("Sounds")]
    public AudioSource AudioSource;

    private void Awake()
    {
       // if (myParticleSystem != null) myParticleSystem.transform.SetParent(null);
    }
    private void OnTriggerEnter(Collider collision)
    {        
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
        if (graficItem != null) graficItem.SetActive(false);
        Invoke("HideObject", timeToHide);        
        OnCollect();
    }
    private void HideObject()
    {
        gameObject.SetActive(false);
    }
    protected virtual void OnCollect()
    {
        if (myParticleSystem != null) myParticleSystem.Play();
        if (AudioSource != null) AudioSource.Play();
    }
}
