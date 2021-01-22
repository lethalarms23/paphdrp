using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeonChange : MonoBehaviour
{
    public Color cor;
    public Light NeonFrente;
    public Light NeonDireita;
    public Light NeonEsquerda;
    public Light NeonTras;

    void Start(){
        NeonFrente.GetComponent<Light>();
        NeonDireita.GetComponent<Light>();
        NeonEsquerda.GetComponent<Light>();
        NeonTras.GetComponent<Light>();
    }

    public void FixedUpdate() {
        NeonFrente.color = cor;
        NeonDireita.color = cor;
        NeonEsquerda.color = cor;
        NeonTras.color = cor;
    }
}
