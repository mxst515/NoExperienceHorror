using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class OutroCutsceneScript : MonoBehaviour
{
    public PlayableDirector director;
    public string sceneToLoad = "MainMenu";

    private void OnEnable()
    {
        if (director != null)
            director.stopped += OnCutsceneFinished;
    }

    private void OnDisable()
    {
        if (director != null)
            director.stopped -= OnCutsceneFinished;
    }

    private void OnCutsceneFinished(PlayableDirector obj)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
