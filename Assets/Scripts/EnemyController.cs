using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject winTextObject;
    public GameObject loseTextObject;  
    
    private static int enemiesTriggered = 0;
    private static int totalEnemies = 3;
    
    private PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false); 
    }
    
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("DeathColider")) 
        {
            gameObject.SetActive(false);

            enemiesTriggered++;

            if (enemiesTriggered == totalEnemies || playerController != null && !playerController.isDead)
            {
                winTextObject.SetActive(true);
                loseTextObject.SetActive(false);
            }
        }
    }
}
