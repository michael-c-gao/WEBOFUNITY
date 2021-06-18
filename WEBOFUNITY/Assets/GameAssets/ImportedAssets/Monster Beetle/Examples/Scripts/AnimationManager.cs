using UnityEngine;
using UnityEngine.UI;

public class AnimationManager : MonoBehaviour
{
    private Animator _animator;

    private int _index;
    private AnimationClip[] _animations;

    private Text _text;


    void Start()
    {
        _animator = GameObject.Find("Monster Beetle").GetComponent<Animator>();

        _animations = _animator.runtimeAnimatorController.animationClips;

        _text = GameObject.Find("CurrentAnimationText").GetComponent<Text>();

        _text.text = _animations[_index].name;
    }

    public void Next()
    {
        if (_index++ >= _animations.Length - 1) _index = 0;

        _animator.Play(_animations[_index].name);

        _text.text = _animations[_index].name;

    }



}
