using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private Image overlay;
    [SerializeField] private int nextLevelID;
    [Header("Leaderboards UI")]
    [SerializeField] private Transform leaderboardContent;
    [SerializeField] private GameObject leaderboardEntryPrefab;

    private LeaderBoards leaderboards;
    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);
        overlay.CrossFadeAlpha(0, 1f, true);
        leaderboards = FindObjectOfType<LeaderBoards>();
    }
    private void OnEnable()
    {
        GameEvents.RaceEnd += ShowGameOverMenu;
    }
    private void OnDisable()
    {
        GameEvents.RaceEnd -= ShowGameOverMenu;
    }

    private void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    private void UpdateLeaderboardUI()
    {
        
        foreach (Transform child in leaderboardContent)
        {
            Destroy(child.gameObject);
        }

  
        List<float> results = leaderboards.GetResults();

        for (int i = 0; i < results.Count; i++)
        {
            GameObject entry = Instantiate(leaderboardEntryPrefab, leaderboardContent);
            Text entryText = entry.GetComponent<Text>();
            if (entryText != null)
            {
                entryText.text = $"{i + 1}. Laiks: {results[i]:F2} sek.";
            }
        }
    }

    public void NextRace()
    {
        StartCoroutine(LoadLevelCorotine(nextLevelID));
    }
    public void Retry()
    {
        StartCoroutine(LoadLevelCorotine(
            SceneManager.GetActiveScene().buildIndex));
    }
    private IEnumerator LoadLevelCorotine(int levelID)
    {
        overlay.CrossFadeAlpha(1, 1f, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelID);
    }

    public void Quit()
    {
        Debug.Log("Quit");
    }

}

