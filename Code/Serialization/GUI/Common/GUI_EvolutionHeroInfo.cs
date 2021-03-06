﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI_EvolutionHeroInfo : MonoBehaviour {

    public Image HeroSchool;
    public Image HeroIcon;
    public Text HeroLevel;
    public Text HeroName;
    public GameObject StarBar;

    void Awake()
    {
#if JIT && !UNITY_IOS
ScriptAssembly.Assemble(gameObject,"GUI_EvolutionHeroInfo_DL", this); // !!!不要删除，否则丢失逻辑组件
#else
        ScriptAssembly.Assemble<GUI_EvolutionHeroInfo_DL>(gameObject, this);
#endif
    }
}
