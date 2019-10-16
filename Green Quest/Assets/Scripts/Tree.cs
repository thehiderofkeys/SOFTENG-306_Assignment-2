using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private static List<Tree> instances = new List<Tree>();
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        instances.Add(this);
    }
    public static void SetTreeEnabled(bool enabled)
    {
        foreach(Tree tree in instances)
        {
            if(tree.enabled)
                tree.GetComponent<InteractableController>().enabled = enabled;
        }
    }
    public void Plant()
    {
        animator.SetBool("Planted", true);
        RandomSpawnController.instance.SpawnGameObject();
        SetTreeEnabled(false);
    }
}
