using UnityEngine;
using UnityEngine.UI;

public class CollectionSlot : MonoBehaviour
{
    public string collectibleID;
    public Image itemImage;

    public void SetDisplay(bool unlocked)
    {
        itemImage.enabled = unlocked;
    }

    public void UpdateDisplay()
    {
        bool unlocked = CollectibleManager.Instance
            .IsCollected(collectibleID);

        SetDisplay(unlocked);
    }
}
