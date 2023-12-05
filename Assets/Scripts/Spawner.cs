using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public TextAsset beatMapJson;
    public GameObject redBlockPrefab;
    public GameObject blueBlockPrefab;
    public float spacingX = 2.0f;
    public float offsetX = 3.0f;
    public float spacingY = 2.0f;

    private BeatSaberMapData mapData;

    [System.Serializable]
    public class BeatSaberBlockData
    {
        public float _time;
        public int _lineIndex;
        public int _lineLayer;
        public int _type;
        public int _cutDirection;
    }

    [System.Serializable]
    public class BeatSaberMapData
    {
        public string _version;
        public List<BeatSaberBlockData> _notes;
    }


    private void Start()
    {
        mapData = JsonUtility.FromJson<BeatSaberMapData>(beatMapJson.text);

        foreach (BeatSaberBlockData blockData in mapData._notes)
        {
            float spawnTime = blockData._time;
            StartCoroutine(SpawnBlockRoutine(blockData, spawnTime));
        }
    }

    private IEnumerator SpawnBlockRoutine(BeatSaberBlockData blockData, float spawnTime)
    {
        float startTime = Time.time;
        float elapsedTime = 0f;

        while (elapsedTime < spawnTime)
        {
            elapsedTime = Time.time - startTime;
            yield return null;
        }

        SpawnBlock(blockData);
    }

    private void SpawnBlock(BeatSaberBlockData blockData)
    {
        GameObject blockPrefab;
        switch (blockData._type)
        {
            case 0:
                blockPrefab = blueBlockPrefab;
                break;
            case 1:
                blockPrefab = redBlockPrefab;
                break;
            default:
                Debug.LogWarning($"Invalid block type: {blockData._type}");
                return;
        }

        float xPosition = blockData._lineIndex * spacingX - offsetX;
        float yPosition = blockData._lineLayer * spacingY + 1; //Added +1 so that the cube don't spawn in contact with Platform_Cube
        Vector3 blockPosition = new Vector3(xPosition, yPosition, transform.position.z);

        GameObject spawnedBlock = Instantiate(blockPrefab, blockPosition, Quaternion.identity, transform);

        BlockController blockController = spawnedBlock.GetComponent<BlockController>();
        if (blockController != null)
        {
            blockController.SetCutDirection(blockData._cutDirection);
        }
    }
}