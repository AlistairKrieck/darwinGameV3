using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Diagnostics.Eventing.Reader;
using System.CodeDom;

namespace darwinGameV1
{
    //TO DO:
    //FIND SMTH FOR HERBIVORES TO BE UNIQUE
    //FIND SMTH FOR OMNIVORES TO BE UNIQUE

    //ALLOW THE ENVIRONMENT TO CHANGE
    //-type, region (land, sea), etc.

    //ADD RANDOM EVENTS
    //-tsunami, hurricane, drought, etc.
    //Add more negative events


    //ADD EVIRONMENT TYPES
    //-snowy, hot, dry, etc.

    //ADD NEW STATS
    //- Temperature / Insulation, ...

    //REBALANCE MUTATIONS <- Still Big

    public partial class darwin : Form
    {
        bool escDown = false;
        bool kDown = false;

        int currentGeneration = 0;

        int playerDefence = 0;
        int playerStrength = 0;
        int playerPopulation = 10;
        int playerSize = 1;

        string playerDietType = "null";
        string playerHabitat = "null";

        string causeOfDeath;

        int mutationPos;
        int eventPos;

        string gameState = "menu";

        List<Mutation> possibleMutations = new List<Mutation>();
        List<Event> possibleEvents = new List<Event>();
        List<Generation> generations = new List<Generation>();

        int environmentDefence = 0;
        int environmentStrength = 0;

        string creatureName;

        //TEST VARIABLES


        //TO BE ADDED / UTILISED
        int appendageCount = 0;
        bool appendageBuff = false;

        int eyeCount = 0;
        int eyeLimit = 8;

        List<string> currentMutations = new List<string>();


        public darwin()
        {
            InitializeComponent();
            GameInit();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        if (gameState == "menu")
                        {
                            if (nameBox.Text != "")
                            {
                                gameState = "running";
                                creatureName = nameBox.Text;
                            }

                            else
                            {
                                nameBox.Text = "Please Enter a Name!";
                            }

                            Refresh();
                        }

                        else if (gameState == "lost")
                        {
                            GameInit();
                        }
                    }
                    break;


                case Keys.K:
                    {
                        if (kDown == false && gameState == "running")
                        {
                            currentGeneration++;
                            RunNextGeneration();

                            Refresh();
                        }

                        kDown = true;
                    }
                    break;

                case Keys.Escape:
                    this.Close();
                    break;

                case Keys.D1:
                    {
                        this.BackColor = Color.FromName("ActiveCaption");
                    }
                    break;

                case Keys.D2:
                    {
                        this.BackColor = Color.FromName("RosyBrown");
                    }
                    break;

                case Keys.D3:
                    {
                        this.BackColor = Color.FromName("DarkOliveGreen");
                    }
                    break;

                case Keys.D4:
                    {
                        this.BackColor = Color.FromName("LemonChiffon");
                    }
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    {
                        escDown = false;
                    }
                    break;

                case Keys.K:
                    {
                        kDown = false;
                    }
                    break;
            }
        }
        private void darwin_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "menu")
            {
                playerDefenceLabel.Text = null;
                playerStrengthLabel.Text = null;
                playerPopulationLabel.Text = null;
                playerSizeLabel.Text = null;

                playerDietTypeLabel.Text = null;
                playerHabitatLabel.Text = null;

                mutationMessageLabel.Visible = false;
                eventLabel.Visible = false;

                nameBox.Visible = true;

                kLabel.Text = null;
                nameLabel.Text = null;

                environmentDefenceLabel.Text = null;
                environmentStrengthLabel.Text = null;

                pastMutationsLabel.Visible = false;

                startLabel.Text = "Press Enter to Start!";
                nameBoxLabel.Text = "Name Your Creature!";
            }

            else if (gameState == "running")
            {
                pastMutationsLabel.Visible = true;
                mutationMessageLabel.Visible = true;
                eventLabel.Visible = true;
                nameBox.Visible = false;
                nameLabel.Visible = true;

                nameLabel.Text = creatureName;

                playerDefenceLabel.Text = $"Player Defence: {playerDefence}";
                playerStrengthLabel.Text = $"Player Strength: {playerStrength}";
                playerPopulationLabel.Text = $"Player Population: {playerPopulation}";
                playerDietTypeLabel.Text = $"Diet Type: {playerDietType}";
                playerHabitatLabel.Text = $"Habitat: {playerHabitat}";
                playerSizeLabel.Text = $"Player Size: {playerSize}";
                mutationMessageLabel.Text = $"Most Recent Mutation: {possibleMutations[mutationPos].OutputMessage()}"
                    + $"\n A: {possibleMutations[mutationPos].StrengthChange()}"
                    + $"  D: {possibleMutations[mutationPos].DefenceChange()}"; //UPDATE

                environmentDefenceLabel.Text = $"Environment Defence: {environmentDefence}";
                environmentStrengthLabel.Text = $"Environment Strength: {environmentStrength}";

                startLabel.Text = null;
                nameBoxLabel.Text = null;
                kLabel.Text = "Press K to Move On to the Next Generation!";
            }

            else if (gameState == "lost")
            {
                playerDefenceLabel.Text = null;
                playerStrengthLabel.Text = null;
                playerPopulationLabel.Text = null;
                playerDietTypeLabel.Text = null;
                playerHabitatLabel.Text = null;
                playerSizeLabel.Text = null;
                nameBoxLabel.Text = null;
                nameLabel.Visible = false;

                mutationMessageLabel.Visible = false;
                nameBox.Visible = false;
                eventLabel.Visible = true;

                eventLabel.Text = "You're Creature Went Extinct!"
                    + $"\n Cause of Death: {causeOfDeath}";

                environmentDefenceLabel.Text = null;
                environmentStrengthLabel.Text = null;

                pastMutationsLabel.Visible = false;

                startLabel.Text = "Press Enter to Return to Menu!";
                kLabel.Text = null;
            }
        }

        public void GameInit()
        {
            generations.Clear();
            pastMutationsLabel.Items.Clear();
            eventLabel.Text = "";

            SetPossibleMutations();
            SetPossibleEvents();
            gameState = "menu";

            currentGeneration = 0;

            environmentDefence = 0;
            environmentStrength = 0;

            playerDefence = 0;
            playerStrength = 0;
            playerSize = 0;

            playerPopulation = 10;

            appendageCount = 0;
            eyeCount = 0;

            SelectDietType();
            SelectHabitat();

            generations.Add(new Generation(currentGeneration, playerStrength, playerDefence, playerSize, playerPopulation, playerHabitat, playerDietType));

            DisplayGenerationData();

            Refresh();
        }

        public void RunNextGeneration()
        {
            eventLabel.Text = "";

            GenerateMutations();
            UpdateEnvironment();
            UpdatePlayerPop();
            RunEvents();

            KillPlayer();

            generations.Add(new Generation(currentGeneration, playerStrength, playerDefence, playerSize, playerPopulation, playerHabitat, playerDietType));

            DisplayGenerationData();
        }
        public void DisplayGenerationData()
        {
            ListViewItem generation = new ListViewItem($"{currentGeneration}", 0);

            generation.SubItems.Add($"{playerStrength}");
            generation.SubItems.Add($"{playerDefence}");
            generation.SubItems.Add($"{playerDietType}");
            generation.SubItems.Add($"{playerPopulation}");
            generation.SubItems.Add($"{possibleMutations[mutationPos].OutputMessage()}");
            generation.SubItems.Add($"{playerSize}");
            generation.SubItems.Add($"{playerHabitat}");

            pastMutationsLabel.Items.Add(generation);
        }

        public void GenerateMutations()
        {
            Random coinToss = new Random();

            int genMutation = coinToss.Next(0, 101);

            if (genMutation > 33)
            {
                Random mutationRoll = new Random();
                mutationPos = mutationRoll.Next(0, possibleMutations.Count() - 1);
                string mutName = possibleMutations[mutationPos].MutationName();

                CheckMutationPossibility(mutationPos, mutName);
            }

            else
            {
                mutationPos = 0;
            }
        }

        public void CheckMutationPossibility(int m, string mutName)
        {
            bool mutPossible = false;

            //if (appendageCount > 0 && appendageBuff == true)
            //{
            //    playerStrength++;
            //    playerDefence++;

            //    appendageBuff = false;
            //} //UPDATE

            if (possibleMutations[m].WaterOnly() == true && playerHabitat == "aquatic")
            {
                ChangeStats(m);
                mutPossible = true;
            }

            else if (possibleMutations[m].LandOnly() == true && playerHabitat == "land-based")
            {
                ChangeStats(m);
                mutPossible = true;
            }

            else if (playerHabitat == "semi-aquatic")
            {
                ChangeStats(m);
                mutPossible = true;
            }

            else if (possibleMutations[m].WaterOnly() == false && possibleMutations[m].LandOnly() == false)
            {
                ChangeStats(m);
                mutPossible = true;
            }

            if (mutPossible == false)
            {
                mutationPos = 0;
            }
        }

        public void ChangeStats(int m)
        {
            //Strength Changes
            if (playerStrength == 0 && possibleMutations[m].StrengthChange() < 0 && possibleMutations[m].DefenceChange() >= 0)
            {
                mutationPos = 0;
            }

            else if (playerDefence == 0 && playerStrength == 0 && possibleMutations[m].StrengthChange() < 0
                    || playerDefence == 0 && playerStrength == 0 && possibleMutations[m].DefenceChange() < 0)
            {
                mutationPos = 0;
            }

            else if (playerStrength + possibleMutations[m].StrengthChange() >= 0)
            {
                playerStrength += possibleMutations[m].StrengthChange();
            }

            else if (playerStrength + possibleMutations[m].StrengthChange() < 0)
            {
                playerStrength = 0;
            }

            //Defence Changes
            if (playerDefence == 0 && possibleMutations[m].DefenceChange() < 0 && possibleMutations[m].StrengthChange() >= 0)
            {
                mutationPos = 0;
            }

            else if (playerDefence + possibleMutations[m].DefenceChange() >= 0)
            {
                playerDefence += possibleMutations[m].DefenceChange();
            }

            else if (playerDefence + possibleMutations[m].DefenceChange() < 0)
            {
                playerDefence = 0;
            }


            //Size Changes
            if (playerSize == 0 && possibleMutations[m].SizeChange() < 0)
            {
                mutationPos = 0;
            }

            else if (playerSize + possibleMutations[m].SizeChange() >= 0)
            {
                playerSize += possibleMutations[m].SizeChange();
            }

            else if (playerSize + possibleMutations[m].SizeChange() < 0)
            {
                playerSize = 1;
            }

            RunSpecialMutation();
        }

        public void RunSpecialMutation()
        {
            if (possibleMutations[mutationPos].MutationName() == "dietChange")
            {
                SelectDietType();
            }

            else if (possibleMutations[mutationPos].MutationName() == "habitatChange")
            {
                SelectHabitat();
            }

            else if (possibleMutations[mutationPos].MutationName() == "semi-aquatic" && playerHabitat != "semi-aquatic")
            {
                playerHabitat = "semi-aquatic";
            }
        }

        public void SelectDietType()
        {
            string prevDietType = playerDietType;

            Random dietGen = new Random();
            int diet = dietGen.Next(0, 3);

            switch (diet)
            {
                case 0:
                    playerDietType = "carnivore";
                    break;

                case 1:
                    playerDietType = "herbivore";
                    break;

                case 2:
                    playerDietType = "omnivore";
                    break;
            }

            if (prevDietType == playerDietType || currentGeneration == 0)
            {
                mutationPos = 0;
            }
        }

        public void SelectHabitat()
        {
            string prevHabitat = playerHabitat;

            Random habitatGen = new Random();
            int habitat = habitatGen.Next(0, 2);

            switch (habitat)
            {
                case 0:
                    playerHabitat = "aquatic";
                    break;

                case 1:
                    playerHabitat = "land-based";
                    break;
            }

            if (prevHabitat == playerHabitat || currentGeneration == 1)
            {
                mutationPos = 0;
            }
        }

        public void ClearPlayerData()
        {
            generations.Clear();
        }

        public void UpdateEnvironment()
        {
            if (currentGeneration % 7 == 0 && currentGeneration != 0)
            {
                environmentDefence++;
                environmentStrength++;
            }
        }

        public void UpdatePlayerPop()
        {
            if (currentGeneration % 5 == 0 && currentGeneration != 0)
            {
                playerPopulation++;
                eventLabel.Text += "\n Population Up! ";
            }

            if (playerDefence < environmentStrength)
            {
                playerPopulation--;
                eventLabel.Text += "\n Eaten by Predators! ";
                causeOfDeath = "Eaten by Predators!";
            }

            if (playerStrength < environmentDefence && playerDietType == "carnivore")
            {
                playerPopulation--;
                eventLabel.Text += "\n Failed to Hunt Enough Food! ";
                causeOfDeath = "Couldn't Find Food!";
            }
        }

        public void KillPlayer()
        {
            if (playerPopulation <= 0)
            {
                gameState = "lost";

                Refresh();
            }
        }

        public void SetPossibleMutations()  //Sets the mutations that can be selected each generation
        {
            //possibleMutations.Clear(); //Clears mutations so the list does not get to have a million of the same items

            //Mutation for if other mutations are not possible (ex. stats being lowered below zero)
            possibleMutations.Add(new Mutation("noMutation", "Nothing new!", 0, 0, 0, false, false));

            //Stat Mutations
            possibleMutations.Add(new Mutation("smallGrow", "Grew a Little!", 0, 0, 1, false, false));
            possibleMutations.Add(new Mutation("medGrow", "Grew a Bit!", 0, 0, 2, false, false));
            possibleMutations.Add(new Mutation("largeGrow", "Grew a Lot!", 0, 0, 3, false, false));

            possibleMutations.Add(new Mutation("smallShrink", "Shrank a Little!", 0, 0, -1, false, false));
            possibleMutations.Add(new Mutation("medShrink", "Shrank a Bit!", 0, 0, -2, false, false));
            possibleMutations.Add(new Mutation("largeShrink", "Shrank a Lot!", 0, 0, -3, false, false));

            possibleMutations.Add(new Mutation("flight", "Flight!", 1, 1, 0, false, true));
            possibleMutations.Add(new Mutation("fins", "Fins!", 1, 1, 0, true, false));

            possibleMutations.Add(new Mutation("smallAttackUp", "Small Attack Increase!", 0, 1, 0, false, false));
            possibleMutations.Add(new Mutation("medAttackUp", "Medium Attack Increase!", 0, 2, 0, false, false));
            possibleMutations.Add(new Mutation("largeAttackUp", "Large Attack Increase!", 0, 3, 0, false, false));
            possibleMutations.Add(new Mutation("sharpClaws", "Sharpened Claws!", 0, 1, 0, false, false));
            possibleMutations.Add(new Mutation("sharpTeeth", "Sharpened Teeth!", 0, 1, 0, false, false));
            possibleMutations.Add(new Mutation("acidSpit", "Acidic Spit!", 0, 2, 0, false, false));
            possibleMutations.Add(new Mutation("venom", "Venom!", 0, 2, 0, false, false));

            possibleMutations.Add(new Mutation("smallDefenceUp", "Small Defence Increase!", 1, 0, 0, false, false));
            possibleMutations.Add(new Mutation("medDefenceUp", "Medium Defence Increase!", 2, 0, 0, false, false));
            possibleMutations.Add(new Mutation("largeDefenceUp", "Large Defence Increase!", 3, 0, 0, false, false));
            possibleMutations.Add(new Mutation("tough", "Tougher!", 1, 0, 0, false, false));
            possibleMutations.Add(new Mutation("armour", "Armour!", 2, 0, 0, false, false));
            possibleMutations.Add(new Mutation("nesting", "Nesting!", 2, 0, 0, false, false));

            possibleMutations.Add(new Mutation("smallAttackDown", "Small Attack Decrease!", 0, -1, 0, false, false));
            possibleMutations.Add(new Mutation("medAttackDown", "Medium Attack Decrease!", 0, -2, 0, false, false));
            possibleMutations.Add(new Mutation("largeAttackDown", "Large Attack Decrease!", 0, -3, 0, false, false));
            possibleMutations.Add(new Mutation("skittish", "Skittish!", 0, -1, 0, false, false));

            possibleMutations.Add(new Mutation("smallDefenceDown", "Small Defence Decrease!", -1, 0, 0, false, false));
            possibleMutations.Add(new Mutation("medDefenceDown", "Medium Defence Decrease!", -2, 0, 0, false, false));
            possibleMutations.Add(new Mutation("largeDefenceDown", "Large Defence Decrease!", -3, 0, 0, false, false));

            possibleMutations.Add(new Mutation("opticsUp", "Two More Eyes!", 1, 1, 0, false, false));
            possibleMutations.Add(new Mutation("opticsDown", "Two Less Eyes!", -1, -1, 0, false, false));

            possibleMutations.Add(new Mutation("hearingUp", "Better Hearing!", 1, 1, 0, false, false));
            possibleMutations.Add(new Mutation("hearingDown", "Worse Hearing!", -1, -1, 0, false, false));

            possibleMutations.Add(new Mutation("badLuck", "...", -3, -3, -3, false, false));


            //Special Mutations
            possibleMutations.Add(new Mutation("dietChange", "New Diet!", 0, 0, 0, false, false)); //Changes creatues dietType
            possibleMutations.Add(new Mutation("habitatChange", "Migrated!", 0, 0, 0, false, false)); //Changes players habitat           
            possibleMutations.Add(new Mutation("semi-aquatic", "Semi-Aquatic!", 0, 0, 0, false, false)); //Allows player to benefit from both aquatic and land-based buffs

            //possibleMutations.Add("minusRandomPastMutation"); ////Removes a past mutation at random
            //possibleMutations.Add(new Mutation("addTwoAppendages", "More Appendages!", 0, 0, 0, false, false)); //Adds 2 to appendageCount, if appendageCount > 0 add one to playerStrength and playerDefence
        }

        public void SetPossibleEvents()
        {
            possibleEvents.Add(new Event("hurricane", "A Hurricane Occured! "));
            possibleEvents.Add(new Event("chanceEncounter", "A Chance Encounter! "));
            possibleEvents.Add(new Event("matingSeason", "It's Mating Season! "));
        }

        public void RunEvents()
        {
            if (currentGeneration % 3 == 0 && currentGeneration != 0)
            {
                Random eventChance = new Random();
                int eventRun = eventChance.Next(0, 101);

                if (eventRun > 50)
                {
                    Random eventGen = new Random();
                    eventPos = eventGen.Next(0, possibleEvents.Count());

                    string chosenEvent = possibleEvents[eventPos].EventName();

                    switch (chosenEvent)
                    {
                        case "hurricane":
                            {
                                GenNaturalDisastor();
                            }
                            break;

                        case "chanceEncounter":
                            {
                                GenChanceEncounter();
                            }
                            break;

                        case "matingSeason":
                            {
                                GenMatingSeason();
                            }
                            break;
                    }
                }
            }
        }

        public void GenNaturalDisastor()
        {
            Random disasterLevel = new Random();
            int deaths = disasterLevel.Next(0, 4);

            eventLabel.Text += possibleEvents[eventPos].Description() + $" {deaths} {creatureName}(s) Died!";

            playerPopulation -= deaths;

            causeOfDeath = "Hurricane Season!";
        }

        public void GenMatingSeason()
        {
            Random random = new Random();
            int pop = random.Next(0, 3);

            playerPopulation += pop;

            eventLabel.Text += possibleEvents[eventPos].Description() + $" {pop} New {creatureName}(s) are Born!";
        }

        public void GenChanceEncounter()
        {
            List<string> chars = new List<string>();

            chars.Add("God");
            chars.Add("Saul Goodman");
            chars.Add("Poacher");
            chars.Add("Creature");
            chars.Add("Thanos");

            Random random = new Random();
            string charMet = chars[random.Next(0, chars.Count)];

            int str;
            int def;
            int pop;

            switch (charMet)
            {
                case "God":
                    {
                        str = random.Next(0, 4);
                        def = random.Next(0, 4);
                        pop = random.Next(0, 4);

                        if (random.Next(0, 11) > 3)
                        {
                            playerStrength += str;
                            playerDefence += def;
                            playerPopulation += pop;

                            eventLabel.Text += possibleEvents[eventPos].Description() +
                                $" You Met God! God Takes Pity on Thee: \n +{str} Strength; +{def} Defence; +{pop} Population.";
                        }

                        else
                        {
                            playerStrength -= str;
                            playerDefence -= def;
                            playerPopulation -= pop;

                            eventLabel.Text += possibleEvents[eventPos].Description() +
                                $" You Met God! God Smites Thee: \n -{str} Strength; -{def} Defence; -{pop} Population.";

                            causeOfDeath = "Smitten by God??";
                        }

                    }
                    break;

                case "Saul Goodman":
                    {
                        def = random.Next(1, 4);
                        playerDefence += def;

                        eventLabel.Text += possibleEvents[eventPos].Description() +
                            $" You Met Saul Goodman! +{def} Legal Defence!";
                    }
                    break;

                case "Poacher":
                    {
                        pop = random.Next(1, 4);
                        playerPopulation -= pop;

                        eventLabel.Text += possibleEvents[eventPos].Description() +
                            $" You Met A Poacher! {pop} {creatureName}(s) Die!";

                        causeOfDeath = "Poached!";
                    }
                    break;

                case "Creature":
                    {
                        if (random.Next(2, 2) == 1)
                        {
                            str = random.Next(1, 4);
                            playerStrength += str;

                            eventLabel.Text += possibleEvents[eventPos].Description() + $" Ƴㄖᙀ ᙏ乇Ʈ Ʈ卄ᙓ ᙅ尺ᙓ卂Ʈㄩᖇ乇...";
                            eventLabel.Text += "\n\n ꒐ꋖ ꒒꒐ꈵꑀꈜ ꐔꊿꌈ" + $"\n You Feel Stronger in the Morning. +{str} Strength!";
                        }

                        else
                        {
                            pop = random.Next(1, 3);
                            playerPopulation -= pop;

                            eventLabel.Text += possibleEvents[eventPos].Description() + $" Ƴㄖᙀ ᙏ乇Ʈ Ʈ卄ᙓ ᙅ尺ᙓ卂Ʈㄩᖇ乇...";
                            eventLabel.Text += "\n\n Ꙇㄒ ᗪO乇ᔑ几'ㄒ ㄥꙆҜᙓ Ƴㄖᙀ " + $"\n {pop} {creatureName} Vanish Without a Trace...";

                            int deathCard = random.Next(0, 3);
                            if (deathCard == 0)
                            {
                                causeOfDeath = "The Accident Wasn't Your Fault...";
                            }

                            else if (deathCard == 1)
                            {
                                causeOfDeath = "Wake Up...";
                            }

                            else
                            {
                                causeOfDeath = "They Miss You...";
                            }
                        }
                    }
                    break;

                case "Thanos":
                    {
                        playerPopulation /= 2;
                        playerStrength += 5;
                        playerDefence += 5;

                        eventLabel.Text += possibleEvents[eventPos].Description() + $"You met Thanos! ";
                        eventLabel.Text += "\n\n Watching Your Family Turn to Dust Strengthens Your Resolve " + "\n 0.5x Population, +5 Strength, +5 Defence. ";

                        causeOfDeath = "Snapped Away!";
                    }
                    break;
            }

            StatAdjustments();

            if (playerPopulation < 1)
            {
                if (random.Next(0, 100) < 25)
                {
                    playerPopulation = 1;
                    eventLabel.Text += " You Escaped Extincion By a Hair!";
                }
            }
        }

        public void StatAdjustments()
        {
            if (playerStrength < 0)
            {
                playerStrength = 0;
            }

            if (playerDefence < 0)
            {
                playerDefence = 0;
            }

            if (playerSize < 0)
            {
                playerSize = 0;
            }
        }
    }
}
