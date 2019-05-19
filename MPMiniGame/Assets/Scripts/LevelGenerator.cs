using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] presets;

    private Camera cam;
    private GameObject left;
    private GameObject middle;
    private GameObject right;
    private GameObject temp;

    void Start()
    {
    //initiate
        cam = FindObjectOfType<Camera>();
        float location = 0f;
        left = new GameObject("");
        middle = new GameObject("");
        right = new GameObject("");
    //get left chunk
        GameObject chunk = GetRandomLevel();
        LevelChunk levelChunk = chunk.GetComponent<LevelChunk>();
        levelChunk.Awake();
        left = ObjectPooler.Instance.SpawnFromPool(levelChunk.name, new Vector3(location, 0, 0), Quaternion.identity);
        location += left.GetComponent<LevelChunk>().getWidth();
    //get middle chunk
        chunk = GetRandomLevel();
        levelChunk = chunk.GetComponent<LevelChunk>();
        levelChunk.Awake();
        middle = ObjectPooler.Instance.SpawnFromPool(levelChunk.name, new Vector3(location, 0, 0), Quaternion.identity);
    //get right chunk
        location += middle.GetComponent<LevelChunk>().getWidth();
        chunk = GetRandomLevel();
        levelChunk = chunk.GetComponent<LevelChunk>();
        levelChunk.Awake();
        right = ObjectPooler.Instance.SpawnFromPool(levelChunk.name, new Vector3(location, 0, 0), Quaternion.identity);
    }

    void Update()
    {
        //if a middle chunk exists and the camera's right bounds exceeds the middle of it, shuffle
        if (middle.name != "")
        {
            if (cam.ViewportToWorldPoint(new Vector3(1, 0, -10)).x >= middle.transform.position.x + middle.GetComponent<LevelChunk>().getWidth()/2)
            {
                GameObject chunk = GetRandomLevel();
                LevelChunk levelChunk = chunk.GetComponent<LevelChunk>();
                left = middle;
                temp = right;
                right = ObjectPooler.Instance.SpawnFromPool(levelChunk.name, right.transform.position + new Vector3(temp.GetComponent<LevelChunk>().getWidth(), 0, 0), Quaternion.identity);
                middle = temp;
            }
        }
    }

    GameObject GetRandomLevel()
    {
        GameObject random;
        do
        {
            random = presets[Random.Range(0, presets.Length)];
        } while (left.name.Contains(random.name) || middle.name.Contains(random.name) || right.name.Contains(random.name));
        return random;
    }
}
