namespace ConsoleApp1.Services
{
    public class AnalysisStrategyFactory
    {
        public IAnalysisStrategy CreateStrategy(AnalysisType analysisType)
        {
            switch (analysisType)
            {
                case AnalysisType.Mood:
                    return new MoodAnalysisStrategy();

                case AnalysisType.Emotions:
                    return new EmotionAnalysisStrategy();

                case AnalysisType.BodySensations:
                    return new BodySensationAnalysisStrategy();

                default:
                    return new MoodAnalysisStrategy();
            }
        }
    }
}