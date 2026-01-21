using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Transform target; // Kéo Tank vào đây
    public bool useSmoothRotation = true; // Toggle để so sánh Lab 3
    public float rotationSpeed = 5f;

    [Header("Debug Info (Lab 4)")]
    public float currentAngle; // Xem góc trực tiếp trên Inspector

    void Update()
    {
        if (target == null) return;

        Vector3 directionToTarget = target.position - transform.position;
        directionToTarget.y = 0; // Chỉ xoay ngang (Topdown)

        // --- LAB 3: QUATERNION ROTATION ---
        if (useSmoothRotation)
        {
            // Cách 1: Xoay mượt (Slerp)
            Quaternion targetRot = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // Cách 2: Xoay cứng (LookAt)
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }

        // --- LAB 4: SIGNED ANGLE ---
        // Tính góc giữa hướng mặt tháp (Forward) và hướng tới Tank
        currentAngle = Vector3.SignedAngle(transform.forward, directionToTarget, Vector3.up);
        
        // Logic bắn đơn giản dựa trên góc
        if (Mathf.Abs(currentAngle) < 10f)
        {
            Debug.DrawRay(transform.position, directionToTarget, Color.red); // Bắn
        }
        else
        {
            Debug.DrawRay(transform.position, directionToTarget, Color.green); // Chưa ngắm trúng
        }
    }
}