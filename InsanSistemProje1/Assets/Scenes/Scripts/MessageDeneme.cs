using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MessageDeneme : MonoBehaviour
{
    // static reference to message manager so can be called from other scripts directly (not just through gameobject component)
    public static MessageDeneme mm;
    // game performance
    public string pMessage = "Player Message:";
    // UI elements to control
    public Text UIPlayerMessages;
    // set things up here
    void Awake()
    {
        // setup reference to message manager
        if (mm == null)
            mm = this.GetComponent<MessageDeneme>();
        // setup all the variables, the UI, and provide errors if things not setup properly.
        setupDefaults();
    }
    // setup all the variables, the UI, and provide errors if things not setup properly.
    void setupDefaults()
    {
        // get the UI ready for the game
        refreshGUI();
    }
    void refreshGUI()
    {
       // UIPlayerMessages.text = pMessage;
    }
    //send messages to the player
    public void DoMessage(string message)
    {
        pMessage = message;
        Debug.Log("Got to DoMessage.");
    }
}
