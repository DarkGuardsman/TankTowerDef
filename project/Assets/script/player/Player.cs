using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour 
{
    [SyncVar]
    string playerName = "player";
    
    public GameObject playerCamera;  

    public TextMesh playerNameText;

    public bool pauseGame = false;
    bool wasGamePaused = false;

    //Use this to setup the object rather than start
    void OnEnable()
    {
        
    }

    // Use this for initialization
    void Start()
    {
        //https://www.youtube.com/watch?v=wvUNXkrEMys Add smooth camera following
        if (isLocalPlayer)
        {
            EnablePlayerScripts(gameObject, true);
            playerCamera.SetActive(true);
        }
    }

    //Called each frame update
    void Update()
    {
        if (playerNameText != null)
        {
            playerNameText.text = playerName;
        }

        //Handle screen unlock
        if (Input.GetKeyDown("escape"))
        {
            pauseGame = !pauseGame;
            TogglePauseState();
        }
        if(IsMouseOffScreen())
        {
            pauseGame = true;
            TogglePauseState();
        }
    }

    void TogglePauseState()
    {
        //Handle screen lock state change
        if (!wasGamePaused && pauseGame)
        {
            wasGamePaused = true;
            PauseGame();
        }
        else if (wasGamePaused && !pauseGame)
        {
            wasGamePaused = false;
            ResumeGame();
        }
    }

    bool IsMouseOffScreen()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float screenX = Screen.width;
        float screenY = Screen.height;

        return (mouseX == 0 || mouseY == 0 || mouseX >= Screen.width - 1 || mouseY >= Screen.height - 1);
    }

    void SetCursorState(CursorLockMode wantedMode)
    {
        Cursor.lockState = wantedMode;
        Cursor.visible = (CursorLockMode.Locked != wantedMode);
    }

    void ResumeGame()
    {
        Debug.Log("Player: Resumed game control");
        SetCursorState(CursorLockMode.Locked);
        EnablePlayerScripts(gameObject, true);
        //TODO enable in game screen
        //TODO disable esc screen
    }

    void PauseGame()
    {
        Debug.Log("Player: Paused game control");
        SetCursorState(CursorLockMode.None);
        EnablePlayerScripts(gameObject, false);
        //TODO hide or fade in game screen
        //TODO enable esc screen
    }

    void OnDeath()
    {
        //TODO switch to free camera
    }
    
    [Command]
    public void CmdChangeName(string newName)
    {
        playerName = newName;
    }

    [Command]
    public virtual void CmdSpawn(GameObject bulletPrefab, GameObject spawnPoint, float velocity, float deathTimer)
    {
        GameObject spawn = (GameObject)Instantiate(bulletPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);

        spawn.GetComponent<Rigidbody>().velocity = spawn.transform.forward * velocity;

        NetworkServer.Spawn(spawn);

        if (deathTimer >= 0)
        {
            Destroy(spawn, deathTimer);
        }
    }

    void EnablePlayerScripts(GameObject parent, bool enable)
    {
        foreach (Component o in parent.GetComponents<Component>())
        {
            if (o)
            {
                if (o is PlayerControl)
                {
                    ((PlayerControl)o).enabled = enable;
                    ((PlayerControl)o).player = this;
                }
            }
        }
        foreach (Transform t in parent.transform)
        {
            if (t != null && parent.transform != t)
            {
                EnablePlayerScripts(t.gameObject, enable);
            }
        }
    }

    GameObject GetGameObject(string name)
    {
        Transform transform = this.transform.Find(name);
        if (transform)
        {
            return transform.gameObject;
        }
        return null;
    }
}
