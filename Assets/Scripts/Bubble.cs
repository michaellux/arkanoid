using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bubble : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioSource audiosource;

    [SerializeField] private readonly int price = 10;

    void Awake()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = _clip;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Projectile")
        {
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            Destroy(gameObject);
            GameManager.instance.AddPointsToPlayer(price);
        }
    }

    void OnCollisionExit2D()
    {
        audiosource.Stop();
    }
}
