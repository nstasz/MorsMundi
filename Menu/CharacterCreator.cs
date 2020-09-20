using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterCreator : MonoBehaviour {

    public InputField localInput1, localInput2, localInput3, localInput4;

    

    public void OnSubmit()
    {


        PlrData.DefineVariables();




        PlrData.plr_total_count = int.Parse(GameObject.Find("PlrCountNumber").GetComponent<Text>().text);
        PlrData.plr_name[0] = "Hermes";      
        PlrData.plr_name[1] = "Aphrodite";
        PlrData.plr_name[2] = "Gaea";
        PlrData.plr_name[3] = "Selene";

        if (localInput1.text != "")
        {
            PlrData.plr_name[0] = localInput1.text;
        }
        if (PlrData.plr_total_count > 1)
        {
            if (localInput2.text != "") { 
                PlrData.plr_name[1] = localInput2.text;
            }
        }
        if (PlrData.plr_total_count > 2)
        {
            if (localInput3.text != "")
            {
                PlrData.plr_name[2] = localInput3.text;
            }
        }
        if (PlrData.plr_total_count ==4)
        {
            if (localInput4.text != "")
            { 
                PlrData.plr_name[3] = localInput4.text;

            }
        }
      
        SceneManager.LoadScene("Scenes/SolarSystem");
    }
        
}
