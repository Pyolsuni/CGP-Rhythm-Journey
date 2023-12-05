using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float speed = 2.11666667f;
    public Vector3 Cube_Movement;
    public AudioClip CorrectSound;
    public AudioClip MissSound;
    public Transform Destruction;
    public string TagName;

    void Update()
    {
        transform.position += (Cube_Movement * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagName))
        {
            AudioSource.PlayClipAtPoint(CorrectSound, transform.position);
        }
        else
        {
            AudioSource.PlayClipAtPoint(MissSound, transform.position);
        }
        
        
        GameObject DestructionParticles = ((Transform)Instantiate(Destruction, this.transform.position, this.transform.rotation)).gameObject;
        Destroy(DestructionParticles, 3.0f);
        GameObject.Destroy(gameObject);
    }
}
