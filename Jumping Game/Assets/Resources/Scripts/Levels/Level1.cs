using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Level1 : MonoBehaviour
{
    [SerializeField]
    private GameObject selectedCharacter;
    private GameObject pauseScreen;
    public static BoxCollider2D selectedCharacterCollder;
    // Start is called before the first frame update
    void Start()
    {
        // selectedCharacter = CharacterContainer.unlockedCharacters.ElementAt(CharacterContainer.selectedCharacter);
        selectedCharacter = Instantiate(selectedCharacter, new Vector3(0, -3, 0), Quaternion.identity);
        selectedCharacter.transform.rotation = Quaternion.Euler(0,0,-90);
        selectedCharacter.AddComponent<PlayerControls>();
        selectedCharacter.AddComponent<Rigidbody2D>();
        selectedCharacterCollder = selectedCharacter.AddComponent<BoxCollider2D>();
        pauseScreen = GameObject.Find("PauseScreen");
        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
