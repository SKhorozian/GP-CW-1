using UnityEngine;

public class RootManager : MonoBehaviour
{
    private static RootManager _instance;

    void Awake()
    {
        if (_instance != null)
            DestroyImmediate(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }
}
