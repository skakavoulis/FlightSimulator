namespace FlightSimulator
{
    internal interface IApplicationUi
    {
        void RenderView();
        void ClearView();
        void RenderControls();
        int GetUserControlOption();
        void FlyUp();
        void FlyDown();
    }
}