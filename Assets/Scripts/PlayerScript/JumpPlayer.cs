using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JumpPlayer : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Animator animator;
    Pos pos;
    bool readyJump;

    private void Start()
    {
        pos = Pos.right;
        readyJump = true;
    }

    IEnumerator Jump()
    {
        if (readyJump)
        {
            ScorePlayer.ShiftScore();

            readyJump = false;
            string nameAnim;

            if (pos == Pos.right)
            {
                nameAnim = "JumpLeft";
                pos = Pos.left;
            }
            else
            {
                nameAnim = "JumpRight";
                pos = Pos.right;
            }

            animator.Play(nameAnim);
            yield return new WaitForSeconds(0.2f);
            readyJump = true;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(Jump());
    }
}

public enum Pos {left, right }