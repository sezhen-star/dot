using UnityEngine;

public class BasementTrigger : MonoBehaviour
{
    public AutoScrollCamera cameraController;
    public bool enterBasement = true; // 进地下室还是出地下室

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cameraController.SetBasementMode(enterBasement);
        }
    }
}
