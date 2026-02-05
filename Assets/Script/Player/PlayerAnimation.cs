using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private PlayerMovement movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();

        //从子物体拿 Animator
        animator = GetComponentInChildren<Animator>();

        if (animator == null)
            Debug.LogError("在 Player 的子物体中找不到 Animator！");
    }

    void Update()
    {
        float speed = Mathf.Abs(rb.velocity.x);
        float yVel = rb.velocity.y;

        animator.SetFloat("speed", speed);
        animator.SetFloat("yVelocity", yVel);

        // 动画层用的“落地判断”：必须真的没在往下掉
        bool groundedForAnim = movement.IsGrounded && yVel <= 0.1f;
        animator.SetBool("isGrounded", groundedForAnim);
    }
}
