using UnityEngine.SceneManagement;

public static class LevelLoader
{
    public static void Load(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
