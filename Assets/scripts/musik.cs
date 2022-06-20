using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musik : MonoBehaviour
{
    public Scrollbar s;
    // Start is called before the first frame update
    void Start()
    {
        if (VarSave.EnterFloat("mus"))
        {


            s.value = VarSave.GetFloat("mus");

        }
    }

        // Update is called once per frame
        void Update()
    {
        VarSave.SetFloat("mus",s.value);
        for (int i=0;i<GameObject.FindGameObjectsWithTag("game musig").Length;i++)
        {
            GameObject.FindGameObjectsWithTag("game musig")[i].GetComponent<AudioSource>().volume = VarSave.GetFloat("mus");
        }
    }
}
