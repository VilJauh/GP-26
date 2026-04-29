using UnityEngine;

public class CollectibleRandomizer : MonoBehaviour
{
    public GameObject collectible;

    public int amount = 10;

    public GameObject ground;

    void Start()
    {
        var sizeX = ground.transform.localScale.x * 10 / 2;
        var sizeZ = ground.transform.localScale.z * 10 / 2;
        for (int i = 0; i < amount; i++) 
        {
            Instantiate(collectible, new Vector3(Random.Range(-sizeX, sizeX), 1f, Random.Range(-sizeZ, sizeZ)), Quaternion.identity);
        }
    }

}
