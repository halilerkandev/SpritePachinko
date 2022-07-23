using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject pizza;
    private float time = 0f;
    public float frequency = 2f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(time == 0f) {
            Instantiate(pizza, new Vector3(NextFloat(-3.75f, 3.75f), 6f, 0f), new Quaternion());
        }
        time += Time.deltaTime;
        if(time > frequency) {
            time = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pizza"))
        {
            audioSource.Play();
            Destroy(collision.gameObject);
        }
    }

    static float NextFloat(float min, float max)
    {
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }
}
