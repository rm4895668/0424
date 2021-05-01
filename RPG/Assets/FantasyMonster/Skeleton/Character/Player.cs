using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    ///宣告變數
    public float speed = 5;//角色移動速度
    public float rotateSpeed = 5;
    Vector3 velocity;//儲存角色位置

    //儲存動畫
    Animator anim;







    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Debug.Log("左右數值" + h);
        Debug.Log("左右數值" + v);
        //計算移動位置
        velocity = new Vector3(0, 0, v);
        velocity = transform.TransformDirection(velocity);
        
        anim.SetFloat("Speed", v);
        if (v > 0.1)
        {
            //移動位置乘上速度
            velocity *= speed;
        }

        //把計算好的位置加到角色
        transform.localPosition += velocity * Time.fixedDeltaTime;
        //角色旋轉
        transform.Rotate(0, h * rotateSpeed, 0);
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Attack", true);
        }
    }

    void AttackEnd()
    {
        anim.SetBool("Attack", false);
    }
}
