using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterContainer : MonoBehaviour
{
    private RectTransform characterContainer;
    private int unlockedCharactersNum;
    // Start is called before the first frame update
    void Start()
    {
        unlockedCharactersNum = UnlockedCharactersData.loadUnlockedCharactersNum();
        characterContainer = GetComponent<RectTransform>();
        characterContainer.sizeDelta = new Vector2(1000 * unlockedCharactersNum, characterContainer.sizeDelta.y);
    }
}
