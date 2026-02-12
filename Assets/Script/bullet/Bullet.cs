using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class Bullet : MonoBehaviour
{
    public ColorType colorType;
    public float lifeTime = 2f;

    private Animator animator;
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        ApplyAnimation();
        Destroy(gameObject, lifeTime);
    }

    void ApplyAnimation()
    {
        if (animator == null) return;

        RuntimeAnimatorController controller = null;

        // 根据颜色选择 Animator Controller
        switch (colorType)
        {
            case ColorType.Red:
                controller = Resources.Load<RuntimeAnimatorController>("Animation/BulletRed");
                break;

            case ColorType.Yellow:
                controller = Resources.Load<RuntimeAnimatorController>("Animation/BulletYellow");
                break;

            case ColorType.Blue:
                controller = Resources.Load<RuntimeAnimatorController>("Animation/BulletBlue");
                break;
        }

        if (controller != null)
        {
            animator.runtimeAnimatorController = controller;
        }
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
