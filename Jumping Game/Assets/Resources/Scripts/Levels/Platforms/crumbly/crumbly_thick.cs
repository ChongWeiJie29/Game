using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crumbly_thick : thick
{
    [SerializeField]
    private GameObject num1, num2, num3;
    private float destroyTime = crumbly_standard.destroyTime;
    private bool destroying = false;
    private Vector2 characterPosition;

    public override void Start()
    {
        base.Start();
        num1.SetActive(false);
        num2.SetActive(false);
        num3.SetActive(false);
    }

    public override void Update()
    {
        base.Update();
        characterPosition = Level1.selectedCharacterCollider.gameObject.transform.position;
        collisionCheck();
    }

    void collisionCheck()
    {
        Vector2 platformPosition = platform.transform.position;
        Vector2 platformExtents = platform.GetComponent<BoxCollider2D>().bounds.extents;
        Vector2 characterExtents = Level1.selectedCharacterCollider.gameObject.GetComponent<BoxCollider2D>().bounds.extents;

        float platformTop = platformPosition.y + platformExtents.y - 0.015f;
        float characterBottom = characterPosition.y - characterExtents.y + 0.015f;

        if(platform.GetComponent<BoxCollider2D>().IsTouching(Level1.selectedCharacterCollider) && characterBottom >= platformTop)
        {
            if(!destroying)
            {
                StartCoroutine(destroyPlatform());
            }
        }
    }

    IEnumerator destroyPlatform()
    {
        destroying = true;

        num3.SetActive(true);
        yield return new WaitForSeconds(destroyTime/3);
        num3.SetActive(false);

        num2.SetActive(true);
        yield return new WaitForSeconds(destroyTime/3);
        num2.SetActive(false);
        
        num1.SetActive(true);
        yield return new WaitForSeconds(destroyTime/3);
        num1.SetActive(false);

        platform.SetActive(false);
    }
}
