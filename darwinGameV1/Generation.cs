using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darwinGameV1
{
    internal class Generation
    {
        int generationNumber;

        int str;
        int def;
        int size;

        int pop;

        string habitat;
        string diet;


        public Generation(int generationNumber, int str, int def, int size, int pop, string habitat, string diet)
        {
            this.generationNumber = generationNumber;
            this.str = str;
            this.def = def;
            this.size = size;
            this.pop = pop;
            this.habitat = habitat;
            this.diet = diet;
        }

        public int GenerationNumber()
        {
            return generationNumber;
        }

        public int GenerationStrength()
        {
            return str;
        }

        public int GenerationDefence()
        {
            return def;
        }

        public int GenerationSize()
        {
            return size;
        }

        public int GenerationPop()
        {
            return pop;
        }

        public string GenerationDiet()
        {
            return diet;
        }

        public string GenerationHabitat()
        {
            return habitat;
        }

    }
}
