using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5.0f;

    void Start()
    {
        // Lấy và gán component Rigidbody cho biến rb
        rb = GetComponent<Rigidbody>();

        // Kiểm tra nếu Rigidbody có gắn đúng vào đối tượng không
        if (rb == null)
        {
            Debug.LogError("Thiếu component Rigidbody trên đối tượng.");
        }
    }

    void FixedUpdate()
    {
        // Lấy input từ người chơi cho trục ngang và trục dọc
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Tạo một Vector3 mới để di chuyển theo chiều ngang (x) và chiều dọc (z)
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Thêm lực vào Rigidbody để di chuyển quả bóng
        rb.AddForce(movement * speed);
    }
}
