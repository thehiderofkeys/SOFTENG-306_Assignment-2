using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueContainer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Level1Dialogue Level1Dialogue = new Level1Dialogue();
        
        string[] level1List = Level1Dialogue.getDialogue();

        /**not quite sure how we want to handle this within the context of the other components
        */
        // foreach(var level1List in level1List) {  
        //         Console.WriteLine(level1List);  
        // } 
        //Console.ReadKey();



    }
}


public struct Level1Dialogue
{
    string[] dialogueArray;
    private int counter;
    
    public void creatLevel1Dialogue(string name) {
        string[] stringArray = {
         "H-Hello? Is there anyone there?",
         ". . .",
         "Hello "+name+" , do not be frightened it is just me Greta the Wizard.",
         "I haven’t met you before. Where did you come from? What are you doing in my room???",
         " I am sorry if I startled you but there is no need to be worried about my intentions as I am here to help you " 
         +name+". I have come from the future to warn you about a great threat.",
         "Help me? Why me? I think I’ll be ok without the help of a stranger.",
         "It’s not just you "+name+" but the whole world needs your help. "
         +"In the future there is a mysterious evil force that ruins the whole planet. It becomes . . . uninhabitable to all. The only way to stop it is for you to act now, in the present before it’s too late.",
         "Oh wow that sounds pretty terrible. But why me? What can I possibly do to help? I am just a kid, shouldn’t more powerful people be trying to help?",
         "It’s hard to explain. Even though I am not quite sure who this evil character is I am sure that it is connected to you in some way. My magical powers are telling me that this evil enviromental force cannot be stopped unless YOU act now. ",
         "Hmmmm . . . well if your wizard powers are strong enough to let you travel back in time then I am sure we can trust them. What can I do to help?",
         "Great! I am so happy you decided to help. Ok, to start we are going to need to follow the malevolent figure’s path of environmentally unsustainable destruction.",
         "Alright, where does this path start? ",
         ". . . ",
         "My powers are telling me it starts very close by. I think a good place to start would be to undo all of their bad influences in your house.",
         "They've been in my house???",
         "I’m not sure . . . ",
         "Either way, I know that all of these small changes will add up in the end. We cannot conquer this problem all at once but instead we need to work on it in small consistent ways.",
         "Oh! So all of these small changes will add up in the end? ",
         "Exactly! That way you can stop the evil force before it gets too out of control. ",
         "Alright then Greta where can I get started?",
         "Let’s start easy by turning off all of the lights and taps in your house. This will be a great starting step to beating the mysterious villain and everything they have set in motion so far. ",
         "That's easy!",
         "It is pretty easy but setting up these small habits are going to be very important for the future. ",
         "Great! Let’s do it.",
      };
        dialogueArray = stringArray;
        counter = 0;
    }

    public string[] getDialogue(){
        return dialogueArray;
    }

}



