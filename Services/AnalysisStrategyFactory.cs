namespace ConsoleApp1.Services
{
    public class AnalysisStrategyFactory
    {
        public IAnalysisStrategy CreateStrategy(AnalysisType analysisType)
        {
            switch (analysisType)
            {
                case AnalysisType.Настроение:
                    return new MoodAnalysisStrategy();

                case AnalysisType.Эмоции:
                    return new EmotionAnalysisStrategy();

                case AnalysisType.ТелесныеОщущения:
                    return new BodySensationAnalysisStrategy();

                default:
                    return new MoodAnalysisStrategy();
            }
        }
    }
}