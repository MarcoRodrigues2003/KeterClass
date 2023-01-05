using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Código da classe criada para facilitar o funcionamento do save system
[System.Serializable]
public class PlayerData
{
    public string Level;

    public PlayerData (canvasmanagerL2 canvasmanagerL2)
    {
        Level = canvasmanagerL2.thisScene as string;
    }

}
