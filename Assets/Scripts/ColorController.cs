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
