using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float speed;
    public Vector3 Cube_Movement;
    public AudioClip DestroySound;

    void Update()
    {
        transform.position += (Cube_Movement * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(DestroySound, transform.position);
        GameObject.Destroy(gameObject);
    }
}
