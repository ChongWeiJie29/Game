using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterContainer : MonoBehaviour
{
    private RectTransform characterContainer;
    private int unlockedCharactersNum;
    private float scrollValue;
    // Start is called before the first frame update
    void Start()
    {
        unlockedCharactersNum = UnlockedCharactersData.loadUnlockedCharactersNum();
        characterContainer = GetComponent<RectTransform>();
        characterContainer.sizeDelta = new Vector2(1000 * unlockedCharactersNum, characterContainer.sizeDelta.y);
    }

    void Update()
    {
        characterSelect();
    }

    void characterSelect()
    {
        if(Input.touchCount > 0)
        {
            scrollValue = characterContainer.position.x;
        }
        else
        {
            for (int i = 1; i <= 2*unlockedCharactersNum; i+=2)
            {
                if(scrollValue < -2.31*i && scrollValue > -2.31*(i+1))
                {
                    characterContainer.position = new Vector2(Mathf.Lerp(characterContainer.position.x, (float)( -2.31*i), 0.1f), characterContainer.position.y);
                }
                else if (scrollValue < -2.31*(i+1) && scrollValue > -2.31*(i+2))
                {
                    characterContainer.position = new Vector2(Mathf.Lerp(characterContainer.position.x, (float)( -2.31*(i+2)), 0.1f), characterContainer.position.y);
                }
            }
        }
    }
}
