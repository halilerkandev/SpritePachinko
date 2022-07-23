using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;
using System;

public class Eat : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Pizza")) {
            Instantiate(
                coin,
                new Vector3(
                    transform.position.x,
                    transform.position.y + 1f,
                    transform.position.z),
                transform.rotation);
            audioSource.Play();
            Destroy(collision.gameObject);
        }
    }
}
