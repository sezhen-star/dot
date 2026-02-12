using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string collectibleID;   // Œ®“ªID£¨±»»Á "C1", "C2"

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CollectibleManager.Instance.Collect(collectibleID);
            Destroy(gameObject);
        }
    }
}
