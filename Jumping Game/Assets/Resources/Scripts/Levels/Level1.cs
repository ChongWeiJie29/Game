using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Level1 : MonoBehaviour
{
    [SerializeField]
    private GameObject selectedCharacter, gameScreen;
    private GameObject pauseScreen;
    public static BoxCollider2D selectedCharacterCollider;
    [SerializeField]
    private GameObject enemyCharacter;
    public static bool isUnlocked = true;
    
    // Start is called before the first frame update
    void Start()
    {
        // selectedCharacter = CharacterContainer.unlockedCharacters.ElementAt(CharacterContainer.selectedCharacter);
        selectedCharacter = Instantiate(selectedCharacter, new Vector3(0, -3, 0), Quaternion.identity);
        selectedCharacter.AddComponent<PlayerControls>();
        selectedCharacter.AddComponent<Rigidbody2D>();
        selectedCharacterCollider = selectedCharacter.GetComponent<BoxCollider2D>();

        Instantiate(enemyCharacter, new Vector3(-2.3f, -3, 0), Quaternion.identity);

        pauseScreen = GameObject.Find("PauseScreen");
        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
