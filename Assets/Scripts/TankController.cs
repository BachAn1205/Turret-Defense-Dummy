using UnityEngine;

public class TankController : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 moveDirection;

    // --- LAB 1: COMPONENT LIFECYCLE ---
    void Awake() => Debug.Log("Lifecycle: Awake (Khởi tạo dữ liệu)");
    void OnEnable() => Debug.Log("Lifecycle: OnEnable (Bật tank)");
    void Start() => Debug.Log("Lifecycle: Start (Bắt đầu game)");
    
    void Update()
    {
        // --- LAB 2: VECTOR MOVEMENT ---
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Tạo vector hướng di chuyển
        moveDirection = new Vector3(h, 0, v);

        // Chuẩn hóa (Normalize): Giữ độ dài vector = 1 để đi chéo không bị nhanh
        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }

        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    // --- LAB 2: GIZMOS ---
    void OnDrawGizmos()
    {
        // Vẽ tia màu vàng hiển thị hướng tank đang muốn đi
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, moveDirection * 3);
        
        // Vẽ khối cầu wireframe bao quanh tank
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }

    void OnDisable() => Debug.Log("Lifecycle: OnDisable (Tắt tank)");
    void OnDestroy() => Debug.Log("Lifecycle: OnDestroy (Hủy tank)");
}