# Unity3D-Ball-Wall
# Wall
![image](https://github.com/user-attachments/assets/78294126-704d-4cde-af45-760a996c14ca)
# Ball
![image](https://github.com/user-attachments/assets/e07d4adc-c9a9-40e5-a66d-1a79f3152610)
# Scenes: Bóng chạm vào tường -> Random Color mỗi lần chạm
![image](https://github.com/user-attachments/assets/7800f850-0c93-4287-90b3-84ef21b1a1eb)
![image](https://github.com/user-attachments/assets/3d9bd3e1-f1ec-49ba-851b-d97b6b8347c4)





# PlayController
```
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
```
# ColorController
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    public Material[] wallMaterial; // Mảng chứa các vật liệu cho tường
    Renderer rend; // Biến lưu trữ Renderer của đối tượng
    private Material originalMaterial; // Lưu vật liệu gốc của tường

    // Start is called before the first frame update
    void Start()
    {
        // Lấy component Renderer của đối tượng
        rend = GetComponent<Renderer>(); 
        rend.enabled = true;
    }

    // Được gọi khi quả bóng va chạm với tường
    private void OnCollisionEnter(Collision col)
    {
        // Kiểm tra nếu đối tượng có tên "Ball" va chạm với tường
        if (col.gameObject.name == "Ball")
        {
            // Đổi vật liệu của tường thành vật liệu ngẫu nhiên từ mảng
            int randomIndex = Random.Range(0, wallMaterial.Length); // Chọn ngẫu nhiên chỉ số trong mảng
            rend.material = wallMaterial[randomIndex]; // Gán vật liệu ngẫu nhiên cho tường
        }
    }

    // Được gọi khi quả bóng rời khỏi tường
    private void OnCollisionExit(Collision col)
    {
        // Kiểm tra nếu đối tượng có tên "Ball" rời khỏi tường
        if (col.gameObject.name == "Ball")
        {
           // Đổi lại màu của tường thành màu trắng (mã màu #FFFFFF)
            rend.material.color = Color.white;
        }
    }
}
```
