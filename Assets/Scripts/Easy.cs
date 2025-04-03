using UnityEngine;

public class Easy : MonoBehaviour
{

    public void ReactToClick() {
        Debug.Log("I've been clicked");
        Initiate.Fade("EasyLevel", Color.green, 1.0f);
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