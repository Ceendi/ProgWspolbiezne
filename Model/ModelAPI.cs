using Data;
using Logic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Model
{
    public class ModelAPI : IModelAPI
    {
        private readonly ILogicAPI _logicAPI;

        public ModelAPI(ILogicAPI? logicAPI = null)
        {
            if (logicAPI == null)
            {
                _logicAPI = ILogicAPI.CreateAPI();
            } else
            {
                _logicAPI = logicAPI;
            }
        }

        public override ObservableCollection<BallModel> GetBalls()
        {
            ObservableCollection<BallModel> balls = new ObservableCollection<BallModel>();
            foreach (Ball ball in _logicAPI.GetBalls().Cast<Ball>())
            {
                balls.Add(new BallModel(ball));
            }

            return balls;
        }

        public override void SetHeight(double height)
        {
            _logicAPI.SetHeight(height);
        }

        public override void SetWidth(double width)
        {
            _logicAPI.SetWidth(width);
        }

        public override void Start(double height, double width, int ballCount)
        {
            _logicAPI.StartSimulation(height, width, ballCount);
        }

        public override void Stop()
        {
            _logicAPI.StopSimulation();
        }
    }
}
