using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private static List<Tree> instances = new List<Tree>();
    private Animator animator;
    private bool isPlanted = false;
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
        isPlanted = true;
        animator.SetBool("Planted", true);
        SetTreeEnabled(false);
        if (!isAllTreesPlanted())
        {
            RandomSpawnController.instance.SpawnGameObject();
        }
        
    }
    public bool isAllTreesPlanted()
    {
        foreach(Tree tree in instances)
        {
            // Check if the instances are enabled. If they are enabled then its not a tree. 
            if (!tree.isPlanted)
            {
                return false;
            }
        }
        return true;
    }
}
