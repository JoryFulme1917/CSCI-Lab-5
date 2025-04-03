using UnityEngine;

public class Credit : MonoBehaviour
{

    public void ReactToClick() {
        Debug.Log("I've been clicked");
        Initiate.Fade("Credit", Color.blue, 1.0f);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}