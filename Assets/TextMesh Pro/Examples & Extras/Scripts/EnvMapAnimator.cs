using UnityEngine;
using System.Collections;
using TMPro;

public class EnvMapAnimator : MonoBehaviour {

    //private Vector3 TranslationSpeeds;
    public Vector3 RotationSpeeds;
    private TMP_Text m_textMeshPro;
    private Material m_material;
    

    void Awake()
    {
        //Debug.Log("Awake() on Script called.");
        m_textMeshPro = GetComponent<TMP_Text>();
        m_material = m_textMeshPro.fontSharedMaterial;
    }

    // Use this for initialization
	IEnumerator Start ()
    {
        Matrix4x4 matrix = new Matrix4x4(); 
        
        while (true)
        {
            //matrix.SetTRS(new Vector3 (GlobalTimer.time * TranslationSpeeds.x, GlobalTimer.time * TranslationSpeeds.y, GlobalTimer.time * TranslationSpeeds.z), Quaternion.Euler(GlobalTimer.time * RotationSpeeds.x, GlobalTimer.time * RotationSpeeds.y , GlobalTimer.time * RotationSpeeds.z), Vector3.one);
             matrix.SetTRS(Vector3.zero, Quaternion.Euler(Time.time * RotationSpeeds.x, Time.time * RotationSpeeds.y , Time.time * RotationSpeeds.z), Vector3.one);

            m_material.SetMatrix("_EnvMatrix", matrix);

            yield return null;
        }
	}
}
