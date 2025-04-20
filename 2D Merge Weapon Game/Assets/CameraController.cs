using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player != null)
        {
            Vector3 newPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = newPosition;
        }
        else
        {
            Debug.LogWarning("Player not found");
        }
    }
}
