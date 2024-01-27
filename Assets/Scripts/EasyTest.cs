using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyTest : MonoBehaviour
{
    public Transform Destruction;

    private void OnTriggerEnter(Collider other)
    {
        GameObject DestructionParticles = ((Transform)Instantiate(Destruction, this.transform.position, this.transform.rotation)).gameObject;
        Destroy(DestructionParticles, 3.0f);
        GameObject.Destroy(gameObject);

        GameStatus.gameinstance.EasyMode();

        Counter.Instance.Combo = 0;
        Counter.Instance.Score = 0;
    }
}
