using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderChange : HudListener {

    protected override void DoSomething(string message)
    {
        if(message == "Player1")
            GetComponent<Slider>().value--;
    }
}
