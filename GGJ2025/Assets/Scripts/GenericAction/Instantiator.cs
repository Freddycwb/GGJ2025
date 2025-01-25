using UnityEngine;

public class Instantiator : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private GameObject spawnPoint;

    public void Create()
    {
        Instantiate(obj, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    public void CreateXObjects(int value)
    {
        for (int i = 0; i < value; i++)
        {
            Create();
        }
    }
}
