using System;
namespace Quiz
{
    public class Options
    {
        private string OptionA;
        private string OptionB;
        private string OptionC;
        private string OptionD;
        public Options(string OptionA, string OptionB, string OptionC, string OptionD)
        {
            this.OptionA = OptionA;
            this.OptionB = OptionB;
            this.OptionC = OptionC;
            this.OptionD = OptionD;
        }
        public string writeOptions() {
            string writeOptions=(OptionA + " " + OptionB + "\n" + OptionC + " " + OptionD);
            return writeOptions;
                }
        public string getOptionA()
        {
            return OptionA;
        }
        public string getOptionB()
        {
            return OptionB;
        }
        public string getOptionC()
        {
            return OptionC;
        }
        public string getOptionD()
        {
            return OptionD;
        }
    }
}