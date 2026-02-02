using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform player;
    //玩家和相机的差
    private Vector3 offset;
    //相机移动速度
    private float speed = 3f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - player.position;
    }


    void LateUpdate()
    {
        //世界坐标转化为局部坐标
        Vector3 targetPosition = player.position + player.TransformDirection(offset);
        // 锁死 Z（2D 很关键）
        targetPosition.z = transform.position.z;
        //移动相机
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
