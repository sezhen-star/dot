using UnityEngine;

public class CollectionPage : MonoBehaviour
{
    public CollectionSlot[] slots;

    [Header("测试模式")]
    public bool testMode = false;

    [Tooltip("测试模式下，手动勾选哪些已收集")]
    public bool[] testCollected;   // 数组大小 = 收藏品数量

    [Header("最终效果")]
    public GameObject finalEffect; // 五个全收集时显示

    void OnEnable()
    {
        RefreshPage();
    }

    public void RefreshPage()
    {
        int collectedCount = 0;

        for (int i = 0; i < slots.Length; i++)
        {
            bool unlocked;

            if (testMode)
            {
                // 测试模式
                if (i < testCollected.Length)
                    unlocked = testCollected[i];
                else
                    unlocked = false;
            }
            else
            {
                // 正常模式
                unlocked = CollectibleManager.Instance
                    .IsCollected(slots[i].collectibleID);
            }

            slots[i].SetDisplay(unlocked);

            if (unlocked)
                collectedCount++;
        }

        // 判断是否全部收集
        if (collectedCount == slots.Length)
        {
            if (finalEffect != null)
                finalEffect.SetActive(true);
        }
        else
        {
            if (finalEffect != null)
                finalEffect.SetActive(false);
        }
    }
}
