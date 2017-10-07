using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

    // Controlls backend stuff for players e.g score or AI/Bot

    int score;
    bool isBot;
    public void Initiliaze(bool botControlled)
    {
        score = 0;

        if (botControlled)
        {
            isBot = true;
        }
    }



}
