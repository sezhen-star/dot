using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance;

    private HashSet<string> collected = new HashSet<string>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Collect(string id)
    {
        if (!collected.Contains(id))
        {
            collected.Add(id);
            Debug.Log("Collected: " + id);
        }
    }

    public bool IsCollected(string id)
    {
        return collected.Contains(id);
    }
}
