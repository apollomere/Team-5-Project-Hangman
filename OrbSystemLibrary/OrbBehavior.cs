using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBehavior : MonoBehaviour
{
    //Object References
    public OrbArray OrbArrayRef;
    //Object References

    //Variables
    public Vector3 scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
    public char words;
    //Variables

    //OrbBehavior Methods
    void OnMouseDown()
    {
        gameObject.tag = ("SelectOrb"); //This will change the tag of the clicked orb. So 1 of the 3 stays.

        for (int i = 0; i < 3; i++) //For loop iterates through GameObject array(orbArrayRef)
        {
            if (OrbArrayRef.orbs[i].CompareTag("SelectOrb") == false) //If 1 of the 3 indices don't have "SelectOrb" it gets destroyed.
            {
                Destroy(OrbArrayRef.orbs[i]);
            }
        }
    }
    //Or Behavior Methods
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "SelectOrb") //Changes size of orb at run-time.
        {
            gameObject.transform.localScale = scaleChange;
        }

        //OrbBehavior once growing, instantiates letter words.
        //Letter words(characters), are made, which appear as letters(we should try 5)
        // character array, should contain random words, but also try to initialize with words that
        //are in the chosen word.


    }
}
