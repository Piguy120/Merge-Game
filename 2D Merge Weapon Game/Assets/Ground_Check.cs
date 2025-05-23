using Unity.VisualScripting;
using UnityEngine;

public class Ground_Check : MonoBehaviour
{
    public Player_Movement playerMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (collision.CompareTag("Ground"))
        {
                playerMovement.isGrounded = true;
                Debug.Log("Player is grounded");
        }
    }
}
