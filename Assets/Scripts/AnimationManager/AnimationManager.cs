using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;
    public List<AnimatorSetup> animationSetups;

  public enum AnimationType
  {
      IDLE,
      RUN,
      DEAD
  }

  public void Play(AnimationType type, float currentSpeedFactor = 1f)
  {
      foreach (var animation in animationSetups)
      {
          if (animation.type == type)
          {
            animator.SetTrigger(animation.trigger);
            animator.speed = animation.speed * currentSpeedFactor;
          }
      }
  }

  private void Update() 
  {
      if(Input.GetKeyDown(KeyCode.Alpha1))
      {
          Play(AnimationType.RUN);
      }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
      {
          Play(AnimationType.DEAD);
      }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
      {
          Play(AnimationType.IDLE);
      }
  }
}

[System.Serializable]
public class AnimatorSetup
{
    public AnimationManager.AnimationType type;
    public string trigger;
    public float speed = 1f;
}
