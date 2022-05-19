using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    [SerializeField]
    private AudioClip _clip;
    private AudioSource audiosource;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = _clip;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        audiosource.Stop();
    }
}
