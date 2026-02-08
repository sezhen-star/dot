using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    // 当前选中的颜色
    public ColorType currentColor = ColorType.Red;

    // 不同颜色的子弹数量
    private Dictionary<ColorType, int> ammoCount = new Dictionary<ColorType, int>();

    void Awake()
    {
        // 初始化所有颜色，避免 Key 不存在
        foreach (ColorType type in System.Enum.GetValues(typeof(ColorType)))
        {
            ammoCount[type] = 0;
        }
    }

    // 增加子弹
    public void AddAmmo(ColorType color, int amount)
    {
        ammoCount[color] += amount;
    }

    // 使用子弹，成功返回 true
    public bool UseAmmo(ColorType color, int amount)
    {
        if (ammoCount[color] < amount)
            return false;

        ammoCount[color] -= amount;
        return true;
    }

    // 查询数量（ UI 用）
    public int GetAmmo(ColorType color)
    {
        return ammoCount[color];
    }
}
