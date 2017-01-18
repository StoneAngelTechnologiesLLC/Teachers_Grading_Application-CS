//John Pietrangelo 9am Tues/Thurs.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnPietrangelo10Grades
{
    class Program
    {
       static void Main(string[] args)
        {   //Local Variables
            bool repeatCategory = true;
            double[] categories = { 200, 500, 100, 100 };
            //double exam = 200;
            //double homework = 500;
            //double quiz = 100;
            //double project = 100;
            string categoryName = "";
            double[] scores;
            
            //To create an array of new objects or instances    (Object is courseGrade).
            Grade[] courseGrades = {new Grade(categories[0],out scores),new Grade(categories[1],out scores),
                                    new Grade(categories[2],out scores), new Grade(categories[3],out scores)};

           //Application starting point.
            do
            {   //Statement To label each grade category
                for (int i = 0; i < 4; i++)
                {
                    switch (i)
                    {
                        case 0:
                          categoryName =  "Exam";
                            break;
                        case 1:
                            categoryName = "Homework";
                            break;
                        case 2:
                            categoryName = "Quiz";
                            break;
                        default:
                            categoryName = "Project";
                            break;
                    }
                    do
                    {   //Call to Program class method, to clear scores if revision is needed.
                        courseGrades[i].ClearScores();
                        //Call to Grade class method, to input data.
                        courseGrades[i].EnterScores(categoryName);
                        //Call to Grade class method, to display entered data.
                        courseGrades[i].DisplayScore("Entered " + categoryName);
                        //Call to Program class to make category transition. 
                        repeatCategory = GetCategoryTransition();
                    } 
                    while (repeatCategory);
                }//Call to Program class, to display final scores and grades. 
                DisplayFinalScore(courseGrades[0], courseGrades[1], courseGrades[2], courseGrades[3]);
                //Call to Program class, to to either exist or reapeat application. 
                repeatCategory = GetNewStudent(courseGrades[0], courseGrades[1], courseGrades[2], courseGrades[3]);
            } 
            while (repeatCategory);
        }//Application ending point. End of Main method.

        //Newly created Program class methods
        public static bool GetCategoryTransition()
        {// To determine whether or not to revise entered scores.
            string input = "";
            Console.WriteLine("\n\t  <<<Press 'R' To Revise Or Any Other Key To Continue>>>");

            input = (Console.ReadLine().ToLower());
            if (input == "r")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void DisplayFinalScore(Grade exam, Grade homework, Grade quiz, Grade project)
        {//To display overall scores.
            //Clears screen.
            Console.Clear();

            double courseScore = ((40 * exam.GetGradePercent()) + (20 * homework.GetGradePercent())
                                 +(30 * quiz.GetGradePercent()) + (10 * project.GetGradePercent()));
            double courseLetterGrade = (courseScore / 100);

            //Displays cumulative scores & grades by category.
            Console.WriteLine("\t\t     ***Total Score & Grade By Category***\n");
            Console.WriteLine("\t\t\t     Exams: {0,10:###.00}%  {1}", exam.GetGradePercent() * 100, exam.GetLetterGrade(exam.GetGradePercent()));
            Console.WriteLine("\t\t\t     Homework: {0,7:###.00}%  {1}", homework.GetGradePercent() * 100, homework.GetLetterGrade(homework.GetGradePercent()));
            Console.WriteLine("\t\t\t     Quizes: {0,9:###.00}%  {1}", quiz.GetGradePercent() * 100, quiz.GetLetterGrade(quiz.GetGradePercent()));
            Console.WriteLine("\t\t\t     Project: {0,8:###.00}%  {1}", project.GetGradePercent() * 100, project.GetLetterGrade(project.GetGradePercent()));
            //Displays total course score & grade.
            Console.WriteLine("\n\t\t\t ***Total Course Score & Grade***");
            Console.WriteLine("\n\t\t     Overall Course Score & grade is: {0:###.00}%  {1}", courseScore, project.GetLetterGrade(courseLetterGrade));
        } 
  




        public static bool GetNewStudent(Grade taco, Grade burrito, Grade toastada, Grade temale)
        {//To determine whether or not to run program again.
            string input = "";
            //To countinue to next student or to exit.
            Console.WriteLine("\n--------------------------------------------------------------------------------\n"
                                       + "      Press 'E' To Exit or Any Other Key To Input Scores For Next Student");
            input = (Console.ReadLine().ToLower());

            //Exits program if 'E' is entered.  
            if (input == "e")
            {
                return false;
            }
            else
            {
                //program resets stored data to 0 if any other key besides 'E' is entered.
                taco.ClearScores();
                burrito.ClearScores();
                toastada.ClearScores();
                temale.ClearScores();
                return true;
            }
        }
    }
 
}
