using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    private AudioSource audiosource;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = _clip;
    }

    void OnCollisionEnter2D()
    {
        AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
    }

    void OnCollisionExit2D()
    {
        audiosource.Stop();
    }
}
