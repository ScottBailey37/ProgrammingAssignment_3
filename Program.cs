/* CODE OF HONOR: I have not discussed the source code in my program with anyone other than my 
 * instructor’s approved human sources. I have not used source code obtained from another student, 
 * or any other unauthorized source, either modified or unmodified. If any source code or documentation 
 * used in my program was obtained from another source, such as a textbook or course notes, that 
 * has been clearly noted with a proper citation in the comments of my program. I have not knowingly 
 * designed this program in such a way as to defeat or interfere with the normal operation of any 
 * machine it is graded on or to produce apparently correct results when in fact it does not. */
 
using System;


namespace ProgrammingAssignment_3_CSIS209
{
    class Program
    {        
        /// <summary>
        /// Provides simulation of rolling two dice a given number of times
        /// and printing the results of the possible roll combinations.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Declare variables
            Random rndNum = new Random(); //Initialize our random number generator
            int lower = 1; // Set lower limit to the minimum number we want
            int upper = 7; // Set upper limit to 1 number higher than max number we want
            int offset = 2; // Used to offset for correct array element
            int die1 = 0; // Holds value for first die
            int die2 = 0; // Holds value for second die            
            int results; // Holds results of the sum of the dice
            int totalRolls = 36000; // The number of times the dice will roll

            // Initialize array to tally results of dice sum
            // NOTE: The array length is dynamic. It will change based upon the variable 'upper', 
            //       which is set for the random number generator's upper limit. Though not required,
            //       it is good programming practice. Since we are summing the dice, we can multiple
            //       by 2. Though, any other mathematic operation could change this.
            int[] tally = new int[(((upper * 2) - 1) - offset)];
            
            // Keep rolling dice until totalRolls is reached            
            for (int count = 0; count < totalRolls; count++)
            {
                // Get a random number for each die
                die1 = rndNum.Next(lower, upper);
                die2 = rndNum.Next(lower, upper);   

                // Add the dice together and store the sum
                results = (die1 + die2);                                 

                // Get the appropiate array element and increment
                // NOTE: Since the results of the sum of our dice will be offset 2 digits from
                //       the correct array element that we want to increment, simply subtract
                //       the offset from the results to get the proper element in the array.
                tally[results - offset] += 1;
            }

            // Print the headers of two columns
            Console.WriteLine("Roll\tCount");

            // Print out the value of every element of the tally array
            for (int i = 0; i <= tally.GetUpperBound(0); i++)
            {
                // Print the roll combination and number of times generated
                Console.WriteLine("{0}\t {1}", (i + 2).ToString(), tally[i].ToString());
            }

            // Await user
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }       
    }
}
