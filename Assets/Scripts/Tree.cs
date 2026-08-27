using UnityEngine;

public class Tree : MonoBehaviour
{

    private MeshRenderer rd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rd = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        rd.material.color = Color.red;

        Player player = collision.gameObject.GetComponent<Player>();
        
        if (player == null) 
          
            return;

        // use the instance, not the type
        player.HP -= 15;
        UIManager.instance.ShowNotiText($"Hurt -15\nHP: {player.HP}");

        if (player.HP <= 0)
        {
            player.HP = 0;
            UIManager.instance.ShowNotiText($"You are dead!!!\nPoints: {player.Point}");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Color takes floats 0..1; use Color32 if you have 0..255 values
        rd.material.color = new Color32(111, 60, 10, 255);
    }
}
