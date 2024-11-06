using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarsManager : MonoBehaviour
{
    public int totalStars; // Общее количество звезд
    public Text resultText; // Текст для отображения результата
    public Button returnButton; // Кнопка для возврата к выбору уровня

    private int starsEarned;

    void Start()
    {
        returnButton.onClick.AddListener(ReturnToLevelSelection);
        returnButton.gameObject.SetActive(false); // Скрываем кнопку в начале
    }

    public void CalculateStars(bool reachedFinish, bool collectedAllGems, bool defeatedAllEnemies)
    {
        starsEarned = 0;

        if (reachedFinish)
            starsEarned++;

        if (collectedAllGems)
            starsEarned++;

        if (defeatedAllEnemies)
            starsEarned++;

        DisplayResults();
    }

    private void DisplayResults()
    {
        resultText.text = $"Вы заработали {starsEarned} звезды(зад)!";

        // Показываем кнопку возврата
        returnButton.gameObject.SetActive(true);
    }

    private void ReturnToLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection"); // Замените на имя вашей сцены выбора уровня
    }
}
