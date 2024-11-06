using UnityEngine;

public class LevelCompleteManager : MonoBehaviour
{
    public GemsManager gemsManager;
    public StarsManager starsManager;
    public bool allEnemiesDefeated; // ���������� ��� �������� � true, ����� ��� ����� �����

    public void LevelCompleted()
    {
        bool reachedFinish = true; // ���������� ��� �������� � true, ����� ����� ������ ������
        bool collectedAllGems = gemsManager.AreAllGemsCollected();

        starsManager.CalculateStars(reachedFinish, collectedAllGems, allEnemiesDefeated);
    }
}
