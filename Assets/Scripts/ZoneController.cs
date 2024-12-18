using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // ���� ������: ���������� ������
        if (other.gameObject.CompareTag("DeathZone"))
        {
            ReloadLevel();
        }

        // ���� ��������: �������� ���������� ������
        if (other.gameObject.CompareTag("LevelExit"))
        {
            LoadNextLevel();
        }
    }

    void ReloadLevel()
    {
        // ���������� �������� ������
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void LoadNextLevel()
    {
        // �������� ���������� ������ �� �������
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // ��������, ���� �� ��������� �������
        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
        else
        {
            Debug.Log("��������� ������� �������!");
        }
    }
}
