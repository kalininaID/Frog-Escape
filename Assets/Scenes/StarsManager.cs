using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarsManager : MonoBehaviour
{
    public int totalStars; // ����� ���������� �����
    public Text resultText; // ����� ��� ����������� ����������
    public Button returnButton; // ������ ��� �������� � ������ ������

    private int starsEarned;

    void Start()
    {
        returnButton.onClick.AddListener(ReturnToLevelSelection);
        returnButton.gameObject.SetActive(false); // �������� ������ � ������
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
        resultText.text = $"�� ���������� {starsEarned} ������(���)!";

        // ���������� ������ ��������
        returnButton.gameObject.SetActive(true);
    }

    private void ReturnToLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection"); // �������� �� ��� ����� ����� ������ ������
    }
}
