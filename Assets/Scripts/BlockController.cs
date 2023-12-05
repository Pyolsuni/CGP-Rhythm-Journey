using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public GameObject[] cutDirectionArrows;

    public void SetCutDirection(int cutDirection)
    {
        if (cutDirection >= 0 && cutDirection < cutDirectionArrows.Length)
        {
            for (int i = 0; i < cutDirectionArrows.Length; i++)
            {
                cutDirectionArrows[i].SetActive(i == cutDirection);
            }
        }
        else
        {
            Debug.LogWarning($"Invalid cut direction: {cutDirection}");
        }
    }
}
