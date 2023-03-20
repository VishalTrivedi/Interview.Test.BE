namespace GraduationTracker.Entities
{
    public class GraduationResult
    {
        public bool HasGraduated { get; set; }

        public STANDING Standing { get; set; }

        public GraduationResult(bool hasGraduated, STANDING standing)
        {
            HasGraduated = hasGraduated;
            Standing = standing;
        }
    }
}
