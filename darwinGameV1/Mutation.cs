using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace darwinGameV1
{
    internal class Mutation
    {
        string mutationName;
        string outputMessage;
        int defenceChange;
        int strengthChange;
        int sizeChange;

        bool waterOnly;
        bool landOnly;

        public Mutation(string mutName, string displayText, int def, int str, int size, bool isWet, bool isDry)
        {
            mutationName = mutName;

            outputMessage = displayText;

            defenceChange = def;
            strengthChange = str;
            sizeChange = size;

            waterOnly = isWet;
            landOnly = isDry;
        }

        public string MutationName()
        {
            return mutationName;
        }

        public string OutputMessage()
        {
            return outputMessage;
        }

        public int DefenceChange()
        {
            return defenceChange;
        }

        public int StrengthChange()
        {
            return strengthChange;
        }

        public int SizeChange()
        {
            return sizeChange;
        }       

        public bool WaterOnly()
        { 
            return waterOnly;
        }

        public bool LandOnly()
        {
            return landOnly;
        }
    }
}
