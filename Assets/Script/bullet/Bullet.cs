using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ColorType colorType;
    public float lifeTime = 2f;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        SetColorFromType(colorType);

        Destroy(gameObject, lifeTime);
    }

    public void SetColorFromType(ColorType type)
    {
        Color color = Color.white;

        switch (type)
        {
            case ColorType.Red: color = Color.red; break;
            case ColorType.Green: color = Color.green; break;
            case ColorType.Blue: color = Color.blue; break;
            case ColorType.Yellow: color = Color.yellow; break;
            case ColorType.Purple: color = new Color(0.5f, 0f, 0.5f); break;
            case ColorType.Cyan: color = Color.cyan; break;
            case ColorType.White: color = Color.white; break;
            case ColorType.Black: color = Color.black; break;
        }

        if (sr != null)
            sr.color = color;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
    
}
