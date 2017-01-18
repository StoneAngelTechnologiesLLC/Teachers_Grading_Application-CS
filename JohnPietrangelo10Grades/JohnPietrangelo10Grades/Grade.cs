//John Pietrangelo 9am Tues/Thurs.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnPietrangelo10Grades
{
    class Grade
    {   
        //Object Variables
        private double[] earnedScores;
        private double pointTotal;
        private int scoresEntered; //
       
             
        ////Defult Constructor
        //public Grade()
        //{
        //}

        //Overloaded Constructor

        public Grade(double total, out double [] scores )
        {
            pointTotal = total;
            scores = new double[30];
            earnedScores = scores; //setting actor's entered Progam class's  'scores' into
        }                          //the Grade class's varible 'scoresEntered'.  
       
        ////Instance Methods
        //public void SetPointTotal(int total)
        //{
        //    pointTotal = (double)total; //using double to type cast an int into a double
        //}
        //public void SetPointTotal(double total) // Overloaded method for SetPointTotal
        //{
        //    pointTotal = total;
        //}


        //Instance method
        public void ClearScores()
        {   /*Clear number of scores previously entered
              Reset all elements of the array back to zero*/
            scoresEntered = 0;
            for (int i = 0; i < earnedScores.Length; i++)
            {
                earnedScores[i] = 0.0;
            }
        }


        public void EnterScores(string category)
        {
            //Loop that lets the user enter up to 30 scores
            //the loop ends after 30 entries or Q is pressed
            do
            {   //Method Variables
                string input;
                double inputNumber;
                
                //Clear screen
                Console.Clear();
 
                //scoreType is a string passed in that prints to the screen to help user know what scores are being entered
                Console.WriteLine("{0,27}{1} Scores***\n", "***", category);
                Console.WriteLine("{0,15}Enter up to {1} scores or 'Q' to quit.\n", "", earnedScores.Length);
                Console.Write("{0} Score {1}: ", category, scoresEntered + 1);
                input = Console.ReadLine();

                //Validate user entered string stored in input.
                //Return -2 if Q was pressed and -1 if the string is invalid
                inputNumber = ValidateScore(input);
                if (inputNumber == -1)
                {
                    Console.WriteLine("Invalid entry.  Please enter a valid positive score.");
                    Console.ReadKey();
                }
                else if (inputNumber == -2)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    earnedScores[scoresEntered] = inputNumber;
                    scoresEntered++;
                }
            } while (scoresEntered < earnedScores.Length);
        }

        //Instance method(no static)
        public double ValidateScore(string inText)
        {   //Method Variables.
            int bulletCount;
            char[] temp;

            //Variable to hold the count of decimals
            bulletCount = 0;

            //**char array to hold incoming string
            temp = inText.ToCharArray();

            //text is not blank if length greater than zero
            if (inText.Length > 0)
            {   //loop thru each character and test contents
                for (int i = 0; i < inText.Length; i++)
                {   //is it a decimal
                    if (temp[i] == '.')
                    {   //dotCount++; does the same thing
                        bulletCount += 1;
                        if (bulletCount > 1) //More than 1 decimal invalid
                            return -1;
                    }//if Negative sign
                    else if (temp[i] == '-')
                    {   //If Negative is not 1st element of array then invalid
                        if (i != 0)
                            return -1;
                    }//**If character is not a number
                    else if (!char.IsNumber(temp[i]))
                    {   //If Q or q then exit loop
                        if (temp[i] == 'Q' || temp[i] == 'q')
                        {
                            return -2;
                        }//Any other letter invalid
                        else
                        {
                            return -1;
                        }
                    }
                }
            }
            else
            {   //Blank was entered
                return -1;
            }//Returns validated string to double format before returning to the calling program method
            return Convert.ToDouble(inText);
        }

        //Instance method.
        public void DisplayScore(string scoreType)
        {
            //scoreType is a string passed in that prints to the screen to help user know what scores are being displayed
            Console.WriteLine("\n{0,40} Scores\n{1}", scoreType
                             ,"--------------------------------------------------------------------------------\n");
            
            //Loop thru the earnedScores array and print each element's value
            for (int i = 0; i < scoresEntered; i++)
            {
                Console.WriteLine("{2,31}Score{0}: {1,10:###.00} Points\n", i + 1, earnedScores[i],scoreType);
            }
        }
       
        //Instance method(no static)
        public double GetGradePercent()
        {   //Method Variables.
            double totalEarnedPoints;
            double gradePercentage;
            
            //Start with zero
            totalEarnedPoints = 0;
 
            //Add all elements of the array to total
            for (int i = 0; i < scoresEntered; i++)
            {
                totalEarnedPoints += earnedScores[i];
            }
            //Return grade percentage by dividing earned points by total points
            gradePercentage = totalEarnedPoints / pointTotal;
            return gradePercentage;
        }
        //Instance method(no static)
        public string GetLetterGrade(double percentage)
        {
            /*Incoming parameter will be in decimal format. Example 90% will be 0.90
              Multiply incoming percentage by 100 to move decimal point scaling number from 0 to 100*/
            percentage *= 100; 

            if (percentage >= 97.0)
            {
                return "A+";
            }
            else if ((percentage < 97) && (percentage >= 93))
            {
                return "A";
            }
            else if ((percentage < 93) && (percentage >= 90))
            {
                return "A-";
            }
            else if ((percentage < 90) && (percentage >= 87))
            {
                return "B+";
            }
            else if ((percentage < 87) && (percentage >= 83))
            {
                return "B";
            }
            else if ((percentage < 83) && (percentage >= 80))
            {
                return "B-";
            }
            else if ((percentage < 80) && (percentage >= 77))
            {
                return "C+";
            }
            else if ((percentage < 77) && (percentage >= 70))
            {
                return "C";
            }
            else if ((percentage < 70) && (percentage >= 60))
            {
                return "D";
            }
            else
            {
                return "E";
            }
        }
       
        }
    }

