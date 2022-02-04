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

  public void Play(AnimationType type)
  {
      foreach (var animation in animationSetups)
      {
          if (animation.type == type)
          {
            animator.SetTrigger(animation.trigger);
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
}
