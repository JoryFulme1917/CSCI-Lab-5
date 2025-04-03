using UnityEngine;

public class Normal : MonoBehaviour
{

    public void ReactToClick() {
        Debug.Log("I've been clicked");
        Initiate.Fade("MediumLevel", Color.blue, 1.0f);
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
