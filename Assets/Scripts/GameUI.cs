using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [Header("Kết nối")]
    public HealthComponent playerHealth; // Observer: Theo dõi máu tank
    public Text healthText;
    public GameObject gameOverPanel; // Chính là cái GameOverText

    void OnEnable()
    {
        // Đăng ký lắng nghe sự kiện từ Lab 5
        if (playerHealth != null)
            playerHealth.OnHealthChanged += UpdateHealthUI;
    }

    void OnDisable()
    {
        // Hủy đăng ký
        if (playerHealth != null)
            playerHealth.OnHealthChanged -= UpdateHealthUI;
    }

    // Hàm cập nhật UI (Chạy mỗi khi máu đổi)
    void UpdateHealthUI(int hp)
    {
        healthText.text = "SHIELD: " + hp + "%";
    }

    // Hàm hiện Game Over (Sẽ được gọi bởi UnityEvent Lab 6)
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }
}