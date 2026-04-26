using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public void ReloadCurrentScene()
    {
        Collectible.total -= Collectible.total;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
