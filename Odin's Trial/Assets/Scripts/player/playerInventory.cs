using UnityEngine;
using UnityEngine.UI;

public class playerInventory : MonoBehaviour
{
    public float woodCount;
    public Text scoreCount;
    public fireLife fire;
    // Start is called before the first frame update
    void Start()
    {
        woodCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreCount.GetComponent<Text>().text = woodCount.ToString();
        removeWood();
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wood")
        {
            Debug.Log("Hit Wood");
            woodCount = woodCount + 1;

        }
    }

    void removeWood()
    {
        if (fire.playerInteracted == true)
        {

            woodCount = woodCount - 1;


        }



    }

}
