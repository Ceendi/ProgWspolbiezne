using System.Collections.ObjectModel;

namespace Model
{
    public abstract class IModelAPI
    {
        public static IModelAPI CreateApi()
        {
            ModelAPI model = new ModelAPI();
            return model;
        }

        public abstract ObservableCollection<BallModel> GetBalls();
        public abstract void Start(double height, double width, int ballCount);
        public abstract void SetHeight(double height);
        public abstract void SetWidth(double width);
        public abstract void Stop();
    }
}
