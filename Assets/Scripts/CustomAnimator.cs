using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class CustomAnimator
{
    private Animator animator;
    private string currentAnimation;

    public CustomAnimator(Animator animator)
    {
        this.animator = animator;
    }
    
    public void ChangeAnimation(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimation = newAnimation;
    }
}
