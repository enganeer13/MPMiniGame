using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] presets;
    public int levelLength = 10;

    IEnumerator Start()
    {
        float location = 0f;
        for(int i = 0; i < levelLength; i++)
        {
            GameObject presetToSpawn = presets[Random.Range(0, presets.Length)];
            yield return presetToSpawn.GetComponent<LevelChunk>().Awake();
            if (presetToSpawn.GetComponent<LevelChunk>())
            {
                if (i == 0)
                {
                    GameObject preset = Instantiate(presetToSpawn, new Vector3(location, 0, 0), Quaternion.identity);
                    location += presetToSpawn.GetComponent<LevelChunk>().getWidth()/2;
                }
                else
                {
                    GameObject preset = Instantiate(presetToSpawn, new Vector3(location + presetToSpawn.GetComponent<LevelChunk>().getWidth()/2, 0, 0), Quaternion.identity);
                    location += presetToSpawn.GetComponent<LevelChunk>().getWidth();
                }
                
            }
            else
            {
                Debug.Log("GameObject does not contain LevelChunk script.");
            }
        }
    }
}
