using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TaskManager : MonoBehaviour
{
    [SerializeField]
    public AudioClip _audioClip;
    public AudioSource _audioSource;
    public TextAsset _textArea;
    public Animation _animation;
    public GameObject target;
    public InfoItem[] InfoItem;
    public View _currentInfoItem;
    public InfoItem currentInfoItem;
    public Text InfoText;
    public static TaskManager s_instance;

    [SerializeField] public View _startingView;

    [SerializeField] public View[] _elements;

    public View _currentView;

    public readonly Stack<View> _history = new Stack<View>();

    private bool sesOynat = false;

    public static T GetView<T>() where T : View
    {
        for (int i = 0; i < s_instance._elements.Length; i++)
        {
            if (s_instance._elements[i] is T tView)
            {
                return tView;
            }
        }

        return null;
    }

    public static void Show<T>(bool remember = true) where T : View
    {
        for (int i = 0; i < s_instance._elements.Length; i++)
        {
            if (s_instance._elements[i] is T)
            {
                if (s_instance._currentView != null)
                {
                    if (remember)
                    {
                        s_instance._history.Push(s_instance._currentView);
                    }

                    s_instance._currentView.Hide();
                }

                s_instance._elements[i].Show();

                s_instance._currentView = s_instance._elements[i];
            }
        }
    }

    public static void Show(View view, bool remember = true)
    {
        if (s_instance._currentView != null)
        {
            if (remember)
            {
                s_instance._history.Push(s_instance._currentView);
            }

            s_instance._currentView.Hide();
        }

        view.Show();

        s_instance._currentView = view;
    }

    public static void ShowLast()
    {
        if (s_instance._history.Count != 0)
        {
            Show(s_instance._history.Pop(), false);
        }
    }

    public void Awake() => s_instance = this;

    public void Start()
    {
        //for (int i = 0; i < _elements.Length; i++)
        //{
        //    _elements[i].Initialize();

        //    _elements[i].Hide();
        //}

        //if (_startingView != null)
        //{
        //    Show(_startingView, true);
        //}
    }
    private void Update()
    {
        if (currentInfoItem!=null)
        {
            InfoText.text = currentInfoItem.ObjeInfo;
            _audioSource.clip = currentInfoItem._audioClip;
            if(!_audioSource.isPlaying)
            _audioSource.Play();
        }
       
        
    }
    //private void Ses()
    //{
    //    if (!_audioSource.isPlaying)
    //    {
    //        _audioSource.clip = currentInfoItem._audioClip;
    //        _audioSource.Play();
    //        sesOynat = true;
    //    }
    //}
    ////
    //public static void currentInfoItem()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {

    //    }
    //}
}
