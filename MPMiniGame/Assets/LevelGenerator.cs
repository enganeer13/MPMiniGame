using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] presets;
    public int preset_width = 18;
    public int levelLength = 10;

    private void Start()
    {
        for(int i = 0; i < levelLength; i++)
        {
            GameObject preset = Instantiate(presets[Random.Range(0, presets.Length)], new Vector3(i * preset_width, 0, 0), Quaternion.identity);
        }
    }
}
