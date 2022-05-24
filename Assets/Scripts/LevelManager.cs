using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelManager: MonoBehaviour
{

    int currentLevel;
    GameObject prefabKey;
    GameObject prefabGrass;
    GameObject prefabWall;

    private void Awake()
    {
        currentLevel = 0;
        prefabKey = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Key.prefab");
        prefabGrass = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Grass.prefab");
    }

    private void Start()
    {
        CreateNextLevel();
    }

    public void CreateNextLevel()
    {
        var newLevel = new GameObject($"Level {currentLevel}");

        Instantiate(prefabGrass, newLevel.transform);

    }
}
