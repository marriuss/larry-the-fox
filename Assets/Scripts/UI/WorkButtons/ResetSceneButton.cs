public class ResetSceneButton : WorkButton
{
    protected override void OnButtonClick()
    {
        SceneResetter.ResetScene();
    }
}
