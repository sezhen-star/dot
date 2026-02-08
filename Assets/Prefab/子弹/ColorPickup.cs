using UnityEngine;

public class ColorPickup : MonoBehaviour
{
    public ColorType colorType; // 预设颜色
    private SpriteRenderer sr;
    private Vector3 startPos;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = GetColor(colorType);
        startPos = transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 玩家拾取
        PlayerAmmo playerAmmo = other.GetComponent<PlayerAmmo>();
        if (playerAmmo != null)
        {
            // 增加子弹数量
            playerAmmo.AddAmmo(colorType, 3);
            //切换颜色
            playerAmmo.currentColor = colorType;

            Destroy(gameObject);
        }
    }

    Color GetColor(ColorType type)
    {
        switch (type)
        {
            case ColorType.Red: return Color.red;
            case ColorType.Green: return Color.green;
            case ColorType.Blue: return Color.blue;
            case ColorType.Yellow: return Color.yellow;
            case ColorType.Purple: return new Color(0.5f,0,0.5f);
            case ColorType.Cyan: return Color.cyan;
            case ColorType.White: return Color.white;
            case ColorType.Black: return Color.black;
            default: return Color.white;
        }
    }
}
