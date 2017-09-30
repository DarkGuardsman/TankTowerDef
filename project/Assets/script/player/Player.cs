using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour 
{
    [SyncVar]
    string playerName = "player";
    
    GameObject playerCamera;  

    TextMesh playerNameText;   
    
    void OnEnable()
    {
        playerCamera = GetGameObject("turret/MainCamera");
        GameObject obj = GetGameObject("turret/PlayerName");
        if (obj)
        {
            playerNameText = obj.GetComponent<TextMesh>();
        }
    }

    GameObject GetGameObject(string name)
    {
        Transform transform = this.transform.Find(name);
        if(transform)
        {
            return transform.gameObject;
        }
        return null;
    }
    
    void OnGUI()
    {
        if(isLocalPlayer)
        {
            playerName = GUI.TextField(new Rect (25, Screen.height - 40, 100, 30), playerName);
            if(GUI.Button(new Rect(130, Screen.height - 40, 80, 30), "Change"))
            {
                CmdChangeName(playerName);
            }
        }
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

    // Use this for initialization
    void Start () 
    {
        //https://www.youtube.com/watch?v=wvUNXkrEMys Add smooth camera following
		if(isLocalPlayer)
        {
            EnablePlayerScripts(gameObject);
            playerCamera.SetActive(true);
        }
	}

    void EnablePlayerScripts(GameObject parent)
    {
        foreach (Component o in parent.GetComponents<Component>())
        {
            if (o)
            {
                if (o is PlayerControl)
                {
                    ((PlayerControl)o).enabled = true;
                    ((PlayerControl)o).player = this;
                }
            }
        }
        foreach (Transform t in parent.transform)
        {
            if (t != null && parent.transform != t)
            {
                EnablePlayerScripts(t.gameObject);
            }
        }
    }
    
    void Update()
    {
        if(playerNameText != null)
        {
            playerNameText.text = playerName;
        }
    }
}
