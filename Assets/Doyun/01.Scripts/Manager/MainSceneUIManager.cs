using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneUIManager : MonoBehaviour
{
    public static MainSceneUIManager Instance;

    [SerializeField] private Image _playerHp;

    [SerializeField] private Text[] _itemTexts = new Text[4];

    [SerializeField] private Text _phaseText;

    public void SetPlayerHp(float percent)
    {
        _playerHp.fillAmount = percent;
    }

    public void SetText(ElementType type, int count)
    {
        _itemTexts[(int)type].text = count.ToString();
    }

    public void SetPhase(bool val)
    {
        StartCoroutine(PhaseTextRoutine(val));
    }

    private IEnumerator PhaseTextRoutine(bool val)
    {
        _phaseText.text = $"{PhaseManager.Instance.CurPhase}페이즈가 {(val ? "시작되었습니다." : "종료되었습니다.")}";
        
        _phaseText.color = new Color(0, 0, 0, 1);

        yield return new WaitForSeconds(0.5f);

        float time = 2f;
        float cur = 0f;
        float percent = 0;

        while (percent <= 1)
        {
            cur += Time.deltaTime;

            percent = cur / time;

            _phaseText.color = new Color(0, 0, 0, 1 - percent);
            yield return null;
        }

        _phaseText.color = new Color(0, 0, 0, 0);
    }
}
