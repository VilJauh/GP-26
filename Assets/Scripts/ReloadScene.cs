using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public void ReloadCurrentScene()
    {
        Collectible.total = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
