using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    public GameObject fishBot;
	public GameObject seal;
	public GameObject shark;
    public GameObject blood;

	public int numFish;
	public int scale;
    int FishEaten = 0;
    public TextMeshProUGUI FishText;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        } else {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        FishText = GameObject.Find("FishEaten")?.GetComponent<TextMeshProUGUI>();
        ResetGame();
    }

    void ResetGame() {
        FishEaten = 0;
        if (FishText != null) {
            FishText.text = "Fish Eaten: " + FishEaten;
        }

        SpawnFish();
    }

    public void IncScore(int ds) {
        FishEaten += ds;
        FishText.text = "Fish Eaten: " + FishEaten;
        if(FishEaten == 10){
            Initiate.Fade("Win Screen", Color.green, 1.0f);
        }

    }

    void SpawnFish() {
        for (int i = 0; i < numFish; i++)
		{
			GameObject fish = (GameObject)Instantiate(fishBot,
				new Vector3(Random.Range(-scale / 2, scale / 2),
					Random.Range(-scale / 2, scale / 2), 0),
				Quaternion.Euler(0, 0, Random.Range(0, 360)));
			fish.GetComponent<AvoidSteer>().target = seal;
			fish.GetComponent<AvoidSteer>().shark = shark;
            fish.GetComponent<AvoidSteer>().blood = blood;
			fish.GetComponent<AvoidOtherSteer>().shark = shark;
			fish.GetComponent<AvoidOtherSteer>().target = seal;
		}
    }

    void Update() {
        
    }

}
