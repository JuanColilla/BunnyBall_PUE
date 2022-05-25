using UnityEditor;
using UnityEngine;

public class LevelManager: MonoBehaviour
{

    int levelNumber;
    GameObject prefabKey;
    GameObject prefabGrass;
    GameObject prefabWall;
    GameObject player;
    GameObject currentLevel;

    private void Awake()
    {
        levelNumber = 0;
        prefabKey = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Key.prefab");
        prefabGrass = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Grass.prefab");
        player = GameObject.Find("Player");
    }

    private void Start()
    {
        CreateNextLevel();
    }


    // Create X amount of grass where X = levelNumber + 1
    // Randomize grass size and place it on the right of the previous level.
    public void CreateNextLevel()
    {
        if (currentLevel != null) {
            Destroy(currentLevel);
            levelNumber++;
        }
        var newLevel = new GameObject($"Level {levelNumber}");
        currentLevel = newLevel;
        //var floor = Instantiate(prefabGrass, newLevel.transform);

        var key = Instantiate(prefabKey, newLevel.transform);


        //floor.transform.localScale = new Vector3(10, 1, 10);


        GameObject floor;
        if (levelNumber == 0)
        {
            floor = Instantiate(prefabGrass, newLevel.transform);
            floor.transform.localScale = new Vector3(10, 1, 10);
            key.transform.position = GetRandomKeyPosition(player.transform.position, floor.transform.localScale, 2);
        }
        else
        {
            for (int currentLeveLNumber = 0; currentLeveLNumber < levelNumber + 1 && levelNumber <= 10; currentLeveLNumber++)
            {
                Debug.Log($"Creating level: {levelNumber}, ");
                floor = Instantiate(original: prefabGrass, position: new Vector3(currentLevel.transform.position.x / 2, 1, 0), rotation: Quaternion.identity, parent: currentLevel.transform);
                floor.transform.localScale = new Vector3(Random.Range(3, 15), 1, Random.Range(3, 15));
            }
            //key.transform.position = GetRandomKeyPosition(player.transform.position, floor.transform.localScale, 2);
        }
        







        //float floorX = floor.transform.localScale.x;
        //float floorZ = floor.transform.localScale.z;



    }


    // Recursive function.
    // Get lastGrass position, place key on top of it and safeArea around the player.
    private Vector3 GetRandomKeyPosition(Vector3 playerPosition, Vector3 grassSize, float safetyMargin)
    {
        var keyPosition = new Vector3(Random.Range(-grassSize.x / 2, grassSize.x / 2), 1.25f, Random.Range(-grassSize.z / 2, grassSize.z / 2));


        //if (Vector2.Distance(new Vector2(playerPosition.x, playerPosition.z),
        //    new Vector2(keyPosition.x, keyPosition.z)) < safetyMargin)
        //{
        //    keyPosition = GetRandomKeyPosition(playerPosition, grassSize, safetyMargin);
        //}

        //return keyPosition;

        // OLD SOLUTION
        if ((int)keyPosition.x >= (int)playerPosition.x - safetyMargin && (int)keyPosition.x <= (int)player.transform.position.x + safetyMargin
            && (int)keyPosition.z >= (int)playerPosition.z - safetyMargin && (int)keyPosition.z <= (int)player.transform.position.z + safetyMargin)
        {
            return GetRandomKeyPosition(playerPosition, grassSize, safetyMargin);
        }
        return keyPosition;
    }
}
