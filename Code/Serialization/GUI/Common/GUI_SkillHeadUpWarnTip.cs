// TODO：确保此文件中使用到的类型已经存在
public class GUI_SkillHeadUpWarnTip : UnityEngine.MonoBehaviour
{
    public UnityEngine.GameObject _WarnTip = null;
    public UnityEngine.RectTransform _WarnTipTrans = null;
    public GUI_TweenAlpha _AlphaTweener = null;
    public UnityEngine.UI.Text _SkillName = null;
    public float _HeadUpDistance = 0;
    void Awake()
    {
#if JIT && !UNITY_IOS
ScriptAssembly.Assemble(gameObject,"GUI_SkillHeadUpWarnTip_DL", this); // !!!不要删除，否则丢失逻辑组件
#else
        ScriptAssembly.Assemble<GUI_SkillHeadUpWarnTip_DL>(gameObject, this);
#endif
    }
}