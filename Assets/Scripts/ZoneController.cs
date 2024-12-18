using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Зона смерти: перезапуск уровня
        if (other.gameObject.CompareTag("DeathZone"))
        {
            ReloadLevel();
        }

        // Зона перехода: загрузка следующего уровня
        if (other.gameObject.CompareTag("LevelExit"))
        {
            LoadNextLevel();
        }
    }

    void ReloadLevel()
    {
        // Перезапуск текущего уровня
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void LoadNextLevel()
    {
        // Загрузка следующего уровня по индексу
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Проверка, есть ли следующий уровень
        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
        else
        {
            Debug.Log("Последний уровень пройден!");
        }
    }
}
