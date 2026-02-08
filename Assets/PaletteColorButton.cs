using UnityEngine;
using UnityEngine.UI;

public class PaletteColorButton : MonoBehaviour
{
    public ColorType colorType;
    public Image image;
    public Button button;

    public Color unlockedColor;
    public Color lockedColor = Color.gray;

    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        bool unlocked = ColorUnlockManager.Instance.IsUnlocked(colorType);

        image.color = unlocked ? unlockedColor : lockedColor;
        button.interactable = unlocked;
    }

    public void OnClick()
    {
        PaintManager.Instance.SetCurrentColor(unlockedColor);
    }
}
