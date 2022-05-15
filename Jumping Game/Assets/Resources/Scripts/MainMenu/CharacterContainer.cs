using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterContainer : MonoBehaviour
{
    private RectTransform characterContainer;
    private int unlockedCharactersNum;
    private float scrollValue;
    private int selectedCharacter = 0;
    [SerializeField]
    private GameObject character1;
    [SerializeField]
    private GameObject character2;
    [SerializeField]
    private GameObject character3;
    [SerializeField]
    private GameObject character4;
    [SerializeField]
    private GameObject character5;
    // Start is called before the first frame update
    void Start()
    {
        characterContainer = GetComponent<RectTransform>();
        for (int i = 1; i <= 5; i++)
        {
            switch (i)
            {
                case 1:
                    if (Square.getUnlocked())
                    {
                        character1 = Instantiate(character1, transform.position, Quaternion.identity);
                        character1.transform.SetParent(characterContainer);
                        character1.transform.localScale = new Vector3(300, 300, 300);
                        unlockedCharactersNum ++;
                    }
                    break;
                case 2:
                    if (Square1.getUnlocked())
                    {
                        character2 = Instantiate(character2, transform.position, Quaternion.identity);
                        character2.transform.SetParent(characterContainer);
                        character2.transform.localScale = new Vector3(300, 300, 300);
                        unlockedCharactersNum ++;
                    }
                    break;
                case 3:
                    if (Square2.getUnlocked())
                    {
                        character3 = Instantiate(character3, transform.position, Quaternion.identity);
                        character3.transform.SetParent(characterContainer);
                        character3.transform.localScale = new Vector3(300, 300, 300);
                        unlockedCharactersNum ++;
                    }
                    break;
                case 4:
                    if (Square3.getUnlocked())
                    {
                        character4 = Instantiate(character4, transform.position, Quaternion.identity);
                        character4.transform.SetParent(characterContainer);
                        character4.transform.localScale = new Vector3(300, 300, 300);
                        unlockedCharactersNum ++;
                    }
                    break;
                case 5:
                    if (Square4.getUnlocked())
                    {
                        character5 = Instantiate(character5, transform.position, Quaternion.identity);
                        character5.transform.SetParent(characterContainer);
                        character5.transform.localScale = new Vector3(300, 300, 300);
                        unlockedCharactersNum ++;
                    }
                    break;
            }
        }
        characterContainer.sizeDelta = new Vector2(800 * unlockedCharactersNum, characterContainer.sizeDelta.y);
    }

    void Update()
    {
        characterSelect();
    }

    void characterSelect()
    {
        if (Input.GetMouseButton(0))
        {
            scrollValue = characterContainer.position.x;
        }
        else
        {
            for (int i = 1; i <= 2*unlockedCharactersNum; i+=2)
            {
                if (scrollValue < -2.31*i && scrollValue > -2.31*(i+1))
                {
                    characterContainer.position = new Vector3(Mathf.Lerp(characterContainer.position.x, (float)(-2.31*i), 0.1f), characterContainer.position.y, characterContainer.position.z);
                }
                else if (scrollValue < -2.31*(i+1) && scrollValue > -2.31*(i+2))
                {
                    characterContainer.position = new Vector3(Mathf.Lerp(characterContainer.position.x, (float)(-2.31*(i+2)), 0.1f), characterContainer.position.y, characterContainer.position.z);
                }
            }
            selectedCharacter = (int)((characterContainer.position.x/(-2.31))/2);
        }
    }
}
