using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private RuntimeAnimatorController normalController;
    [SerializeField] private RuntimeAnimatorController spiritController;
    private Animator animator;
    public bool isSpirit;

    [SerializeField] private float shiftCooldown = 1f;
    private float shiftTimer;
    void Start()
    {
        shiftTimer = 0;
        isSpirit = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shiftTimer -= Time.fixedDeltaTime;
        if(Input.GetKeyDown("f") && shiftTimer <= 0)
        {
            if (!isSpirit) 
            {
                animator.runtimeAnimatorController = spiritController;
                isSpirit = true;
            }
            else
            {
                animator.runtimeAnimatorController = normalController;
                isSpirit = false;
            }
            shiftTimer = shiftCooldown;
        }
    }
}
