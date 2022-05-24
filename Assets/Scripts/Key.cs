using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] GameObject shockwavePrefab;
    [SerializeField] GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            Instantiate(shockwavePrefab, transform.position, Quaternion.identity);
            gameManager.UpdateLevel();
            Destroy(gameObject, 0.1f);
        }
    }
}
