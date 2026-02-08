using UnityEngine;

public class PaintManager : MonoBehaviour
{
    public static PaintManager Instance;

    public Color CurrentColor { get; private set; } = Color.white;

    void Awake()
    {
        Instance = this;
    }

    public void SetCurrentColor(Color c)
    {
        CurrentColor = c;
    }
}
