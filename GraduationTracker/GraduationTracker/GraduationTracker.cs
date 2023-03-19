using System;
using GraduationTracker.DAL.Entities;

namespace GraduationTracker
{
    public partial class GraduationTracker
    // Vishal: Why is this a partial class?
    {
        // Vishal: Is Tuple the right data type for return?
        public Tuple<bool, STANDING> HasGraduated(Diploma diploma, Student student)
        {
            int average = CalculageAverageMarks(diploma.Requirements, student.Courses);

            switch (average)
            {
                case >= 95:
                    return new Tuple<bool, STANDING>(true, STANDING.SumaCumLaude);
                case >= 80:
                    return new Tuple<bool, STANDING>(true, STANDING.MagnaCumLaude);
                case >= 50:
                    return new Tuple<bool, STANDING>(true, STANDING.Average);
                case > 0:
                    return new Tuple<bool, STANDING>(false, STANDING.Remedial);
                default:
                    return new Tuple<bool, STANDING>(false, STANDING.None);
            }
        }

        private int CalculageAverageMarks(int[] requirements, Course[] studentCourses)
        {
            // Vishal: Credits is never used, why?
            var credits = 0;
            var totalMarks = 0;

            for (int i = 0; i < requirements.Length; i++)
            {
                for (int j = 0; j < studentCourses.Length; j++)
                {
                    var requirement = Repository.GetRequirement(requirements[i]);

                    for (int k = 0; k < requirement.Courses.Length; k++)
                    {
                        if (requirement.Courses[k] == studentCourses[j].Id)
                        {
                            totalMarks += studentCourses[j].Marks;

                            if (studentCourses[j].Marks > requirement.MinimumMark)
                            {
                                credits += requirement.Credits;
                            }
                        }
                    }
                }
            }
            
            return totalMarks / studentCourses.Length;
        }
    }
}
