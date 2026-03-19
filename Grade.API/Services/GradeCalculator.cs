using Grade.Common.Interfaces;

namespace Grade.API.Services;

public class GradeCalculator : IGradeCalculator
{
    public string CalculateGrade(int percentage)
    {
        if (percentage < 0 || percentage > 100)
        {
            return "Invalid Score";
        }

        return percentage switch
        {
            >= 90 => "A",
            >= 80 => "B",
            >= 70 => "C",
            >= 60 => "D",
            _ => "F"
        };
    }
}