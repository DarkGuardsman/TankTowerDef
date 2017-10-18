using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    public Player player;

    public bool IsControlPaused()
    {
        return player == null || !player.enabled || player.pauseGame;
    }
}
