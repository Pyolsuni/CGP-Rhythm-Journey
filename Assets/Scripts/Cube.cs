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
    public int score = 10;
    public int combo = 1;

    void Update()
    {
        transform.position += (Cube_Movement * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagName))
        {
            AudioSource.PlayClipAtPoint(CorrectSound, transform.position);
            Counter.Instance.Combo += combo;
            Counter.Instance.Score += score;
        }
        else
        {
            AudioSource.PlayClipAtPoint(MissSound, transform.position);
            Counter.Instance.Combo = 0;
        }
        
        
        GameObject DestructionParticles = ((Transform)Instantiate(Destruction, this.transform.position, this.transform.rotation)).gameObject;
        Destroy(DestructionParticles, 3.0f);
        GameObject.Destroy(gameObject);
    }
}
