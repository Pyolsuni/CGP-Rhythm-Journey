using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public TextAsset beatMapJson;
    public GameObject redBlockPrefab;
    public GameObject blueBlockPrefab;
    public float spacingX = 0.75f;
    public float offsetX = 1.125f;
    public float spacingY = 0.5f;
    public float offsetY = 0.75f;

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


    private void OnEnable()
    {
        mapData = JsonUtility.FromJson<BeatSaberMapData>(beatMapJson.text);

        foreach (BeatSaberBlockData blockData in mapData._notes)
        {
            float spawnTime = blockData._time * 60 / 127;
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
        Debug.Log(startTime);
        Debug.Log(elapsedTime);
        Debug.Log(spawnTime);
    }

    private void SpawnBlock(BeatSaberBlockData blockData)
    {
        GameObject blockPrefab;
        switch (blockData._type)
        {
            case 0:
                blockPrefab = redBlockPrefab;
                break;
            case 1:
                blockPrefab = blueBlockPrefab;
                break;
            default:
                Debug.LogWarning($"Invalid block type: {blockData._type}");
                return;
        }

        float xPosition = -(blockData._lineIndex * spacingX - offsetX); //Added offset so that it is centered
        float yPosition = blockData._lineLayer * spacingY + offsetY; //Added offset so that the cube don't spawn in contact with Platform_Cube
        Vector3 blockPosition = new Vector3(xPosition, yPosition, transform.position.z);

        GameObject spawnedBlock = Instantiate(blockPrefab, blockPosition, Quaternion.identity, transform);
        

        switch (blockData._cutDirection)
        {
            case 0:
                spawnedBlock.transform.Rotate(0, 0, 180);
                break;
            case 1:
                spawnedBlock.transform.Rotate(0, 0, 0);
                break;
            case 2:
                spawnedBlock.transform.Rotate(0, 0, 90);
                break;
            case 3:
                spawnedBlock.transform.Rotate(0, 0, -90);
                break;
            case 4:
                spawnedBlock.transform.Rotate(0, 0, -225);
                break;
            case 5:
                spawnedBlock.transform.Rotate(0, 0, 225);
                break;
            case 6:
                spawnedBlock.transform.Rotate(0, 0, 45);
                break;
            case 7:
                spawnedBlock.transform.Rotate(0, 0, -45);
                break;
            default:
                Debug.LogWarning($"Invalid block type: {blockData._type}");
                return;
        }


    }
}