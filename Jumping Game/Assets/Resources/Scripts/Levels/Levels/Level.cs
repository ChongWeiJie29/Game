using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level: MonoBehaviour
{
    protected GameObject selectedCharacter;
    protected GameObject pauseScreen;
    public static BoxCollider2D selectedCharacterCollider;
    protected GameObject enemyCharacter;
    public static bool isUnlocked;
    public static bool isFinished;
    protected void loadItems()
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
    void Start()
    {
        selectedCharacter = Resources.Load("Assets/Characters/Scientists/Scientist/Scientist") as GameObject;
        enemyCharacter = Resources.Load("Assets/Characters/Enemy") as GameObject;
        loadItems();
    }
}
