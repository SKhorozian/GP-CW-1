using UnityEngine;

public class RootManager : MonoBehaviour
{
    private static RootManager _instance;

    private void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);
        
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
