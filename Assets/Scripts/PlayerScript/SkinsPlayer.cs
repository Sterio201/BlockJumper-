using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsPlayer : MonoBehaviour
{
    [SerializeField] List<Sprite> allSkins;
    SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public IEnumerator ShiftSkin(TypeControl typeControl)
    {
        animator.SetTrigger("Shift");
        yield return new WaitForSeconds(0.5f);
        transform.rotation = new Quaternion(0, 0, 0, 0);

        switch (typeControl)
        {
            case TypeControl.jump:
                spriteRenderer.sprite = allSkins[0];
                break;
            case TypeControl.rail:
                spriteRenderer.sprite = allSkins[1];
                break;
            case TypeControl.flight:
                spriteRenderer.sprite = allSkins[2];
                break;
        }
    }
}