using UnityEngine;

public class LevelCompleteManager : MonoBehaviour
{
    public GemsManager gemsManager;
    public StarsManager starsManager;
    public bool allEnemiesDefeated; // ”становите это значение в true, когда все враги убиты

    public void LevelCompleted()
    {
        bool reachedFinish = true; // ”становите это значение в true, когда игрок достиг финиша
        bool collectedAllGems = gemsManager.AreAllGemsCollected();

        starsManager.CalculateStars(reachedFinish, collectedAllGems, allEnemiesDefeated);
    }
}
