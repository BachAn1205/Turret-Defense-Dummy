using UnityEngine;
using UnityEngine.Events; // Cho Lab 6
using System;             // Cho Lab 5

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    // --- LAB 5: C# EVENT (Observer Pattern) ---
    // Dùng Action nhẹ, nhanh, thích hợp để update UI code-to-code
    public event Action<int> OnHealthChanged;

    // --- LAB 6: UNITY EVENT ---
    // Thích hợp để Designer kéo thả trong Inspector (vụ nổ, âm thanh, tắt game)
    public UnityEvent OnDeath;

    void Start()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth); // Báo cáo máu ban đầu
    }

    void Update()
    {
        // Test trừ máu
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;
        
        // 1. Bắn sự kiện cho các Observer (như UI) biết
        OnHealthChanged?.Invoke(currentHealth);

        // 2. Kiểm tra chết
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Tank đã nổ!");
            OnDeath.Invoke(); // Kích hoạt sự kiện chết
        }
    }
}