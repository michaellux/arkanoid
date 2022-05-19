using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private AudioClip _clip;
    private AudioSource audiosource;

    private float _speed = 20;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = _clip;
    }

    void Update()
    {
        Move();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        audiosource.Stop();
    }
    
    public void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontalInput, 0, 0); 

        transform.Translate(direction * _speed * Time.deltaTime);

        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -9, -4.9f), transform.localPosition.y);
    }
}
