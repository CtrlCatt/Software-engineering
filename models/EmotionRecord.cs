namespace ConsoleApp1.Models
{
    public class EmotionRecord
    {
        public EmotionType EmotionType { get; set; }
        public int Intensity { get; set; }
        public string Comment { get; set; } = string.Empty;

        
    }
}