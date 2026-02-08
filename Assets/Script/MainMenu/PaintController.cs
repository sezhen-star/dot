using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PaintController : MonoBehaviour
{
    [Header("画布尺寸")]
    public int textureWidth = 512;
    public int textureHeight = 512;

    [Header("UI")]
    public RawImage paintImage;

    Texture2D paintTexture;
    RenderTexture renderTexture;

    void Start()
    {
        InitCanvas();
    }

    void InitCanvas()
    {
        // 创建 Texture2D
        paintTexture = new Texture2D(textureWidth, textureHeight, TextureFormat.RGBA32, false);
        paintTexture.filterMode = FilterMode.Point;

        // 清空为透明
        Color clear = new Color(0, 0, 0, 0);
        for (int x = 0; x < textureWidth; x++)
        {
            for (int y = 0; y < textureHeight; y++)
            {
                paintTexture.SetPixel(x, y, clear);
            }
        }

        paintTexture.Apply();

        // 创建 RenderTexture
        renderTexture = new RenderTexture(textureWidth, textureHeight, 0);
        renderTexture.Create();

        Graphics.Blit(paintTexture, renderTexture);
        paintImage.texture = renderTexture;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryFloodFill();
        }
    }

    void TryFloodFill()
    {
        Vector2 localPos;
        RectTransform rect = paintImage.rectTransform;

        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rect, Input.mousePosition, null, out localPos))
            return;

        Rect r = rect.rect;
        float px = (localPos.x - r.x) / r.width;
        float py = (localPos.y - r.y) / r.height;

        int x = Mathf.FloorToInt(px * textureWidth);
        int y = Mathf.FloorToInt(py * textureHeight);

        if (x < 0 || x >= textureWidth || y < 0 || y >= textureHeight)
            return;

        //这里才是正确的调用
        FloodFill(x, y, PaintManager.Instance.CurrentColor);
    }

    // ================= 洪水填充 =================

    void FloodFill(int startX, int startY, Color newColor)
    {
        Color targetColor = paintTexture.GetPixel(startX, startY);

        if (SameColor(targetColor, newColor))
            return;

        Queue<Vector2Int> queue = new Queue<Vector2Int>();
        queue.Enqueue(new Vector2Int(startX, startY));

        while (queue.Count > 0)
        {
            Vector2Int p = queue.Dequeue();

            if (p.x < 0 || p.x >= textureWidth ||
                p.y < 0 || p.y >= textureHeight)
                continue;

            Color c = paintTexture.GetPixel(p.x, p.y);
            if (!SameColor(c, targetColor))
                continue;

            paintTexture.SetPixel(p.x, p.y, newColor);

            queue.Enqueue(new Vector2Int(p.x + 1, p.y));
            queue.Enqueue(new Vector2Int(p.x - 1, p.y));
            queue.Enqueue(new Vector2Int(p.x, p.y + 1));
            queue.Enqueue(new Vector2Int(p.x, p.y - 1));
        }

        paintTexture.Apply();
        Graphics.Blit(paintTexture, renderTexture);
    }
    bool SameColor(Color a, Color b)
    {
        return Mathf.Abs(a.r - b.r) < 0.01f &&
               Mathf.Abs(a.g - b.g) < 0.01f &&
               Mathf.Abs(a.b - b.b) < 0.01f &&
               Mathf.Abs(a.a - b.a) < 0.01f;
    }
}