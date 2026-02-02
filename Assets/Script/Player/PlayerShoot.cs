using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform fashe;
    public float bulletSpeed = 10f;

    void Update()
    {
        if (Mouse.current == null)
            return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null||fashe == null)
        {
            Debug.Log("子弹组件为空");
            return;
        }
            

        // 1️鼠标屏幕坐标 → 世界坐标
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseWorldPos.z = 0f;

        // 2️计算方向
        Vector2 shootDir = (mouseWorldPos - fashe.position).normalized;

        // 点积判断：是否在前方
        float dot = Vector2.Dot(transform.right, shootDir);

        if (dot <= 0f)
        {
            // 鼠标在身后，不允许射击
            return;
        }

        // 3️生成子弹
        GameObject bullet = Instantiate(bulletPrefab, fashe.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = shootDir * bulletSpeed;
        }
    }
}
