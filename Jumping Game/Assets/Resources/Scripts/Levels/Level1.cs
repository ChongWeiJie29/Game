using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Level1 : MonoBehaviour
{
    [SerializeField]
    private GameObject selectedCharacter;
    [SerializeField]
    private GameObject pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        // selectedCharacter = CharacterContainer.unlockedCharacters.ElementAt(CharacterContainer.selectedCharacter);
        selectedCharacter = Instantiate(selectedCharacter, new Vector3(0, -3, 0), Quaternion.identity);
        selectedCharacter.transform.rotation = Quaternion.Euler(0,0,-90);
        selectedCharacter.AddComponent<PlayerControls>();
        selectedCharacter.AddComponent<Rigidbody2D>();
        selectedCharacter.AddComponent<BoxCollider2D>();
        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
